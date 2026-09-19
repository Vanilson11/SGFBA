using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;
using SGFBA.Exception.ExceptionsBase;
using System.Text.RegularExpressions;

namespace SGFBA.Application.Ususarios.Registrar;

public class RegistrarUsuarioUseCase : IRegistrarUsuarioUseCase
{
    public async Task<ResponseRegistrarUsuarioJson> Executar(RequestRegistrarUsuarioJson request)
    {
        Validar_Request(request);

        request.Email = Regex.Replace(request.Email, @"\s+", "");
        request.Senha = Regex.Replace(request.Senha, @"\s+", "");

        return new ResponseRegistrarUsuarioJson()
        {
            Id = 1,
            Nome = request.Nome,
            Token = "TOKEN"
        };
    }

    private void Validar_Request(RequestRegistrarUsuarioJson request)
    {
        var resultado = new UsuarioValidator().Validate(request);

        if(resultado.IsValid is false)
        {
            var mensagensErro = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrosNaValidacaoException(mensagensErro);
        }
    }
}
