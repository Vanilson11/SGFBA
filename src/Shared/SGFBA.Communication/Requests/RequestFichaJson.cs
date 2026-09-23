using SGFBA.Communication.Enums;

namespace SGFBA.Communication.Requests;

public class RequestFichaJson
{
    public DateTime DataAbertura { get; set; }
    public Motivo Motivo { get; set; }
    public StatusFicha Status { get; set; }
    public string? Observacao { get; set; }
}
