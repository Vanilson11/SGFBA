using SGFBA.Communication.Requests;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Ususarios.AlterarSenha;

public class AlterarSenhaUsuarioUseCase : IAlterarSenhaUsuarioUseCase
{
    public async Task Executar(RequestAlterarSenhaJson request)
    {
        Validar_Request(request);
    }

    private void Validar_Request(RequestAlterarSenhaJson request)
    {
        var resultado = new AlterarSenhaValidator().Validate(request);

        if(resultado.IsValid is false)
        {
            var mensagensErro = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrosNaValidacaoException(mensagensErro);
        }
    }
}
