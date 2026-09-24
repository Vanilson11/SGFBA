using Mapster;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Repositories.Acoes;
using SGFBA.Domain.Repositories.Fichas;
using SGFBA.Domain.Services.LoggedUser;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Acoes.BuscarTodas;

public class BuscarTodasAcoesUseCase : IBuscarTodasAcoesUseCase
{
    private readonly IReadOnlyFichasRepository _readOnlyFichasRepository;
    private readonly IReadOnlyAcoesRepository _readOnlyAcoesRepository;
    private readonly ILoggedUser _loggedUser;

    public BuscarTodasAcoesUseCase(
        IReadOnlyFichasRepository readOnlyFichasRepository,
        IReadOnlyAcoesRepository readOnlyAcoesRepository,
        ILoggedUser loggedUser
        )
    {
        _readOnlyFichasRepository = readOnlyFichasRepository;
        _readOnlyAcoesRepository = readOnlyAcoesRepository;
        _loggedUser = loggedUser;
    }
    public async Task<ResponseAcoesJson> Executar(long idFicha)
    {
        var usuarioLogado = await _loggedUser.Get();

        var ficha = await _readOnlyFichasRepository.BuscarPorId(usuarioLogado.Id, idFicha);

        if (ficha is null) throw new NotFoundException(ResourceErrorMessages.FICHA_NAO_ENCONTRADA);

        var acoes = await _readOnlyAcoesRepository.BuscarTodas(ficha.Id);

        return new ResponseAcoesJson
        {
            Acoes = acoes.Adapt<List<ResponseShortAcaoJson>>()
        };
    }
}
