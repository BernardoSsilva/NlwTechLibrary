using System.Net;

namespace TechLibrary.Exception
{
    public abstract class TechLibraryException:SystemException
    {
        public abstract List<string> getErrorMessages();
        public abstract HttpStatusCode getStatusCode();
    }
}
