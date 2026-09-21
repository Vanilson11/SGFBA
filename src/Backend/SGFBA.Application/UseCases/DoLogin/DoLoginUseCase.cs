using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Repositories.Usuarios;
using SGFBA.Domain.Security.Criptography;
using SGFBA.Domain.Security.Tokens;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.DoLogin;

public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IReadOnlyUsuarioRepository _readOnlyUsuarioRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public DoLoginUseCase(
        IReadOnlyUsuarioRepository readOnlyUsuarioRepository, 
        IAccessTokenGenerator accessTokenGenerator,
        IPasswordHasher passwordHasher)
    {
        _readOnlyUsuarioRepository = readOnlyUsuarioRepository;
        _passwordHasher = passwordHasher;
        _accessTokenGenerator = accessTokenGenerator;
    }
    public async Task<ResponseDoLoginJson> Executar(RequestDoLoginJson request)
    {
        var usuario = await _readOnlyUsuarioRepository.BuscarPorEmail(request.Email);

        if (usuario is null) throw new InvalidLoginException(ResourceErrorMessages.LOGIN_INVALIDO);

        var senhaCorreta = _passwordHasher.VerifyPassword(request.Senha, usuario.Senha);

        if(senhaCorreta is false) throw new InvalidLoginException(ResourceErrorMessages.LOGIN_INVALIDO);

        return new ResponseDoLoginJson
        {
            Nome = usuario.Nome,
            Matricula = usuario.Matricula,
            Token = _accessTokenGenerator.Gerar(usuario)
        };
    }
}
