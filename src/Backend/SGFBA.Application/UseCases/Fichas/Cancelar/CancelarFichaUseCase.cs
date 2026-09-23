using SGFBA.Domain.Repositories;
using SGFBA.Domain.Repositories.Fichas;
using SGFBA.Domain.Services.LoggedUser;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Fichas.Cancelar;

public class CancelarFichaUseCase : ICancelarFichaUseCase
{
    private readonly IUpdateOnlyFichasRepository _updateOnlyFichasRepository;
    private readonly ILoggedUser _loggedUser;
    private readonly IUnitOffWork _unitOffWork;

    public CancelarFichaUseCase(
        IUpdateOnlyFichasRepository updateOnlyFichasRepository,
        ILoggedUser loggedUser,
        IUnitOffWork unitOffWork
        )
    {
        _updateOnlyFichasRepository = updateOnlyFichasRepository;
        _loggedUser = loggedUser;
        _unitOffWork = unitOffWork;
    }
    public async Task Executar(long idFicha)
    {
        var usuarioLogado = await _loggedUser.Get();

        var ficha = await _updateOnlyFichasRepository.BuscarPorId(usuarioLogado.Id, idFicha);

        if (ficha is null) throw new NotFoundException(ResourceErrorMessages.FICHA_NAO_ENCONTRADA);

        ficha.Status = Domain.Enums.StatusFicha.Cancelada;

        _updateOnlyFichasRepository.Atualizar(ficha);

        await _unitOffWork.Commit();
    }
}
