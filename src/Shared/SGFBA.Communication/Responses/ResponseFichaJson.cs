using SGFBA.Communication.Enums;

namespace SGFBA.Communication.Responses;

public class ResponseFichaJson
{
    public long Id { get; set; }
    public DateTime DataAbertura { get; set; }
    public Motivo Motivo { get; set; }
    public StatusFicha Status { get; set; }
    public string? Observacao { get; set; }
}
