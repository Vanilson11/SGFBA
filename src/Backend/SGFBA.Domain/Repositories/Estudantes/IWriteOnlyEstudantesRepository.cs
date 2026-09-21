using SGFBA.Domain.Entities;

namespace SGFBA.Domain.Repositories.Estudantes;

public interface IWriteOnlyEstudantesRepository
{
    Task Adicionar(Estudante estudante);
}
