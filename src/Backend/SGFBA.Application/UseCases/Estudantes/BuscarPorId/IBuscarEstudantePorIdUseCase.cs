using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Estudantes.BuscarPorId;

public interface IBuscarEstudantePorIdUseCase
{
    Task<ResponseEstudanteJson> Executar(long idEstudante);
}
