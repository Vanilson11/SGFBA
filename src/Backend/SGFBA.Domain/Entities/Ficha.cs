using SGFBA.Domain.Enums;

namespace SGFBA.Domain.Entities;

public class Ficha
{
    public long Id { get; set; }
    public DateTime DataAbertura { get; set; }
    public Motivo Motivo { get; set; }
    public StatusFicha Status { get; set; }
    public string? Observacao { get; set; }
    public Guid FichaIdentifier { get; set; } = Guid.CreateVersion7();
    public long IdUsuario { get; set; }//trocar o nome para IdUsuario
    public Usuario Usuario { get; set; } = default!;
    public long IdEstudante { get; set; }
    public Estudante Estudante { get; set; } = default!;
}
