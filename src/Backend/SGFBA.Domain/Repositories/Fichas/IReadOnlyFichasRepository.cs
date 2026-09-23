using SGFBA.Domain.Entities;

namespace SGFBA.Domain.Repositories.Fichas;

public interface IReadOnlyFichasRepository
{
    Task<List<Ficha>> BuscarTodas();
    Task<List<Ficha>> BuscarTodasAtivas(long idUsuario);
    Task<Ficha?> BuscarPorId(long idUsuario, long idFicha);
}
