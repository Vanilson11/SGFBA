using SGFBA.Communication.Enums;

namespace SGFBA.Communication.Responses;

public class ResponseRegistrarAcaoJson
{
    public long Id { get; set; }
    public TipoAcao Tipo { get; set; }
    public DateTime Data { get; set; }
}
