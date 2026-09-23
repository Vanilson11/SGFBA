using Microsoft.EntityFrameworkCore;
using SGFBA.Domain.Entities;
using SGFBA.Domain.Repositories.Fichas;

namespace SGFBA.Infrastructure.DataAccess.Repositories;

internal class FichasRepository : IWriteOnlyFichasRepository, IReadOnlyFichasRepository, IUpdateOnlyFichasRepository
{
    private readonly SGFBADbContext _dbContext;

    public FichasRepository(SGFBADbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Adicionar(Ficha ficha) => await _dbContext.Fichas.AddAsync(ficha);

    public void Atualizar(Ficha ficha)
    {
        _dbContext.Fichas.Update(ficha);
    }

    async Task<Ficha?> IReadOnlyFichasRepository.BuscarPorId(long idUsuario, long idFicha)
    {
        return await _dbContext.Fichas.AsNoTracking()
            .FirstOrDefaultAsync(ficha => ficha.IdUsuario.Equals(idUsuario) && ficha.Id.Equals(idFicha));
    }

    async Task<Ficha?> IUpdateOnlyFichasRepository.BuscarPorId(long idUsuario, long idFicha)
    {
        return await _dbContext.Fichas
            .FirstOrDefaultAsync(ficha => ficha.IdUsuario.Equals(idUsuario) && ficha.Id.Equals(idFicha));
    }
}
