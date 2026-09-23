using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Fichas.BuscarAtivaPorId;

public interface IBuscarFichaAtivaPorIdUseCase
{
    Task<ResponseFichaJson> Executar(long idFicha);
}
