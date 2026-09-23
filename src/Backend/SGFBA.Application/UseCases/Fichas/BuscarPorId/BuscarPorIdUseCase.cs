using SGFBA.Communication.Responses;
using SGFBA.Domain.Repositories.Fichas;
using SGFBA.Domain.Repositories.Usuarios;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Fichas.BuscarPorId;

public class BuscarPorIdUseCase : IBuscarPorIdUseCase
{
    private readonly IReadOnlyUsuarioRepository _readOnlyUsuarioRepository;
    private readonly IReadOnlyFichasRepository _readOnlyFichasRepository;

    public BuscarPorIdUseCase(
        IReadOnlyUsuarioRepository readOnlyUsuarioRepository,
        IReadOnlyFichasRepository readOnlyFichasRepository
        )
    {
        _readOnlyUsuarioRepository = readOnlyUsuarioRepository;
        _readOnlyFichasRepository = readOnlyFichasRepository;
    }
    public async Task<ResponseFichaJson> Executar(long idUsuario, long idFicha)
    {
        var usuario = await _readOnlyUsuarioRepository.BuscarPorId(idUsuario);

        if (usuario is null) throw new NotFoundException(ResourceErrorMessages.USUARIO_NAO_ENCONTRADO);

        var ficha = await _readOnlyFichasRepository.BuscarPorId(usuario.Id, idFicha);

        if (ficha is null) throw new NotFoundException(ResourceErrorMessages.FICHA_NAO_ENCONTRADA);

        return new ResponseFichaJson
        {
            Id = ficha.Id,
            DataAbertura = ficha.DataAbertura,
            Motivo = (Communication.Enums.Motivo)ficha.Motivo,
            Status = (Communication.Enums.StatusFicha)ficha.Status,
            Observacao = ficha.Observacao
        };
    }
}
