namespace CompanyName.Notebook.NoteTaking.Infrastructure.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using AutoMapper;
    using CompanyName.Notebook.NoteTaking.Core.Application.Services;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Factories;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Services;
    using CompanyName.Notebook.NoteTaking.Infrastructure.Data.MongoDb;
    using CompanyName.Notebook.NoteTaking.Infrastructure.Server;
    using CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Authorization.Requirements;
    using CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Exceptions;
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using Newtonsoft.Json;
    using Swashbuckle.AspNetCore.Swagger;

    public class Startup
    {
        private readonly ILogger<NoteBookExceptionFilter> _logger;

        public Startup(IConfiguration configuration, ILogger<NoteBookExceptionFilter> logger)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Support For Metrics
            services
                .AddMetrics(
                    Configuration.GetSection("AppMetrics"), 
                    options => options.GlobalTags.Add("app", "Reference Architecture - Note Taking Service"))
                .AddJsonSerialization()
                .AddHealthChecks()
                .AddMetricsMiddleware(Configuration.GetSection("AspNetMetrics"));

            // Add Framework services
            services.AddMvc(config => {
                config.Filters.Add(typeof(NoteBookExceptionFilter));
                config.AddMetricsResourceFilter();
            }).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MongoMappingProfile>();
                cfg.AddProfile<MessageMappingProfile>();
            });

            // Add Authentication Support
            var tokenValidationParameters = new TokenValidationParameters
            {
                NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
            };

            string domain = $"https://{Configuration["NoteTaking:UserProfileService:Auth0:Domain"]}/";
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = domain;
                options.Audience = Configuration["NoteTaking:UserProfileService:Auth0:ApiIdentifier"];
                options.TokenValidationParameters = tokenValidationParameters;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("https://company.dev/notetaking/pingsecure", 
                    policy => policy.Requirements.Add(new HasScopeRequirement("https://company.dev/notetaking/pingsecure", domain)));
                options.AddPolicy("https://company.dev/notetaking/default", 
                    policy => policy.Requirements.Add(new HasScopeRequirement("https://company.dev/notetaking/default", domain)));
                options.AddPolicy("https://company.dev/notetaking/categories:read", 
                    policy => policy.Requirements.Add(new HasScopeRequirement("https://company.dev/notetaking/categories:read", domain)));
                options.AddPolicy("https://company.dev/notetaking/categories:write", 
                    policy => policy.Requirements.Add(new HasScopeRequirement("https://company.dev/notetaking/categories:write", domain)));
            });
            

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info {
                    Title = "Note Taking API",
                    Version = "v1",
                    Description = "Microservice reference architecture featuring DDD and Onion.",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Walter Pinson", Email = "", Url = "https://github.com/walterpinson" },
                });
            });

            // Add Application services.
            services.AddSingleton<INoteFactory, NoteFactory>();
            services.AddSingleton<ISubscriberFactory, SubscriberFactory>();
            services.AddSingleton<ICategoryFactory, CategoryFactory>();
            services.AddTransient<ICategoryRepository>(sp =>
                new CategoryRepository(Configuration.GetConnectionString("NoteTakingService"), sp.GetRequiredService<IMapper>()));
            services.AddTransient<INoteTaker, NoteTaker>();
            services.AddTransient<IRegistrar, Registrar>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(options => {
                    options.Run(async context => {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";
                        var ex = context.Features.Get<IExceptionHandlerFeature>();
                        if (ex != null)
                        {
                            _logger.LogError(0, ex.Error, "Unhandled exception in Note Taker service.");
                            var result = JsonConvert.SerializeObject(new { error = ex.Error.Message, innerError = ex.Error.InnerException.Message });
                            await context.Response.WriteAsync(result).ConfigureAwait(false);
                        }
                    });
                });
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Note Taking API V1");
            });

            app.UseAuthentication();
            app.UseMetrics();
            app.UseMvc();
        }
    }
}
