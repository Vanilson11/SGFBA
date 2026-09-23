using SGFBA.Communication.Requests;

namespace SGFBA.Application.UseCases.Fichas.Atualizar;

public interface IAtualizarFichaUseCase
{
    Task Executar(RequestFichaJson request, long idFicha);
}
