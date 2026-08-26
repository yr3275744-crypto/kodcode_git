using System.Net;

namespace TasksApi.Middelware
{
    public class ExceptionHandlingMiddelware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddelware> _logger;

        public ExceptionHandlingMiddelware(RequestDelegate next,
            ILogger<ExceptionHandlingMiddelware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, $"Invalid operation - reason: {ex.Message}");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsJsonAsync("somthing get wrong, try later");
            }
            catch (TimeoutException ex)
            {
                _logger.LogError(ex, $"time out. reason: {ex.Message}");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsJsonAsync("somthing get wrong,time is gone. try later");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Invalid operation - reason: {ex.Message}");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsJsonAsync("somthing get wrong, try later");
            }
        }
    }
}
