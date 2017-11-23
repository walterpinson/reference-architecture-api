namespace CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Exceptions
{
    using System;
    using System.Net;
    using CompanyName.Notebook.NoteTaking.Core.Application.Exceptions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    public class NoteBookExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<NoteBookExceptionFilter> _logger;

        public NoteBookExceptionFilter(ILogger<NoteBookExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            String message = String.Empty;
    
            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                message = "Unauthorized Access";
                status = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                message = "A server error occurred.";
                status = HttpStatusCode.NotImplemented;
            }
            else if (exceptionType == typeof(NotFoundException))
            {
                message = "Resource not found.";
                status = HttpStatusCode.NotFound;
            }
            else if (exceptionType == typeof(ArgumentException) || exceptionType == typeof(ArgumentNullException))
            {
                message = "Malformed input data.";
                status = HttpStatusCode.BadRequest;
            }
            else
            {
                message = context.Exception.ToString();
                status = HttpStatusCode.InternalServerError;
            }

            _logger.LogError(0, context.Exception, message);

            var result = JsonConvert.SerializeObject(new { error = message, innerError = context.Exception.Message });
            
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            response.WriteAsync(result);
        }
    }
}