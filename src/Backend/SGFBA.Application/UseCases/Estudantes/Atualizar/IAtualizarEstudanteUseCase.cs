using SGFBA.Communication.Requests;

namespace SGFBA.Application.UseCases.Estudantes.Atualizar;

public interface IAtualizarEstudanteUseCase
{
    Task Executar(RequestEstudanteJson request, long idEstudante);
}
