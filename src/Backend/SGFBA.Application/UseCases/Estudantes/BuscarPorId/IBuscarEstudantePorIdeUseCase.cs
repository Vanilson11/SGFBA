using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Estudantes.BuscarPorId;

public interface IBuscarEstudantePorIdeUseCase
{
    Task<ResponseEstudanteJson> Executar(long idEstudante);
}
