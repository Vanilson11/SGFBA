namespace SGFBA.Application.UseCases.Fichas.Cancelar;

public interface ICancelarFichaUseCase
{
    Task Executar(long idFicha);
}
