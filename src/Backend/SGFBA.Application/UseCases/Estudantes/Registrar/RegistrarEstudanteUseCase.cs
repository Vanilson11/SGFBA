using Mapster;
using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Entities;
using SGFBA.Domain.Repositories;
using SGFBA.Domain.Repositories.Estudantes;
using SGFBA.Domain.Services.LoggedUser;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Estudantes.Registrar;

public class RegistrarEstudanteUseCase : IRegistrarEstudanteUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IWriteOnlyEstudantesRepository _writeOnlyEstudantesRepository;
    private readonly IUnitOffWork _unitOffWork;

    public RegistrarEstudanteUseCase(
        ILoggedUser loggedUser,
        IWriteOnlyEstudantesRepository writeOnlyEstudantesRepository,
        IUnitOffWork unitOffWork
        )
    {
        _loggedUser = loggedUser;
        _writeOnlyEstudantesRepository = writeOnlyEstudantesRepository;
        _unitOffWork = unitOffWork;
    }
    public async Task<ResponseRegistrarEstudanteJson> Executar(RequestRegistrarEstudanteJson request)
    {
        Validate_Request(request);

        var estudante = request.Adapt<Estudante>();

        var usuario = await _loggedUser.Get();

        estudante.UserId = usuario.Id;

        await _writeOnlyEstudantesRepository.Adicionar(estudante);

        await _unitOffWork.Commit();

        return new ResponseRegistrarEstudanteJson
        {
            Id = estudante.Id,
            Nome = estudante.Nome,
            Turma = (Communication.Enums.Turma)estudante.Turma,
            NomeResponsavel = estudante.NomeResponsavel
        };
    }

    private void Validate_Request(RequestRegistrarEstudanteJson request)
    {
        var resultado = new EstudanteValidator().Validate(request);

        if(resultado.IsValid is false)
        {
            var mensagensErro = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrosNaValidacaoException(mensagensErro);
        }
    }
}
