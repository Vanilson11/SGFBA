using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Acoes.Registrar;

public class RegistrarAcaoUseCase : IRegistrarAcaoUseCase
{
    public async Task<ResponseRegistrarAcaoJson> Executar(RequestRegistrarAcaoJson request)
    {
        Validar_Request(request);

        return new ResponseRegistrarAcaoJson
        {
            Id = 1,
            Data = request.Data,
            Tipo = request.Tipo
        };
    }

    private void Validar_Request(RequestRegistrarAcaoJson request)
    {
        var resultado = new AcaoValidator().Validate(request);

        if(resultado.IsValid is false)
        {
            var mensagensErro = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrosNaValidacaoException(mensagensErro);
        }
    }
}
