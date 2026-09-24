using Mapster;
using SGFBA.Communication.Entities;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Entities;
using SGFBA.Domain.Repositories.Fichas;
using SGFBA.Domain.Services.LoggedUser;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Fichas.BuscarAtivaPorId;

public class BuscarFichaAtivaPorIdUseCase : IBuscarFichaAtivaPorIdUseCase
{
    private readonly IReadOnlyFichasRepository _readOnlyFichasRepository;
    private readonly ILoggedUser _loggedUser;

    public BuscarFichaAtivaPorIdUseCase(
        IReadOnlyFichasRepository readOnlyFichasRepository,
        ILoggedUser loggedUser
        )
    {
        _readOnlyFichasRepository = readOnlyFichasRepository;
        _loggedUser = loggedUser;
    }
    public async Task<ResponseFichaJson> Executar(long idFicha)
    {
        var usuarioLogado = await _loggedUser.Get();

        var ficha = await _readOnlyFichasRepository.BuscarPorId(usuarioLogado.Id, idFicha);

        if (ficha is null) throw new NotFoundException(ResourceErrorMessages.FICHA_NAO_ENCONTRADA);

        return new ResponseFichaJson
        {
            Id = ficha.Id,
            DataAbertura = ficha.DataAbertura,
            Motivo = (Communication.Enums.Motivo)ficha.Motivo,
            Status = (Communication.Enums.StatusFicha)ficha.Status,
            Observacao = ficha.Observacao,
            Acoes = ficha.Acoes.Adapt<IList<Communication.Entities.Acao>>()
        };
    }
}
