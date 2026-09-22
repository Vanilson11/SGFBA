using SGFBA.Communication.Requests;

namespace SGFBA.Application.UseCases.Ususarios.AlterarSenha;

public interface IAlterarSenhaUsuarioUseCase
{
    Task Executar(RequestAlterarSenhaJson request);
}
