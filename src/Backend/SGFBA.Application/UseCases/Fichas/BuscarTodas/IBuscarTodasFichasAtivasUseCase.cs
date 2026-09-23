using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Fichas.BuscarTodas;

public interface IBuscarTodasFichasAtivasUseCase
{
    Task<ResponseFichasAtivasJson> Executar();
}
