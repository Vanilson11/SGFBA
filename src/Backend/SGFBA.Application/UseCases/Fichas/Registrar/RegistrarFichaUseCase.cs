using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Fichas.Registrar;

public class RegistrarFichaUseCase : IRegistrarFichaUseCase
{
    public async Task<ResponseRegistrarFichaJson> Executar(RequestRegistrarFichaJson request)
    {
        Validar_Request(request);

        return new ResponseRegistrarFichaJson
        {
            Id = 1,
            DataAbertura = request.DataAbertura,
            Status = request.Status
        };
    }

    private void Validar_Request(RequestRegistrarFichaJson request)
    {
        var resultado = new FichaValidator().Validate(request);

        if(resultado.IsValid is false)
        {
            var mensagensErro = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrosNaValidacaoException(mensagensErro);
        }
    }
}
