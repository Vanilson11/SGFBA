using Mapster;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Repositories.Estudantes;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Estudantes.BuscarPorId;

public class BuscarEstudantePorIdeUseCase : IBuscarEstudantePorIdeUseCase
{
    private readonly IReadOnlyEstudantesRepository _readOnlyEstudantesRepository;

    public BuscarEstudantePorIdeUseCase(IReadOnlyEstudantesRepository readOnlyEstudantesRepository)
    {
        _readOnlyEstudantesRepository = readOnlyEstudantesRepository;
    }
    public async Task<ResponseEstudanteJson> Executar(long idEstudante)
    {
        var estudante = await _readOnlyEstudantesRepository.BuscarPorId(idEstudante);

        if (estudante is null) throw new NotFoundException(ResourceErrorMessages.ESTUDANTE_NAO_ENCONTRADO);

        var response = estudante.Adapt<ResponseEstudanteJson>();

        return response;
    }
}
