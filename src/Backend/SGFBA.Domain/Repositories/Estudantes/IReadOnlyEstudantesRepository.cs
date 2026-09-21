using SGFBA.Domain.Entities;

namespace SGFBA.Domain.Repositories.Estudantes;

public interface IReadOnlyEstudantesRepository
{
    Task<Estudante?> BuscarPorId(long id);
}
