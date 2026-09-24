using SGFBA.Communication.Enums;

namespace SGFBA.Communication.Entities;

public class Acao
{
    public long Id { get; set; }
    public TipoAcao Tipo { get; set; }
    public DateTime Data { get; set; }
    public string? Observacao { get; set; }
}
