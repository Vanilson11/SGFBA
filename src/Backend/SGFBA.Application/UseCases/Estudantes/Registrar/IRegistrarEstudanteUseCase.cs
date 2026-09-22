using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Estudantes.Registrar;

public interface IRegistrarEstudanteUseCase
{
    Task<ResponseRegistrarEstudanteJson> Executar(RequestEstudanteJson request);
}
