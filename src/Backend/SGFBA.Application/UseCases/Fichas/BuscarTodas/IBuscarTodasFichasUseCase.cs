using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Fichas.BuscarTodas;

public interface IBuscarTodasFichasUseCase
{
    Task<ResponseFichasJson> Executar();
}
