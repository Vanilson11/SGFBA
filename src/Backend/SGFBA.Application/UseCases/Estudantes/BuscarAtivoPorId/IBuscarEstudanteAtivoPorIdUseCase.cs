using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Estudantes.BuscarAtivoPorId;

public interface IBuscarEstudanteAtivoPorIdUseCase
{
    Task<ResponseEstudanteJson> Executar(long idEstudante);
}
