using FluentValidation.Results;
using Mapster;
using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Entities;
using SGFBA.Domain.Repositories;
using SGFBA.Domain.Repositories.Usuarios;
using SGFBA.Domain.Security.Criptography;
using SGFBA.Domain.Security.Tokens;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;
using System.Text.RegularExpressions;

namespace SGFBA.Application.UseCases.Ususarios.Registrar;

public class RegistrarUsuarioUseCase : IRegistrarUsuarioUseCase
{
    private readonly IReadOnlyUsuarioRepository _readOnlyUsuarioRepository;
    private readonly IUpdateOnlyUsuariosRepository _updateOnlyUsuariosRepository;
    private readonly IWriteOnlyUsuariosRepository _writeOnlyUsuariosRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOffWork _unitOffWork;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public RegistrarUsuarioUseCase(
        IReadOnlyUsuarioRepository readOnlyUsuarioRepository,
        IUpdateOnlyUsuariosRepository updateOnlyUsuariosRepository,
        IWriteOnlyUsuariosRepository writeOnlyUsuariosRepository,
        IPasswordHasher passwordHasher,
        IUnitOffWork unitOffWork,
        IAccessTokenGenerator accessTokenGenerator)
    {
        _readOnlyUsuarioRepository = readOnlyUsuarioRepository;
        _updateOnlyUsuariosRepository = updateOnlyUsuariosRepository;
        _writeOnlyUsuariosRepository = writeOnlyUsuariosRepository;
        _passwordHasher = passwordHasher;
        _unitOffWork = unitOffWork;
        _accessTokenGenerator = accessTokenGenerator;
    }
    public async Task<ResponseRegistrarUsuarioJson> Executar(RequestRegistrarUsuarioJson request)
    {
        await Validar_Request(request);

        request.Email = Regex.Replace(request.Email, @"\s+", "");
        request.Senha = Regex.Replace(request.Senha, @"\s+", "");

        var usuario = request.Adapt<Usuario>();

        usuario.Senha = _passwordHasher.HashPassword(request.Senha);

        await _writeOnlyUsuariosRepository.Adicionar(usuario);

        await _unitOffWork.Commit();

        return new ResponseRegistrarUsuarioJson()
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Token = _accessTokenGenerator.Gerar(usuario)
        };
    }

    private async Task Validar_Request(RequestRegistrarUsuarioJson request)
    {
        var resultado = new UsuarioValidator().Validate(request);
        var usuarioComEmailExiste = await _updateOnlyUsuariosRepository.BuscarPorEmail(request.Email);

        if (usuarioComEmailExiste)
        {
            resultado.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.USUARIO_JA_REGISTRADO));
        }

        var usuarioComMatriculaExiste = await _readOnlyUsuarioRepository.BuscarPorMatricula(request.Matricula);
        if (usuarioComMatriculaExiste)
        {
            resultado.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.USUARIO_COM_MATRICULA_EXISTE));
        }

        if (resultado.IsValid is false)
        {
            var mensagensErro = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrosNaValidacaoException(mensagensErro);
        }
    }
}
