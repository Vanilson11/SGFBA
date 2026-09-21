using SGFBA.Communication.Enums;

namespace SGFBA.Communication.Responses;

public class ResponseRegistrarFichaJson
{
    public long Id { get; set; }
    public DateTime DataAbertura { get; set; }
    public StatusFicha Status { get; set; }
}
