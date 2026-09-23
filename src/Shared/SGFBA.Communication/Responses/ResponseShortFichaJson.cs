using SGFBA.Communication.Enums;

namespace SGFBA.Communication.Responses;

public class ResponseShortFichaJson
{
    public DateTime DataAbertura { get; set; }
    public Motivo Motivo { get; set; }
    public StatusFicha Status { get; set; }
}
