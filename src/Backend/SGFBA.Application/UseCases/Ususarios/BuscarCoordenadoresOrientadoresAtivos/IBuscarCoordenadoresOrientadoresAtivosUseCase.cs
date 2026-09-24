using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Ususarios.BuscarCoordenadoresOrientadoresAtivos;

public interface IBuscarCoordenadoresOrientadoresAtivosUseCase
{
    Task<ResponseCoordenadoresOrientadoresAtivosJson> Executar();
}
