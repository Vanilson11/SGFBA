using SGFBA.Domain.Entities;

namespace SGFBA.Domain.Repositories.Acoes;

public interface IUpdateOnlyAcoesRepository
{
    Task<Acao?> BuscarPorId(long idAcao, long idFicha);
    void Atualizar(Acao acao);
}
