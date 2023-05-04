using Newtonsoft.Json;
using System.Net;
using System.Runtime.Serialization;

namespace DominoApi.Exceptions
{
    public class DominoException : Exception
    {
        public readonly string _message;
        public readonly HttpStatusCode _statusCode;

        protected DominoException(HttpStatusCode statusCode, string message)
        {
            _statusCode = statusCode;
            _message = message;
        }

        protected DominoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public async Task SetHttpResponse(HttpContext httpContext)
        {
            httpContext.Response.StatusCode = (int)_statusCode;
            var response = new
            {
                Status = httpContext.Response.StatusCode,
                Message = _message
            };

            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
