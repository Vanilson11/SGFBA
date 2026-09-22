using Mapster;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Repositories.Estudantes;

namespace SGFBA.Application.UseCases.Estudantes.BuscarTodos;

public class BuscarTodosEstudantesUseCase : IBuscarTodosEstudantesUseCase
{
    private readonly IReadOnlyEstudantesRepository _readOnlyEstudantesRepository;

    public BuscarTodosEstudantesUseCase(IReadOnlyEstudantesRepository readOnlyEstudantesRepository)
    {
        _readOnlyEstudantesRepository = readOnlyEstudantesRepository;
    }
    public async Task<ResponseEstudantesJson> Executar()
    {
        var estudantes = await _readOnlyEstudantesRepository.BuscarTodos();

        return new ResponseEstudantesJson
        {
            Estudantes = estudantes.Adapt<List<ResponseShortEstudanteJson>>()
        };
    }
}
