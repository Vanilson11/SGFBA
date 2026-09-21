using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.DoLogin;

public class DoLoginUseCase : IDoLoginUseCase
{
    public Task<ResponseDoLoginJson> Executar(RequestDoLoginJson request)
    {
        throw new NotImplementedException();
    }
}
