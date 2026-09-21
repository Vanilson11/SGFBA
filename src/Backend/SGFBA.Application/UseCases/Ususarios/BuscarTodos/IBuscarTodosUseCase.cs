using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Ususarios.BuscarTodos;

public interface IBuscarTodosUseCase
{
    Task<ResponseUsuariosJson> Executar();
}
