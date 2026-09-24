using SGFBA.Domain.Entities;

namespace SGFBA.Domain.Repositories.Usuarios;

public interface IReadOnlyUsuarioRepository
{
    Task<List<Usuario>> BuscarTodos();
    Task<List<Usuario>> BuscarTodosAtivos();
    Task<List<Usuario>> BuscarCoordenadoresOrientadoresAtivos();
    Task<Usuario?> BuscarCoordenadorOrientadorAtivoPorId(long id);
    Task<List<Usuario>> BuscarCoordenadoresOrientadores();
    Task<Usuario?> BuscarPorId(long id);
    Task<Usuario?> BuscarPorEmail(string email);
    Task<bool> BuscarPorMatricula(string matricula);
}
