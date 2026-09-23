using Mapster;
using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Entities;
using SGFBA.Domain.Repositories;
using SGFBA.Domain.Repositories.Acoes;
using SGFBA.Domain.Repositories.Fichas;
using SGFBA.Domain.Services.LoggedUser;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Acoes.Registrar;

public class RegistrarAcaoUseCase : IRegistrarAcaoUseCase
{
    private readonly IReadOnlyFichasRepository _readOnlyFichasRepository;
    private readonly IWriteOnlyAcoesRepository _writeOnlyAcoesRepository;
    private readonly ILoggedUser _loggedUser;
    private readonly IUnitOffWork _unitOffWork;

    public RegistrarAcaoUseCase(
        IReadOnlyFichasRepository readOnlyFichasRepository,
        IWriteOnlyAcoesRepository writeOnlyAcoesRepository,
        ILoggedUser loggedUser,
        IUnitOffWork unitOffWork
        )
    {
        _readOnlyFichasRepository = readOnlyFichasRepository;
        _writeOnlyAcoesRepository = writeOnlyAcoesRepository;
        _loggedUser = loggedUser;
        _unitOffWork = unitOffWork;
    }
    public async Task<ResponseRegistrarAcaoJson> Executar(RequestRegistrarAcaoJson request, long idFicha)
    {
        Validar_Request(request);

        var acao = request.Adapt<Acao>();

        var usuario = await _loggedUser.Get();

        var ficha = await _readOnlyFichasRepository.BuscarPorId(usuario.Id, idFicha);

        if (ficha is null) throw new NotFoundException(ResourceErrorMessages.FICHA_NAO_ENCONTRADA);

        acao.IdFicha = ficha.Id;

        await _writeOnlyAcoesRepository.Adicionar(acao);

        await _unitOffWork.Commit();

        return new ResponseRegistrarAcaoJson
        {
            Id = acao.Id,
            Data = acao.Data,
            Tipo = (Communication.Enums.TipoAcao)acao.Tipo
        };
    }

    private void Validar_Request(RequestRegistrarAcaoJson request)
    {
        var resultado = new AcaoValidator().Validate(request);

        if(resultado.IsValid is false)
        {
            var mensagensErro = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrosNaValidacaoException(mensagensErro);
        }
    }
}
