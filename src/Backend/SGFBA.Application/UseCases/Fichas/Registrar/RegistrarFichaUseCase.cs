using Mapster;
using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Entities;
using SGFBA.Domain.Repositories;
using SGFBA.Domain.Repositories.Estudantes;
using SGFBA.Domain.Repositories.Fichas;
using SGFBA.Domain.Services.LoggedUser;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Fichas.Registrar;

public class RegistrarFichaUseCase : IRegistrarFichaUseCase
{
    private readonly IWriteOnlyFichasRepository _writeOnlyFichasRepository;
    private readonly IReadOnlyEstudantesRepository _readOnlyEstudantesRepository;
    private readonly ILoggedUser _loggedUser;
    private readonly IUnitOffWork _unitOffWork;

    public RegistrarFichaUseCase(
        IWriteOnlyFichasRepository writeOnlyFichasRepository,
        IReadOnlyEstudantesRepository readOnlyEstudantesRepository,
        ILoggedUser loggedUser,
        IUnitOffWork unitOffWork
        )
    {
        _writeOnlyFichasRepository = writeOnlyFichasRepository;
        _readOnlyEstudantesRepository = readOnlyEstudantesRepository;
        _loggedUser = loggedUser;
        _unitOffWork = unitOffWork;
    }
    public async Task<ResponseRegistrarFichaJson> Executar(RequestRegistrarFichaJson request, long id)
    {
        Validar_Request(request);

        var ficha = request.Adapt<Ficha>();
        var estudante = await _readOnlyEstudantesRepository.BuscarPorId(id);

        if (estudante is null) throw new NotFoundException(ResourceErrorMessages.ESTUDANTE_NAO_ENCONTRADO);

        ficha.IdEstudante = estudante.Id;

        var usuario = await _loggedUser.Get();

        ficha.IdOrientador = usuario.Id;

        await _writeOnlyFichasRepository.Adicionar(ficha);

        await _unitOffWork.Commit();

        return new ResponseRegistrarFichaJson
        {
            Id = ficha.Id,
            DataAbertura = ficha.DataAbertura,
            Status = (Communication.Enums.StatusFicha)ficha.Status
        };
    }

    private void Validar_Request(RequestRegistrarFichaJson request)
    {
        var resultado = new FichaValidator().Validate(request);

        if(resultado.IsValid is false)
        {
            var mensagensErro = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrosNaValidacaoException(mensagensErro);
        }
    }
}
