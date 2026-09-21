using Microsoft.EntityFrameworkCore;
using SGFBA.Domain.Entities;
using SGFBA.Domain.Repositories.Fichas;

namespace SGFBA.Infrastructure.DataAccess.Repositories;

internal class FichasRepository : IWriteOnlyFichasRepository, IReadOnlyFichasRepository
{
    private readonly SGFBADbContext _dbContext;

    public FichasRepository(SGFBADbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Adicionar(Ficha ficha) => await _dbContext.Fichas.AddAsync(ficha);

    public async Task<Ficha?> BuscaPorId(long idUsuario, long idFicha)
    {
        return await _dbContext.Fichas.AsNoTracking()
            .FirstOrDefaultAsync(ficha => ficha.IdOrientador.Equals(idUsuario) && ficha.Id.Equals(idFicha));
    }
}
