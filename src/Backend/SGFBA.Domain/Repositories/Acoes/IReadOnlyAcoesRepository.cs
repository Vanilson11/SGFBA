using SGFBA.Domain.Entities;

namespace SGFBA.Domain.Repositories.Acoes;

public interface IReadOnlyAcoesRepository
{
    Task<List<Acao>> BuscarTodas(long idFicha);
    Task<Acao?> BuscarPorId(long idAcao, long idFicha);
}
