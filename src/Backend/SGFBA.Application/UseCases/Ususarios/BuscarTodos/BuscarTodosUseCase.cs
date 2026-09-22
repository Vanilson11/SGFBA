using Mapster;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Repositories.Usuarios;

namespace SGFBA.Application.UseCases.Ususarios.BuscarTodos;

public class BuscarTodosUseCase : IBuscarTodosUseCase
{
    private readonly IReadOnlyUsuarioRepository _readOnlyUsuarioRepository;

    public BuscarTodosUseCase(IReadOnlyUsuarioRepository readOnlyUsuarioRepository)
    {
        _readOnlyUsuarioRepository = readOnlyUsuarioRepository;
    }
    public async Task<ResponseUsuariosJson> Executar()
    {
        var usuarios = await _readOnlyUsuarioRepository.BuscarTodos();

        return new ResponseUsuariosJson
        {
            Usuarios = usuarios.Adapt<List<ResponseShortUsuarioJson>>()
        };
    }
}
