using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Estudantes.BuscarAtivoPorId;

public interface IBuscarEstudanteAtivoPorIdUseCase
{
    Task<ResponseEstudanteAtivoJson> Executar(long idEstudante);
}
