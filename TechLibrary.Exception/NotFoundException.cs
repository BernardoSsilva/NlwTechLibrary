using System.Net;

namespace TechLibrary.Exception
{
    public class NotFoundException : TechLibraryException
    {
        public NotFoundException(string message) : base(message)
        {
         
        }
        public override List<string> getErrorMessages() => [Message];

        public override HttpStatusCode getStatusCode() => HttpStatusCode.NotFound;
    }
}
