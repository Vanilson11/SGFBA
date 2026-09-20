using SGFBA.Domain.Entities;

namespace SGFBA.Domain.Repositories.Usuarios;

public interface IWriteOnlyUsuariosRepository
{
    Task Adicionar(Usuario usuario);
}
