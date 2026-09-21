using SGFBA.Domain.Entities;

namespace SGFBA.Domain.Repositories.Usuarios;

public interface IReadOnlyUsuarioRepository
{
    Task<Usuario?> BuscarPorEmail(string email);
    Task<bool> BuscarPorMatricula(string matricula);
}
