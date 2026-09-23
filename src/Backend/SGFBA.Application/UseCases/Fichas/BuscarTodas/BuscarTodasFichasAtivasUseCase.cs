using Mapster;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Repositories.Fichas;
using SGFBA.Domain.Services.LoggedUser;

namespace SGFBA.Application.UseCases.Fichas.BuscarTodas;

public class BuscarTodasFichasAtivasUseCase : IBuscarTodasFichasAtivasUseCase
{
    private readonly IReadOnlyFichasRepository _readOnlyFichasRepository;
    private readonly ILoggedUser _loggedUser;

    public BuscarTodasFichasAtivasUseCase(
        IReadOnlyFichasRepository readOnlyFichasRepository,
        ILoggedUser loggedUser
        )
    {
        _readOnlyFichasRepository = readOnlyFichasRepository;
        _loggedUser = loggedUser;
    }
    public async Task<ResponseFichasAtivasJson> Executar()
    {
        var usuarioLogado = await _loggedUser.Get();

        var fichas = await _readOnlyFichasRepository.BuscarTodasAtivas(usuarioLogado.Id);

        return new ResponseFichasAtivasJson
        {
            Fichas = fichas.Adapt<List<ResponseShortFichaAtivaJson>>()
        };
    }
}
