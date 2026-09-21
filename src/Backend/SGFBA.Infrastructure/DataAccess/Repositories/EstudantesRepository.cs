using SGFBA.Domain.Entities;
using SGFBA.Domain.Repositories.Estudantes;

namespace SGFBA.Infrastructure.DataAccess.Repositories;

internal class EstudantesRepository : IWriteOnlyEstudantesRepository
{
    private readonly SGFBADbContext _dbContext;

    public EstudantesRepository(SGFBADbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Adicionar(Estudante estudante) => await _dbContext.Estudantes.AddAsync(estudante);
}
