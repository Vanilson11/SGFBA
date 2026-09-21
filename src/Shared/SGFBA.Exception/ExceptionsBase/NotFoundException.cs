using System.Net;

namespace SGFBA.Exception.ExceptionsBase;

public class NotFoundException : SGFBAException
{
    public NotFoundException(string message) : base(message)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErros()
    {
        return [Message];
    }
}
