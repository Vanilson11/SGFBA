using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Ususarios.BuscarCoordenadorOrientadorAtivoPorId;

public interface IBuscarCoordenadorOrientadorAtivoPorIdUseCase
{
    Task<ResponseCoordenadorOrientadorJson> Executar(long id);
}
