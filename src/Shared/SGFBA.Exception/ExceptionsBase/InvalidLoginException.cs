using System.Net;

namespace SGFBA.Exception.ExceptionsBase;

public class InvalidLoginException : SGFBAException
{
    public InvalidLoginException(string message) : base(message)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public override List<string> GetErros()
    {
        return [Message];
    }
}
