using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Estudantes.Registrar;

public class RegistrarEstudanteUseCase : IRegistrarEstudanteUseCase
{
    public async Task<ResponseRegistrarEstudanteJson> Executar(RequestRegistrarEstudanteJson request)
    {
        Validate_Request(request);

        return new ResponseRegistrarEstudanteJson
        {
            Id = 1,
            Nome = request.Nome,
            Turma = Communication.Enums.Turma.EF_02_A,
            NomeResponsavel = request.NomeResponsavel
        };
    }

    private void Validate_Request(RequestRegistrarEstudanteJson request)
    {
        var resultado = new EstudanteValidator().Validate(request);

        if(resultado.IsValid is false)
        {
            var mensagensErro = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrosNaValidacaoException(mensagensErro);
        }
    }
}
