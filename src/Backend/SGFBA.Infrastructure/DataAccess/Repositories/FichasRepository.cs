using SGFBA.Domain.Entities;
using SGFBA.Domain.Repositories.Fichas;

namespace SGFBA.Infrastructure.DataAccess.Repositories;

internal class FichasRepository : IWriteOnlyFichasRepository
{
    private readonly SGFBADbContext _dbContext;

    public FichasRepository(SGFBADbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Adicionar(Ficha ficha) => await _dbContext.Fichas.AddAsync(ficha);
}
