using SGFBA.Domain.Entities;

namespace SGFBA.Domain.Repositories.Fichas;

public interface IUpdateOnlyFichasRepository
{
    Task<Ficha?> BuscarPorId(long idUsuario, long idFicha);
    void Atualizar(Ficha ficha);
}
