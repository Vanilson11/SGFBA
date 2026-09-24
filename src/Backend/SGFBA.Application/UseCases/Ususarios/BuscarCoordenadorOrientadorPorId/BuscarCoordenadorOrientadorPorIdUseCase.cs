using Mapster;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Repositories.Usuarios;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Ususarios.BuscarCoordenadorOrientadorPorId;

public class BuscarCoordenadorOrientadorPorIdUseCase : IBuscarCoordenadorOrientadorPorIdUseCase
{
    private readonly IReadOnlyUsuarioRepository _readOnlyUsuarioRepository;

    public BuscarCoordenadorOrientadorPorIdUseCase(IReadOnlyUsuarioRepository readOnlyUsuarioRepository)
    {
        _readOnlyUsuarioRepository = readOnlyUsuarioRepository;
    }
    public async Task<ResponseCoordenadorOrientadorJson> Executar(long id)
    {
        var usuario = await _readOnlyUsuarioRepository.BuscarCoordenadorOrientadorPorId(id);

        if (usuario is null) throw new NotFoundException(ResourceErrorMessages.USUARIO_NAO_ENCONTRADO);

        var response = usuario.Adapt<ResponseCoordenadorOrientadorJson>();

        return response;
    }
}
