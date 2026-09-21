using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.DoLogin;

public interface IDoLoginUseCase
{
    Task<ResponseDoLoginJson> Executar(RequestDoLoginJson request);
}
