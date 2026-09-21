using Microsoft.EntityFrameworkCore;
using SGFBA.Domain.Entities;
using SGFBA.Domain.Repositories.Estudantes;

namespace SGFBA.Infrastructure.DataAccess.Repositories;

internal class EstudantesRepository : IWriteOnlyEstudantesRepository, IReadOnlyEstudantesRepository
{
    private readonly SGFBADbContext _dbContext;

    public EstudantesRepository(SGFBADbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Adicionar(Estudante estudante) => await _dbContext.Estudantes.AddAsync(estudante);

    public async Task<Estudante?> BuscarPorId(long id)
    {
        return await _dbContext.Estudantes.AsNoTracking().FirstOrDefaultAsync(estudante => estudante.Ativo && estudante.Id.Equals(id));
    }
}
