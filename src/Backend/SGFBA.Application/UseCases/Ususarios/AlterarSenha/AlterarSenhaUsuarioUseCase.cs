using FluentValidation.Results;
using SGFBA.Communication.Requests;
using SGFBA.Domain.Entities;
using SGFBA.Domain.Repositories;
using SGFBA.Domain.Repositories.Usuarios;
using SGFBA.Domain.Security.Criptography;
using SGFBA.Domain.Services.LoggedUser;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Ususarios.AlterarSenha;

public class AlterarSenhaUsuarioUseCase : IAlterarSenhaUsuarioUseCase
{
    private readonly IUpdateOnlyUsuariosRepository _updateOnlyUsuariosRepository;
    private readonly ILoggedUser _loggedUser;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOffWork _unitOffWork;

    public AlterarSenhaUsuarioUseCase(
        IUpdateOnlyUsuariosRepository updateOnlyUsuariosRepository,
        ILoggedUser loggedUser,
        IPasswordHasher passwordHasher,
        IUnitOffWork unitOffWork
        )
    {
        _updateOnlyUsuariosRepository = updateOnlyUsuariosRepository;
        _loggedUser = loggedUser;
        _passwordHasher = passwordHasher;
        _unitOffWork = unitOffWork;
    }
    public async Task Executar(RequestAlterarSenhaJson request)
    {
        var usuarioLogado = await _loggedUser.Get();

        Validar_Request(request, usuarioLogado);

        var usuario = await _updateOnlyUsuariosRepository.BuscarPorId(usuarioLogado.Id);

        if (usuario is null) throw new NotFoundException(ResourceErrorMessages.USUARIO_NAO_ENCONTRADO);

        usuario.Senha = _passwordHasher.HashPassword(request.NovaSenha);

        _updateOnlyUsuariosRepository.Atualizar(usuario);

        await _unitOffWork.Commit();
    }

    private void Validar_Request(RequestAlterarSenhaJson request, Usuario usuario)
    {
        var resultado = new AlterarSenhaValidator().Validate(request);

        var senhaConfere = _passwordHasher.VerifyPassword(request.SenhaAtual, usuario.Senha);

        if (senhaConfere is false)
        {
            resultado.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.SENHA_ATUAL_NAO_CONFERE));
        }

        if (resultado.IsValid is false)
        {
            var mensagensErro = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrosNaValidacaoException(mensagensErro);
        }
    }
}
