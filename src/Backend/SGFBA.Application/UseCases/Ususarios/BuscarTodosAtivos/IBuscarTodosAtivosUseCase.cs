using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Ususarios.BuscarTodosAtivos;

public interface IBuscarTodosAtivosUseCase
{
    Task<ResponseUsuariosJson> Executar();
}
