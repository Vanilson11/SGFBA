using SGFBA.Communication.Enums;

namespace SGFBA.Communication.Requests;

public class RequestAtualizarUsuarioJson
{
    public string Nome { get; set; } = string.Empty;
    public string Matricula { get; set; } = string.Empty;
    public CargoUsuario Cargo { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public bool Ativo { get; set; }
}
