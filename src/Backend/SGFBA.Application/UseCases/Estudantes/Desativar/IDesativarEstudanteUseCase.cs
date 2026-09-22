namespace SGFBA.Application.UseCases.Estudantes.Desativar;

public interface IDesativarEstudanteUseCase
{
    Task Executar(long idEstudante);
}
