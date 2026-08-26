using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace TasksApi.ExceptionHandlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, 
            Exception exception, 
            CancellationToken cancellationToken)
        {
           if (exception is InvalidOperationException IoEx)
            {
                _logger.LogError(IoEx, $"Invalid operation. reason: {IoEx.Message}");
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await httpContext.Response.WriteAsJsonAsync("invalid operation, try later");
            }
           else
            {
                _logger.LogError(exception, $"error. reason: {exception.Message}");
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await httpContext.Response.WriteAsJsonAsync("somthing get wrong, try later");
            }
            return true;
        }
    }
}
