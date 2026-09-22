using FluentValidation.Results;
using SGFBA.Communication.Requests;
using SGFBA.Domain.Entities;
using SGFBA.Domain.Repositories.Usuarios;
using SGFBA.Domain.Services.LoggedUser;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Ususarios.AtualizarPerfil;

public class AtualizarPerfilUseCase : IAtualizarPerfilUseCase
{
    private readonly IReadOnlyUsuarioRepository _readOnlyUsuarioRepository;
    private readonly ILoggedUser _loggedUser;

    public AtualizarPerfilUseCase(
        IReadOnlyUsuarioRepository readOnlyUsuarioRepository,
        ILoggedUser loggedUser)
    {
        _readOnlyUsuarioRepository = readOnlyUsuarioRepository;
        _loggedUser = loggedUser;
    }
    public async Task Executar(RequestAtualizarPerfilJson request)
    {
        var usuario = await _loggedUser.Get();
        
        await Validar_Requisição(request, usuario);
    }

    private async Task Validar_Requisição(RequestAtualizarPerfilJson request, Usuario usuario)
    {
        var resultado = new AtualizarPerfilValidator().Validate(request);

        if(request.Email.Equals(usuario.Email) is false)
        {
            var usuarioComEmailExiste = await _readOnlyUsuarioRepository.BuscarPorEmail(request.Email);

            if(usuarioComEmailExiste is not null)
            {
                resultado.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.USUARIO_JA_REGISTRADO));
            }
        }

        if (request.Matricula.Equals(usuario.Matricula) is false)
        {
            var usuarioComMatriculaExiste = await _readOnlyUsuarioRepository.BuscarPorMatricula(request.Matricula);

            if (usuarioComMatriculaExiste)
            {
                resultado.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.USUARIO_COM_MATRICULA_EXISTE));
            }
        }

        if(resultado.IsValid is false)
        {
            var mensagensErro = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrosNaValidacaoException(mensagensErro);
        }
    }
}
