using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Acoes.Registrar;

public interface IRegistrarAcaoUseCase
{
    Task<ResponseRegistrarAcaoJson> Executar(RequestRegistrarAcaoJson request);
}
