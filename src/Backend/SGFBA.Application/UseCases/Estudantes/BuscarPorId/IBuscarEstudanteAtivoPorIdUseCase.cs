using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Estudantes.BuscarPorId;

public interface IBuscarEstudanteAtivoPorIdUseCase
{
    Task<ResponseEstudanteJson> Executar(long idEstudante);
}
