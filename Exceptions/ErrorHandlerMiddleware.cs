using Newtonsoft.Json;
using System.Net;

namespace DominoApi.Exceptions
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var result = string.Empty;
                var response = context.Response;
                response.ContentType = "application/json";
                switch (error)
                {
                    case NotValidChainException notValidChainException:
                        await notValidChainException.SetHttpResponse(context);
                        break;
                    default:
                        _logger.LogCritical($"CriticalError: {error.Message}");
                        result = JsonConvert.SerializeObject(new { error = error.Message });
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                await response.WriteAsync(result);
            }
        }
    }
}
