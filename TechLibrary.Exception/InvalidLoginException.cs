using System.Net;

namespace TechLibrary.Exception
{
    public class InvalidLoginException : TechLibraryException
    {
        private readonly List<string> _errors;

        public override List<string> getErrorMessages() => ["invalid email or password"];

        public override HttpStatusCode getStatusCode() => HttpStatusCode.Unauthorized;
    }
}
