using Mapster;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Repositories.Fichas;

namespace SGFBA.Application.UseCases.Fichas.BuscarTodas;

public class BuscarTodasFichasUseCase : IBuscarTodasFichasUseCase
{
    private readonly IReadOnlyFichasRepository _readOnlyFichasRepository;

    public BuscarTodasFichasUseCase(IReadOnlyFichasRepository readOnlyFichasRepository)
    {
        _readOnlyFichasRepository = readOnlyFichasRepository;
    }
    public async Task<ResponseFichasJson> Executar()
    {
        var fichas = await _readOnlyFichasRepository.BuscarTodas();

        return new ResponseFichasJson
        {
            Fichas = fichas.Adapt<List<ResponseShortFichaJson>>()
        };
    }
}
