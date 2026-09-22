using SGFBA.Domain.Entities;

namespace SGFBA.Domain.Repositories.Usuarios;

public interface IUpdateOnlyUsuariosRepository
{
    void Atualizar(Usuario usuario);
}
