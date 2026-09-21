using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Ususarios.BuscarPorId;

public interface IBuscarUsuarioPorIdUseCase
{
    Task<ResponseBuscarUsuarioJson> Executar(long id);
}
