using SGFBA.Domain.Repositories;
using SGFBA.Domain.Repositories.Acoes;
using SGFBA.Domain.Repositories.Fichas;
using SGFBA.Domain.Services.LoggedUser;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Acoes.Apagar;

public class ApagarAcaoUseCase : IApagarAcaoUseCase
{
    private readonly IWriteOnlyAcoesRepository _writeOnlyAcoesRepository;
    private readonly IUpdateOnlyAcoesRepository _updateOnlyAcoesRepository;
    private readonly IReadOnlyFichasRepository _readOnlyFichasRepository;
    private readonly ILoggedUser _loggedUser;
    private readonly IUnitOffWork _unitOffWork;

    public ApagarAcaoUseCase(
        IWriteOnlyAcoesRepository writeOnlyAcoesRepository,
        IUpdateOnlyAcoesRepository updateOnlyAcoesRepository,
        IReadOnlyFichasRepository readOnlyFichasRepository,
        ILoggedUser loggedUser,
        IUnitOffWork unitOffWork
        )
    {
        _writeOnlyAcoesRepository = writeOnlyAcoesRepository;
        _updateOnlyAcoesRepository = updateOnlyAcoesRepository;
        _readOnlyFichasRepository = readOnlyFichasRepository;
        _loggedUser = loggedUser;
        _unitOffWork = unitOffWork;
    }
    public async Task Executar(long idAcao, long idFicha)
    {
        var usuarioLogado = await _loggedUser.Get();

        var ficha = await _readOnlyFichasRepository.BuscarAtivaPorId(usuarioLogado.Id, idFicha);

        if (ficha is null) throw new NotFoundException(ResourceErrorMessages.FICHA_NAO_ENCONTRADA);

        var acao = await _updateOnlyAcoesRepository.BuscarPorId(idAcao, ficha.Id);

        if(acao is null) throw new NotFoundException(ResourceErrorMessages.ACAO_NAO_ENCONTRADA);

        _writeOnlyAcoesRepository.Apagar(acao);

        await _unitOffWork.Commit();
    }
}
