using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Ususarios.BuscarCoordenadorOrientadorPorId;

public interface IBuscarCoordenadorOrientadorPorIdUseCase
{
    Task<ResponseCoordenadorOrientadorJson> Executar(long id);
}
