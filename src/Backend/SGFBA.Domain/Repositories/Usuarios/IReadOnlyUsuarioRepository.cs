namespace SGFBA.Domain.Repositories.Usuarios;

public interface IReadOnlyUsuarioRepository
{
    Task<bool> BuscarPorEmail(string email);
    Task<bool> BuscarPorMatricula(string matricula);
}
