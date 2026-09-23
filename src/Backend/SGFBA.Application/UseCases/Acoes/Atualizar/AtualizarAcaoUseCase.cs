using SGFBA.Communication.Requests;
using SGFBA.Domain.Repositories;
using SGFBA.Domain.Repositories.Acoes;
using SGFBA.Domain.Repositories.Fichas;
using SGFBA.Domain.Services.LoggedUser;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Acoes.Atualizar;

public class AtualizarAcaoUseCase : IAtualizarAcaoUseCase
{
    private readonly IReadOnlyFichasRepository _readOnlyFichasRepository;
    private readonly IUpdateOnlyAcoesRepository _updateOnlyAcoesRepository;
    private readonly ILoggedUser _loggedUser;
    private readonly IUnitOffWork _unitOffWork;

    public AtualizarAcaoUseCase(
        IReadOnlyFichasRepository readOnlyFichasRepository,
        IUpdateOnlyAcoesRepository updateOnlyAcoesRepository,
        ILoggedUser loggedUser,
        IUnitOffWork unitOffWork
        )
    {
        _readOnlyFichasRepository = readOnlyFichasRepository;
        _updateOnlyAcoesRepository = updateOnlyAcoesRepository;
        _loggedUser = loggedUser;
        _unitOffWork = unitOffWork;
    }
    public async Task Executar(RequestAcaoJson request, long idAcao, long idFicha)
    {
        Validar_Request(request);

        var usuarioLogado = await _loggedUser.Get();

        var ficha = await _readOnlyFichasRepository.BuscarPorId(usuarioLogado.Id, idFicha);

        if (ficha is null) throw new NotFoundException(ResourceErrorMessages.FICHA_NAO_ENCONTRADA);

        var acao = await _updateOnlyAcoesRepository.BuscarPorId(idAcao, ficha.Id);

        if (acao is null) throw new NotFoundException(ResourceErrorMessages.ACAO_NAO_ENCONTRADA);

        acao.Tipo = (Domain.Enums.TipoAcao)request.Tipo;
        acao.Data = request.Data;
        acao.Observacao = request.Observacao;

        _updateOnlyAcoesRepository.Atualizar(acao);

        await _unitOffWork.Commit();
    }

    private void Validar_Request(RequestAcaoJson request)
    {
        var resultado = new AcaoValidator().Validate(request);

        if(resultado.IsValid is false)
        {
            var mensagensErro = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrosNaValidacaoException(mensagensErro);
        }
    }
}
