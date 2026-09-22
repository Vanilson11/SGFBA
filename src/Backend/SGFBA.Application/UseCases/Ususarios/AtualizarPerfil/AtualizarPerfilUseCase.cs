using FluentValidation.Results;
using Mapster;
using SGFBA.Communication.Requests;
using SGFBA.Domain.Entities;
using SGFBA.Domain.Repositories;
using SGFBA.Domain.Repositories.Usuarios;
using SGFBA.Domain.Services.LoggedUser;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Ususarios.AtualizarPerfil;

public class AtualizarPerfilUseCase : IAtualizarPerfilUseCase
{
    private readonly IReadOnlyUsuarioRepository _readOnlyUsuarioRepository;
    private readonly IUpdateOnlyUsuariosRepository _updateOnlyUsuariosRepository;
    private readonly ILoggedUser _loggedUser;
    private readonly IUnitOffWork _unitOffWork;

    public AtualizarPerfilUseCase(
        IReadOnlyUsuarioRepository readOnlyUsuarioRepository,
        IUpdateOnlyUsuariosRepository updateOnlyUsuariosRepository,
        ILoggedUser loggedUser,
        IUnitOffWork unitOffWork)
    {
        _readOnlyUsuarioRepository = readOnlyUsuarioRepository;
        _updateOnlyUsuariosRepository = updateOnlyUsuariosRepository;
        _loggedUser = loggedUser;
        _unitOffWork = unitOffWork;
    }
    public async Task Executar(RequestAtualizarPerfilJson request)
    {
        var usuario = await _loggedUser.Get();
        
        await Validar_Requisição(request, usuario);

        usuario.Nome = request.Nome;
        usuario.Matricula = request.Matricula;
        usuario.Cargo = (Domain.Enums.CargoUsuario)request.Cargo;
        usuario.Email = request.Email;

        _updateOnlyUsuariosRepository.Atualizar(usuario);

        await _unitOffWork.Commit();
    }

    private async Task Validar_Requisição(RequestAtualizarPerfilJson request, Usuario usuario)
    {
        var resultado = new AtualizarPerfilValidator().Validate(request);

        if(request.Email.Equals(usuario.Email) is false)
        {
            var usuarioComEmailExiste = await _updateOnlyUsuariosRepository.BuscarPorEmail(request.Email);

            if(usuarioComEmailExiste)
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
