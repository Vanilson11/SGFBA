using SGFBA.Communication.Requests;

namespace SGFBA.Application.UseCases.Estudantes.Atualizar;

public interface IAtualizarEstudanteUseCase
{
    Task Executar(RequestAtualizarEstudanteJson request, long idEstudante);
}
