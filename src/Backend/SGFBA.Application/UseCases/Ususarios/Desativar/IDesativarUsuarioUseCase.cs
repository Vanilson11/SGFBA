namespace SGFBA.Application.UseCases.Ususarios.Desativar;

public interface IDesativarUsuarioUseCase
{
    Task Executar(long idUsuario);
}
