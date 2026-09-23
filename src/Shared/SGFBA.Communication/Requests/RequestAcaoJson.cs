using SGFBA.Communication.Enums;

namespace SGFBA.Communication.Requests;

public class RequestAcaoJson
{
    public TipoAcao Tipo { get; set; }
    public DateTime Data { get; set; }
    public string? Observacao { get; set; }
}
