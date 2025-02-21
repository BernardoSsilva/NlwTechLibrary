using System.Net;

namespace TechLibrary.Exception
{
    public class ErrorOnValidationException : TechLibraryException
    {
        private readonly List<string> _errors;
        public ErrorOnValidationException(List<string> errorMessages) : base (string.Empty)
        {
            _errors = errorMessages;
        }
        public override List<string> getErrorMessages() => _errors;
        public override HttpStatusCode getStatusCode() => HttpStatusCode.BadRequest;
        
    }
}
