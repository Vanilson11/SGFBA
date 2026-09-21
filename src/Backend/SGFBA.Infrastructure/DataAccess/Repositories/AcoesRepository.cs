using SGFBA.Domain.Entities;
using SGFBA.Domain.Repositories.Acoes;

namespace SGFBA.Infrastructure.DataAccess.Repositories;

internal class AcoesRepository : IWriteOnlyAcoesRepository
{
    private readonly SGFBADbContext _dbContext;

    public AcoesRepository(SGFBADbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Adicionar(Acao acao) => await _dbContext.Acoes.AddAsync(acao);
}
