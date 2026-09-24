using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Estudantes.BuscarEstudantesFichasAtivos;

public interface IBuscarEstudantesFichasAtivosUseCase
{
    Task<ResponseEstudantesFichasJson> Executar();
}
