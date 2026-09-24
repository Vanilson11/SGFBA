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

    public async Task<List<Ficha>> BuscarTodas()
    {
        return await _dbContext.Fichas.AsNoTracking().IgnoreQueryFilters().ToListAsync();
    }

    public async Task<List<Ficha>> BuscarTodasAtivas(long idUsuario)
    {
        return await _dbContext.Fichas.AsNoTracking().Where(ficha => ficha.IdUsuario.Equals(idUsuario)).ToListAsync();
    }

    async Task<Ficha?> IReadOnlyFichasRepository.BuscarAtivaPorId(long idUsuario, long idFicha)
    {
        return await _dbContext.Fichas.AsNoTracking()
            .Include(ficha => ficha.Acoes)
            .FirstOrDefaultAsync(ficha => ficha.IdUsuario.Equals(idUsuario) && ficha.Id.Equals(idFicha));
    }

    async Task<Ficha?> IReadOnlyFichasRepository.BuscarPorId(long idUsuario, long idFicha)
    {
        return await _dbContext.Fichas.AsNoTracking()
            .IgnoreQueryFilters()
            .Include(ficha => ficha.Acoes)
            .FirstOrDefaultAsync(ficha => ficha.IdUsuario.Equals(idUsuario) && ficha.Id.Equals(idFicha));
    }

    async Task<Ficha?> IUpdateOnlyFichasRepository.BuscarPorId(long idUsuario, long idFicha)
    {
        return await _dbContext.Fichas
            .FirstOrDefaultAsync(ficha => ficha.IdUsuario.Equals(idUsuario) && ficha.Id.Equals(idFicha));
    }
}
