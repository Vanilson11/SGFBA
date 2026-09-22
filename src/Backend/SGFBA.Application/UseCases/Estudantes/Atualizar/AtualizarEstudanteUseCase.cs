using SGFBA.Communication.Requests;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Estudantes.Atualizar;

public class AtualizarEstudanteUseCase : IAtualizarEstudanteUseCase
{
    public async Task Executar(RequestEstudanteJson request, long idEstudante)
    {
        Validar_Request(request);
    }

    private void Validar_Request(RequestEstudanteJson request)
    {
        var resultado = new EstudanteValidator().Validate(request);

        if(resultado.IsValid is false)
        {
            var mensagensErro = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrosNaValidacaoException(mensagensErro);
        }
    }
}
