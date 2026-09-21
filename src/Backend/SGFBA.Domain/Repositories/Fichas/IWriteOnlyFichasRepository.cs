using SGFBA.Domain.Entities;

namespace SGFBA.Domain.Repositories.Fichas;

public interface IWriteOnlyFichasRepository
{
    Task Adicionar(Ficha ficha);
}
