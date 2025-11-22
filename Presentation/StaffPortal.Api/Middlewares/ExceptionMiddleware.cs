using Newtonsoft.Json;
using StaffPortal.Application.Dtos;
using StaffPortal.Application.Exceptions;
using System.Net;

namespace StaffPortal.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, IWebHostEnvironment env, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _env = env;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                _logger.LogWarning("Test");
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode;
            string message = exception.Message;

            // Xətanı log faylında saxla
            _logger.LogError(exception, "Unhandled exception occurred.");

            if (exception is BaseException baseEx)
                statusCode = baseEx.StatusCode;
            else
                statusCode = HttpStatusCode.InternalServerError;

            var response = new ErrorResponse
            {
                StatusCode = (int)statusCode,
                Message = message,
                Details = _env.IsDevelopment() ? exception.StackTrace : null
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var json = JsonConvert.SerializeObject(response);
            await context.Response.WriteAsync(json);
        }
    }
}

