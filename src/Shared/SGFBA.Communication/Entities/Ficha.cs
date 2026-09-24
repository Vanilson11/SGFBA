using SGFBA.Communication.Enums;

namespace SGFBA.Communication.Entities;

public class Ficha
{
    public DateTime DataAbertura { get; set; }
    public Motivo Motivo { get; set; }
    public StatusFicha Status { get; set; }
    public string? Observacao { get; set; }
    public ICollection<Acao> Acoes { get; set; } = [];
}
