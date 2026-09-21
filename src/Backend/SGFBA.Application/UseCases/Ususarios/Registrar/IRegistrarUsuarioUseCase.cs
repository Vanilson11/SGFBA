using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Ususarios.Registrar;

public interface IRegistrarUsuarioUseCase
{
    Task<ResponseRegistrarUsuarioJson> Executar(RequestRegistrarUsuarioJson request);
}
