using Mapster;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Repositories.Estudantes;

namespace SGFBA.Application.UseCases.Estudantes.BuscarTodosAtivos;

public class BuscarTodosEstudantesAtivosUseCase : IBuscarTodosEstudantesAtivosUseCase
{
    private readonly IReadOnlyEstudantesRepository _readOnlyEstudantesRepository;

    public BuscarTodosEstudantesAtivosUseCase(IReadOnlyEstudantesRepository readOnlyEstudantesRepository)
    {
        _readOnlyEstudantesRepository = readOnlyEstudantesRepository;
    }
    public async Task<ResponseEstudantesAtivosJson> Executar()
    {
        var estudantes = await _readOnlyEstudantesRepository.BuscarTodosAtivos();

        return new ResponseEstudantesAtivosJson
        {
            Estudantes = estudantes.Adapt<List<ResponseShortEstudanteAtivoJson>>()
        };
    }
}
