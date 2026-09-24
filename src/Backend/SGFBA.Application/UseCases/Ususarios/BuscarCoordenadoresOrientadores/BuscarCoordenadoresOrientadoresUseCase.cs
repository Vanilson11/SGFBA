using Mapster;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Repositories.Usuarios;

namespace SGFBA.Application.UseCases.Ususarios.BuscarCoordenadoresOrientadores;

public class BuscarCoordenadoresOrientadoresUseCase : IBuscarCoordenadoresOrientadoresUseCase
{
    private readonly IReadOnlyUsuarioRepository _readOnlyUsuarioRepository;

    public BuscarCoordenadoresOrientadoresUseCase(IReadOnlyUsuarioRepository readOnlyUsuarioRepository)
    {
        _readOnlyUsuarioRepository = readOnlyUsuarioRepository;
    }
    public async Task<ResponseCoordenadoresOrientadoresJson> Executar()
    {
        var usuarios = await _readOnlyUsuarioRepository.BuscarCoordenadoresOrientadores();

        return new ResponseCoordenadoresOrientadoresJson
        {
            Usuarios = (List<ResponseShortCoordenadoresOrientadoresJson>)usuarios.Adapt<IList<ResponseShortCoordenadoresOrientadoresJson>>()
        };
    }
}
