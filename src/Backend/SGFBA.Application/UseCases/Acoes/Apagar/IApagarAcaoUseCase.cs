namespace SGFBA.Application.UseCases.Acoes.Apagar;

public interface IApagarAcaoUseCase
{
    Task Executar(long idAcao, long idFicha);
}
