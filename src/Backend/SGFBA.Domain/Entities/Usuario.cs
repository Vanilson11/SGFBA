using SGFBA.Domain.Enums;

namespace SGFBA.Domain.Entities;

public class Usuario
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Matricula { get; set; } = string.Empty;
    public CargoUsuario Cargo { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string Role { get; set; } = Roles.MEMBRO;
    public bool Ativo { get; set; } = true;
    public Guid UserIdentifier { get; set; } = Guid.CreateVersion7();
    public ICollection<Ficha> Fichas { get; set; } = [];
}
