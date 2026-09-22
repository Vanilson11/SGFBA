using SGFBA.Communication.Requests;

namespace SGFBA.Application.UseCases.Ususarios.Atualizar;

public interface IAtualizarUsuarioUseCase
{
    Task Executar(RequestAtualizarUsuarioJson request, long idUsuario);
}
