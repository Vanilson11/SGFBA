using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;

namespace SGFBA.Application.Ususarios.Registrar;

public interface IRegistrarUsuarioUseCase
{
    Task<ResponseRegistrarUsuarioJson> Executar(RequestRegistrarUsuarioJson request);
}
