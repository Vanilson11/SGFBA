using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Acoes.BuscarTodas;

public interface IBuscarTodasAcoesUseCase
{
    Task<ResponseAcoesJson> Executar(long idFicha);
}
