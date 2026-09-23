using SGFBA.Domain.Entities;

namespace SGFBA.Domain.Repositories.Estudantes;

public interface IWriteOnlyEstudantesRepository
{
    Task Adicionar(Estudante estudante);

    /// <summary>
    /// This method return true if delete was successfull. Return false when student is not found and the delete not successfull
    /// </summary>
    /// <param name="idEstudante"></param>
    /// <returns></returns>
    Task<bool> Desativar(long idEstudante);
}
