using SGFBA.Domain.Entities;

namespace SGFBA.Domain.Repositories.Acoes;

public interface IWriteOnlyAcoesRepository
{
    Task Adicionar(Acao acao);

    void Apagar(Acao acao);
}
