using SGFBA.Communication.Requests;

namespace SGFBA.Application.UseCases.Acoes.Atualizar;

public interface IAtualizarAcaoUseCase
{
    Task Executar(RequestAcaoJson request, long idFicha, long idAcao);
}
