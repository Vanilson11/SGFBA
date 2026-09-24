using Mapster;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Repositories.Usuarios;

namespace SGFBA.Application.UseCases.Ususarios.BuscarCoordenadoresOrientadoresAtivos;

public class BuscarCoordenadoresOrientadoresAtivosUseCase : IBuscarCoordenadoresOrientadoresAtivosUseCase
{
    private readonly IReadOnlyUsuarioRepository _readOnlyUsuarioRepository;

    public BuscarCoordenadoresOrientadoresAtivosUseCase(IReadOnlyUsuarioRepository readOnlyUsuarioRepository)
    {
        _readOnlyUsuarioRepository = readOnlyUsuarioRepository;
    }
    public async Task<ResponseCoordenadoresOrientadoresAtivosJson> Executar()
    {
        var usuarios = await _readOnlyUsuarioRepository.BuscarCoordenadoresOrientadoresAtivos();

        return new ResponseCoordenadoresOrientadoresAtivosJson
        {
            Usuarios = (List<ResponseShortCoordenadorOrientadorAtivoJson>)usuarios.Adapt<IList<ResponseShortCoordenadorOrientadorAtivoJson>>()
        };
    }
}
