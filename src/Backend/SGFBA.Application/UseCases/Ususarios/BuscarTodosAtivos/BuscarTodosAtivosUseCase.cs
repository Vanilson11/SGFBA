using Mapster;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Repositories.Usuarios;

namespace SGFBA.Application.UseCases.Ususarios.BuscarTodosAtivos;

public class BuscarTodosAtivosUseCase : IBuscarTodosAtivosUseCase
{
    private readonly IReadOnlyUsuarioRepository _readOnlyUsuarioRepository;

    public BuscarTodosAtivosUseCase(IReadOnlyUsuarioRepository readOnlyUsuarioRepository)
    {
        _readOnlyUsuarioRepository = readOnlyUsuarioRepository;
    }
    public async Task<ResponseUsuariosJson> Executar()
    {
        var usuarios = await _readOnlyUsuarioRepository.BuscarTodosAtivos();

        return new ResponseUsuariosJson
        {
            Usuarios = usuarios.Adapt<List<ResponseShortUsuarioJson>>()
        };
    }
}
