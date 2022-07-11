using Newtonsoft.Json;

namespace Bank.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                _logger.LogError(ex.Message + "\n" + ex.InnerException?.Message);
                _logger.LogError("Error query: {query}", context.Request.Path);
                _logger.LogError(ex.StackTrace);
                var result = JsonConvert.SerializeObject(new
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    ErrorMessage = ex.Message

                });

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.WriteAsync(result);
            }
        }
    }
}
