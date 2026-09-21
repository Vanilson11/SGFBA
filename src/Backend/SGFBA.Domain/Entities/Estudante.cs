using SGFBA.Domain.Enums;

namespace SGFBA.Domain.Entities;

public class Estudante
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public Turma Turma { get; set; }
    public Turno Turno { get; set; }
    public DateTime DataNascimento { get; set; }
    public string NomeResponsavel { get; set; } = string.Empty;
    public string TelefoneResponsavel { get; set; } = string.Empty;
    public bool Ativo { get; set; } = true;
    public Guid StudentIdentifier { get; set; } = Guid.CreateVersion7();
    public long UserId { get; set; }
    public Usuario Usuario { get; set; } = default!;
}
