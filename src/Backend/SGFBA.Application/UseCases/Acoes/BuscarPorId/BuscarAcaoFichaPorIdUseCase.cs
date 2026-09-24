using Mapster;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Repositories.Acoes;
using SGFBA.Domain.Repositories.Fichas;
using SGFBA.Domain.Services.LoggedUser;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Acoes.BuscarPorId;

public class BuscarAcaoFichaPorIdUseCase : IBuscarAcaoFichaPorIdUseCase
{
    private readonly IReadOnlyFichasRepository _readOnlyFichasRepository;
    private readonly IReadOnlyAcoesRepository _readOnlyAcoesRepository;
    private readonly ILoggedUser _loggedUser;

    public BuscarAcaoFichaPorIdUseCase(
        IReadOnlyFichasRepository readOnlyFichasRepository,
        IReadOnlyAcoesRepository readOnlyAcoesRepository,
        ILoggedUser loggedUser
        )
    {
        _readOnlyFichasRepository = readOnlyFichasRepository;
        _readOnlyAcoesRepository = readOnlyAcoesRepository;
        _loggedUser = loggedUser;
    }
    public async Task<ResponseAcaoJson> Executar(long idAcao, long idFicha)
    {
        var usuarioLogado = await _loggedUser.Get();

        var ficha = await _readOnlyFichasRepository.BuscarPorId(usuarioLogado.Id, idFicha);

        if (ficha is null) throw new NotFoundException(ResourceErrorMessages.FICHA_NAO_ENCONTRADA);

        var acao = await _readOnlyAcoesRepository.BuscarPorId(idAcao, ficha.Id);

        if(acao is null) throw new NotFoundException(ResourceErrorMessages.ACAO_NAO_ENCONTRADA);

        var response = acao.Adapt<ResponseAcaoJson>();

        return response;
    }
}
