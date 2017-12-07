namespace CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.HealthChecks
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using CompanyName.Notebook.NoteTaking.Infrastructure.Data.MongoDb;
    using App.Metrics.Health;
    using AutoMapper;
    using Microsoft.Extensions.Configuration;

    public class MongoHealthCheck : HealthCheck
    {
        IConfigurationRoot _config = null;
        string _connectionString = string.Empty;

        public MongoHealthCheck() : base("MongoDb") {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables();
            _config = builder.Build();
            _connectionString = _config.GetConnectionString("NoteTakingService");

        }

        protected override Task<HealthCheckResult> CheckAsync(CancellationToken token = default(CancellationToken))
        {
            try
            {


                IMapper mapper = Mapper.Instance;
                var subjectUnderTest = new CategoryRepository(_connectionString, mapper);

                return Task.FromResult(HealthCheckResult.Healthy("Ok. MongoDb is up and running"));          
            }
            catch (Exception ex)
            {
                return Task.FromResult(HealthCheckResult.Unhealthy(ex.Message));          
            }
        }
    }
}