using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Estudantes.BuscarEstudantesFichas;

public interface IBuscarEstudantesFichasUseCase
{
    Task<ResponseEstudantesFichasJson> Executar();
}
