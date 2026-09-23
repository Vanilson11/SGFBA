using SGFBA.Communication.Requests;
using SGFBA.Domain.Repositories;
using SGFBA.Domain.Repositories.Fichas;
using SGFBA.Domain.Services.LoggedUser;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Fichas.Atualizar;

public class AtualizarFichaUseCase : IAtualizarFichaUseCase
{
    private readonly IUpdateOnlyFichasRepository _updateOnlyFichasRepository;
    private readonly ILoggedUser _loggedUser;
    private readonly IUnitOffWork _unitOffWork;

    public AtualizarFichaUseCase(
        IUpdateOnlyFichasRepository updateOnlyFichasRepository,
        ILoggedUser loggedUser,
        IUnitOffWork unitOffWork
        )
    {
        _updateOnlyFichasRepository = updateOnlyFichasRepository;
        _loggedUser = loggedUser;
        _unitOffWork = unitOffWork;
    }
    public async Task Executar(RequestFichaJson request, long idFicha)
    {
        Validar_Request(request);

        var usuarioLogado = await _loggedUser.Get();

        var ficha = await _updateOnlyFichasRepository.BuscarPorId(usuarioLogado.Id, idFicha);

        if (ficha is null) throw new NotFoundException(ResourceErrorMessages.FICHA_NAO_ENCONTRADA);

        ficha.DataAbertura = request.DataAbertura;
        ficha.Motivo = (Domain.Enums.Motivo)request.Motivo;
        ficha.Status = (Domain.Enums.StatusFicha)request.Status;
        ficha.Observacao = request.Observacao;

        _updateOnlyFichasRepository.Atualizar(ficha);

        await _unitOffWork.Commit();
    }

    private void Validar_Request(RequestFichaJson request)
    {
        var resultado = new FichaValidator().Validate(request);

        if(resultado.IsValid is false)
        {
            var mensagensErro = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrosNaValidacaoException(mensagensErro);
        }
    }
}
