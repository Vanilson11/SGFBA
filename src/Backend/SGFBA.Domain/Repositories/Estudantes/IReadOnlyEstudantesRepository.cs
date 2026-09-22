using SGFBA.Domain.Entities;

namespace SGFBA.Domain.Repositories.Estudantes;

public interface IReadOnlyEstudantesRepository
{
    Task<List<Estudante>> BuscarTodos();
    Task<List<Estudante>> BuscarTodosAtivos();
    Task<Estudante?> BuscarPorId(long id);
}
