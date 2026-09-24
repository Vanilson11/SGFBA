using SGFBA.Communication.Enums;

namespace SGFBA.Communication.Responses;

public class ResponseShortAcaoJson
{
    public TipoAcao Tipo { get; set; }
    public DateTime Data { get; set; }
    public string? Observacao { get; set; }
    public long IdFicha { get; set; }
}
