using SGFBA.Communication.Requests;

namespace SGFBA.Application.UseCases.Ususarios.AtualizarPerfil;

public interface IAtualizarPerfilUseCase
{
    Task Executar(RequestAtualizarPerfilJson request);
}
