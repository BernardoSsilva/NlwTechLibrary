using System.Net;

namespace TechLibrary.Exception
{
    public class ConflictException: TechLibraryException
    {
        public ConflictException(string message) : base(message)
        {

        }
        public override List<string> getErrorMessages() => [Message];

        public override HttpStatusCode getStatusCode() => HttpStatusCode.Conflict;
    }
}
