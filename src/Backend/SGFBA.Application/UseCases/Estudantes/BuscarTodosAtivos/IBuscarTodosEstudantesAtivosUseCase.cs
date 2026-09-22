using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Estudantes.BuscarTodosAtivos;

public interface IBuscarTodosEstudantesAtivosUseCase
{
    Task<ResponseEstudantesAtivosJson> Executar();
}
