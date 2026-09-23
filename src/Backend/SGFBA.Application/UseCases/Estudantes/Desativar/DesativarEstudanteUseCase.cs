using SGFBA.Domain.Repositories;
using SGFBA.Domain.Repositories.Estudantes;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Estudantes.Desativar;

public class DesativarEstudanteUseCase : IDesativarEstudanteUseCase
{
    private readonly IWriteOnlyEstudantesRepository _writeOnlyEstudantesRepository;
    private readonly IUnitOffWork _unitOffWork;

    public DesativarEstudanteUseCase(
        IWriteOnlyEstudantesRepository writeOnlyEstudantesRepository,
        IUnitOffWork unitOffWork
        )
    {
        _writeOnlyEstudantesRepository = writeOnlyEstudantesRepository;
        _unitOffWork = unitOffWork;
    }
    public async Task Executar(long idEstudante)
    {
        var resultado = await _writeOnlyEstudantesRepository.Desativar(idEstudante);

        if (resultado is false) throw new NotFoundException(ResourceErrorMessages.ESTUDANTE_NAO_ENCONTRADO);

        await _unitOffWork.Commit();
    }
}
