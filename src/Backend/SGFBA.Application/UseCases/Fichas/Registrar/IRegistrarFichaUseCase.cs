using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;

namespace SGFBA.Application.UseCases.Fichas.Registrar;

public interface IRegistrarFichaUseCase
{
    Task<ResponseRegistrarFichaJson> Executar(RequestRegistrarFichaJson request);
}
