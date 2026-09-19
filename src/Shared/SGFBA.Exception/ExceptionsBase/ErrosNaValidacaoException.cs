using System.Net;

namespace SGFBA.Exception.ExceptionsBase;

public class ErrosNaValidacaoException : SGFBAException
{
    private List<string> _erros { get; set; } = [];

    public ErrosNaValidacaoException(List<string> erros) : base(string.Empty)
    {
        _erros = erros;
    }
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public override List<string> GetErros() => _erros;
}
