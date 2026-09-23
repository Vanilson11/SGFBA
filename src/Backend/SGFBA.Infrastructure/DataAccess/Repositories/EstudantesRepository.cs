using Microsoft.EntityFrameworkCore;
using SGFBA.Domain.Entities;
using SGFBA.Domain.Repositories.Estudantes;

namespace SGFBA.Infrastructure.DataAccess.Repositories;

internal class EstudantesRepository : IWriteOnlyEstudantesRepository, IReadOnlyEstudantesRepository, IUpdateOnlyEstudantesRepository
{
    private readonly SGFBADbContext _dbContext;

    public EstudantesRepository(SGFBADbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Adicionar(Estudante estudante) => await _dbContext.Estudantes.AddAsync(estudante);

    async Task<Estudante?> IReadOnlyEstudantesRepository.BuscarPorId(long id)
    {
        return await _dbContext.Estudantes.AsNoTracking().IgnoreQueryFilters().FirstOrDefaultAsync(estudante => estudante.Id.Equals(id));
    }

    async Task<Estudante?> IUpdateOnlyEstudantesRepository.BuscarPorId(long id)
    {
        return await _dbContext.Estudantes.FirstOrDefaultAsync(estudante => estudante.Id.Equals(id));
    }

    public async Task<Estudante?> BuscarAtivoPorId(long id)
    {
        return await _dbContext.Estudantes.AsNoTracking().FirstOrDefaultAsync(estudante => estudante.Id.Equals(id));
    }

    public async Task<List<Estudante>> BuscarTodos()
    {
        return await _dbContext.Estudantes.AsNoTracking().IgnoreQueryFilters().ToListAsync();
    }

    public async Task<List<Estudante>> BuscarTodosAtivos()
    {
        return await _dbContext.Estudantes.AsNoTracking().ToListAsync();
    }

    public void Atualizar(Estudante estudante)
    {
        _dbContext.Estudantes.Update(estudante);
    }

    public async Task<bool> Desativar(long idEstudante)
    {
        var estudante = await _dbContext.Estudantes.FirstOrDefaultAsync(e => e.Id.Equals(idEstudante));

        if (estudante is null) return false;

        estudante.Ativo = false;

        return true;
    }
}
