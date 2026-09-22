using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Estudantes.BuscarTodos;

public interface IBuscarTodosEstudantesUseCase
{
    Task<ResponseEstudantesJson> Executar();
}
