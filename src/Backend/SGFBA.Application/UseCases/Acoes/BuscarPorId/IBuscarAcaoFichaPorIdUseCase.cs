using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Acoes.BuscarPorId;

public interface IBuscarAcaoFichaPorIdUseCase
{
    Task<ResponseAcaoJson> Executar(long idAcao, long idFicha);
}
