using SGFBA.Domain.Entities;

namespace SGFBA.Domain.Repositories.Fichas;

public interface IReadOnlyFichasRepository
{
    Task<Ficha?> BuscaPorId(long idUsuario, long idFicha);
}
