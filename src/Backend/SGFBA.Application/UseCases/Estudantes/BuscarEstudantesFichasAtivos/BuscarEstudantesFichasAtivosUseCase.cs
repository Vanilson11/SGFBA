using Mapster;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Repositories.Estudantes;

namespace SGFBA.Application.UseCases.Estudantes.BuscarEstudantesFichasAtivos;

public class BuscarEstudantesFichasAtivosUseCase : IBuscarEstudantesFichasAtivosUseCase
{
    private readonly IReadOnlyEstudantesRepository _readOnlyEstudantesRepository;

    public BuscarEstudantesFichasAtivosUseCase(IReadOnlyEstudantesRepository readOnlyEstudantesRepository)
    {
        _readOnlyEstudantesRepository = readOnlyEstudantesRepository;   
    }
    public async Task<ResponseEstudantesFichasJson> Executar()
    {
        var estudantes = await _readOnlyEstudantesRepository.BuscarEstudantesFichasAtivos();

        return new ResponseEstudantesFichasJson
        {
            Estudantes = (List<ResponseShortEstudantesFichasJson>)estudantes.Adapt<IList<ResponseShortEstudantesFichasJson>>()
        };
    }
}
