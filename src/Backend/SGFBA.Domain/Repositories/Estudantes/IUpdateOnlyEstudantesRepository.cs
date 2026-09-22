using SGFBA.Domain.Entities;

namespace SGFBA.Domain.Repositories.Estudantes;

public interface IUpdateOnlyEstudantesRepository
{
    Task<Estudante?> BuscarPorId(long id);

    void Atualizar(Estudante estudante);
}
