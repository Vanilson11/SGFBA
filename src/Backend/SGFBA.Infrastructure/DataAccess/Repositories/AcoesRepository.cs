using Microsoft.EntityFrameworkCore;
using SGFBA.Domain.Entities;
using SGFBA.Domain.Repositories.Acoes;

namespace SGFBA.Infrastructure.DataAccess.Repositories;

internal class AcoesRepository : IWriteOnlyAcoesRepository, IUpdateOnlyAcoesRepository, IReadOnlyAcoesRepository
{
    private readonly SGFBADbContext _dbContext;

    public AcoesRepository(SGFBADbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Adicionar(Acao acao) => await _dbContext.Acoes.AddAsync(acao);

    public async Task<Acao?> BuscarPorId(long idAcao, long idFicha)
    {
        return await _dbContext.Acoes.FirstOrDefaultAsync(acao => acao.Id.Equals(idAcao) && acao.IdFicha.Equals(idFicha));
    }

    public void Atualizar(Acao acao)
    {
        _dbContext.Acoes.Update(acao);
    }

    public async Task<List<Acao>> BuscarTodas(long idFicha)
    {
        return await _dbContext.Acoes.AsNoTracking().Where(acao => acao.IdFicha.Equals(idFicha)).ToListAsync();
    }
}
