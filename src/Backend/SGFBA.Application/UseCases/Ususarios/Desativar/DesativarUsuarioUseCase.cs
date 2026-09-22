using SGFBA.Domain.Repositories;
using SGFBA.Domain.Repositories.Usuarios;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Ususarios.Desativar;

public class DesativarUsuarioUseCase : IDesativarUsuarioUseCase
{
    private readonly IReadOnlyUsuarioRepository _readOnlyUsuarioRepository;
    private readonly IWriteOnlyUsuariosRepository _writeOnlyUsuariosRepository;
    private readonly IUnitOffWork _unitOffWork;

    public DesativarUsuarioUseCase(
        IReadOnlyUsuarioRepository readOnlyUsuarioRepository,
        IWriteOnlyUsuariosRepository writeOnlyUsuariosRepository,
        IUnitOffWork unitOffWork
        )
    {
        _readOnlyUsuarioRepository = readOnlyUsuarioRepository;
        _writeOnlyUsuariosRepository = writeOnlyUsuariosRepository;
        _unitOffWork = unitOffWork;
    }
    public async Task Executar(long idUsuario)
    {
        var usuario = await _readOnlyUsuarioRepository.BuscarPorId(idUsuario);

        if (usuario is null) throw new NotFoundException(ResourceErrorMessages.USUARIO_NAO_ENCONTRADO);

        var resultado = await _writeOnlyUsuariosRepository.Desativar(usuario);

        if(resultado is false) throw new NotFoundException(ResourceErrorMessages.DESATIVAR_USUARIO_ERRO);

        await _unitOffWork.Commit();
    }
}
