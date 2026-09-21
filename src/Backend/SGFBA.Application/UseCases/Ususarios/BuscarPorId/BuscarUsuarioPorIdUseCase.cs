using SGFBA.Communication.Responses;
using SGFBA.Domain.Repositories.Usuarios;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Ususarios.BuscarPorId;

public class BuscarUsuarioPorIdUseCase : IBuscarUsuarioPorIdUseCase
{
    private readonly IReadOnlyUsuarioRepository _readOnlyUsuarioRepository;

    public BuscarUsuarioPorIdUseCase(IReadOnlyUsuarioRepository readOnlyUsuarioRepository)
    {
        _readOnlyUsuarioRepository = readOnlyUsuarioRepository;
    }
    public async Task<ResponseBuscarUsuarioJson> Executar(long id)
    {
        var usuario = await _readOnlyUsuarioRepository.BuscarPorId(id);

        if (usuario is null) throw new NotFoundException(ResourceErrorMessages.USUARIO_NAO_ENCONTRADO);

        return new ResponseBuscarUsuarioJson
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Matricula = usuario.Matricula,
            Cargo = (Communication.Enums.CargoUsuario)usuario.Cargo,
            Role = usuario.Role,
            Ativo = usuario.Ativo
        };
    }
}
