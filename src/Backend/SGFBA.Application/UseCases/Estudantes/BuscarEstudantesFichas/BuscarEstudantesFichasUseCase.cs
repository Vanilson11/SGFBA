using Mapster;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Repositories.Estudantes;

namespace SGFBA.Application.UseCases.Estudantes.BuscarEstudantesFichas;

public class BuscarEstudantesFichasUseCase : IBuscarEstudantesFichasUseCase
{
    private readonly IReadOnlyEstudantesRepository _readOnlyEstudantesRepository;

    public BuscarEstudantesFichasUseCase(IReadOnlyEstudantesRepository readOnlyEstudantesRepository)
    {
        _readOnlyEstudantesRepository = readOnlyEstudantesRepository;
    }
    public async Task<ResponseEstudantesFichasJson> Executar()
    {
        var estudantes = await _readOnlyEstudantesRepository.BuscarEstudantesFichas();

        return new ResponseEstudantesFichasJson
        {
            Estudantes = (List<ResponseShortEstudantesFichasJson>)estudantes.Adapt<IList<ResponseShortEstudantesFichasJson>>()
        };
    }
}
