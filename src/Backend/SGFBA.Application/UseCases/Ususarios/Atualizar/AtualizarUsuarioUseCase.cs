using FluentValidation.Results;
using SGFBA.Communication.Requests;
using SGFBA.Domain.Entities;
using SGFBA.Domain.Repositories;
using SGFBA.Domain.Repositories.Usuarios;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Ususarios.Atualizar;

public class AtualizarUsuarioUseCase : IAtualizarUsuarioUseCase
{
    private readonly IReadOnlyUsuarioRepository _readOnlyUsuarioRepository;
    private readonly IUpdateOnlyUsuariosRepository _updateOnlyUsuariosRepository;
    private readonly IUnitOffWork _unitOffWork;

    public AtualizarUsuarioUseCase(
        IReadOnlyUsuarioRepository readOnlyUsuarioRepository,
        IUpdateOnlyUsuariosRepository updateOnlyUsuariosRepository,
        IUnitOffWork unitOffWork
        )
    {
        _readOnlyUsuarioRepository = readOnlyUsuarioRepository;
        _updateOnlyUsuariosRepository = updateOnlyUsuariosRepository;
        _unitOffWork = unitOffWork;
    }
    public async Task Executar(RequestAtualizarUsuarioJson request, long idUsuario)
    {
        var usuario = await _readOnlyUsuarioRepository.BuscarPorId(idUsuario);

        if (usuario is null) throw new NotFoundException(ResourceErrorMessages.USUARIO_NAO_ENCONTRADO);

        await Validar_Request(request, usuario);

        usuario.Nome = request.Nome;
        usuario.Matricula = request.Matricula;
        usuario.Cargo = (Domain.Enums.CargoUsuario)request.Cargo;
        usuario.Email = request.Email;
        usuario.Role = request.Role;
        usuario.Ativo = request.Ativo;

        _updateOnlyUsuariosRepository.Atualizar(usuario);

        await _unitOffWork.Commit();
    }

    private async Task Validar_Request(RequestAtualizarUsuarioJson request, Usuario usuario)
    {
        var resultado = new AtualizarUsuarioValidator().Validate(request);

        if(request.Matricula.Equals(usuario.Matricula) is false)
        {
            var usuarioComMatriculaExiste = await _readOnlyUsuarioRepository.BuscarPorMatricula(request.Matricula);

            if (usuarioComMatriculaExiste)
            {
                resultado.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.USUARIO_COM_MATRICULA_EXISTE));
            }
        }

        if(request.Email.Equals(usuario.Email) is false)
        {
            var usuarioComEmailExiste = await _updateOnlyUsuariosRepository.BuscarPorEmail(request.Email);

            if(usuarioComEmailExiste)
            {
                resultado.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.USUARIO_JA_REGISTRADO));
            }
        }

        if(resultado.IsValid is false)
        {
            var mensagensErro = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrosNaValidacaoException(mensagensErro);
        }
    }
}
