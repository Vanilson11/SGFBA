using SGFBA.Domain.Entities;

namespace SGFBA.Domain.Repositories.Usuarios;

public interface IUpdateOnlyUsuariosRepository
{
    Task<Usuario?> BuscarPorId(long id);
    Task<bool> BuscarPorEmail(string email);
    void Atualizar(Usuario usuario);
}
