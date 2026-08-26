using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExceptionHandlingLab.ExceptionHandlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is InvalidOperationException invalidOp)
            {
                _logger.LogError(invalidOp, $"invalid operation; {invalidOp.Message}");

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await httpContext.Response.WriteAsJsonAsync(new
                {
                    error = "A data error occurred. Please try again later."
                },
                cancellationToken);

            }
            //else
            //{
            _logger.LogError(exception, "An unexpected error occurred");

            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(new
            {
                error = "An unexpected error occurred.Please try again later."
            },
                cancellationToken
            );
            //}
            return true;
        }
    }
}
