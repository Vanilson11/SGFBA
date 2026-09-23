using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Fichas.BuscarPorId;

public interface IBuscarPorIdUseCase
{
    Task<ResponseFichaJson> Executar(long idUsuario, long idFicha);
}
