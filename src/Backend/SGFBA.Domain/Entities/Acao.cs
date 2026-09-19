using SGFBA.Domain.Enums;

namespace SGFBA.Domain.Entities;

public class Acao
{
    public long Id { get; set; }
    public TipoAcao Tipo { get; set; }
    public DateTime Data { get; set; }
    public string? Observacao { get; set; }
    public Guid AcaoIdentifier { get; set; } = Guid.CreateVersion7();
    public long IdFicha { get; set; }
    public Ficha Ficha { get; set; } = default!;
}
