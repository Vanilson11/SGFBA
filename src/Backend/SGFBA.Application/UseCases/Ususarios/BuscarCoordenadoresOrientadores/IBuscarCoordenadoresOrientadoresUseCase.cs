using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Ususarios.BuscarCoordenadoresOrientadores;

public interface IBuscarCoordenadoresOrientadoresUseCase
{
    Task<ResponseCoordenadoresOrientadoresJson> Executar();
}
