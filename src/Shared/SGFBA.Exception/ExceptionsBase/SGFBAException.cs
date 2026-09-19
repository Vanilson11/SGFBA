namespace SGFBA.Exception.ExceptionsBase;

public abstract class SGFBAException : System.Exception
{
    protected SGFBAException(string message) : base(message)
    {
        
    }
    public abstract int StatusCode { get; }
    public abstract List<string> GetErros();
}
