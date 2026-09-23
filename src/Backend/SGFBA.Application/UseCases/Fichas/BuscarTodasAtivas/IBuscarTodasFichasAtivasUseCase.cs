using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Fichas.BuscarTodasAtivas;

public interface IBuscarTodasFichasAtivasUseCase
{
    Task<ResponseFichasJson> Executar();
}
