using System.Net;

namespace DominoApi.Exceptions
{
    public class NotValidChainException : DominoException
    {
        public NotValidChainException() : base(HttpStatusCode.BadRequest, "Not valid Chain Found")
        {
        }
    }
}
