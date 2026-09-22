using SGFBA.Communication.Responses;
using SGFBA.Domain.Repositories.Estudantes;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Estudantes.BuscarAtivoPorId;

public class BuscarEstudanteAtivoPorIdUseCase : IBuscarEstudanteAtivoPorIdUseCase
{
    private readonly IReadOnlyEstudantesRepository _readOnlyEstudantesRepository;

    public BuscarEstudanteAtivoPorIdUseCase(IReadOnlyEstudantesRepository readOnlyEstudantesRepository)
    {
        _readOnlyEstudantesRepository = readOnlyEstudantesRepository;
    }
    public async Task<ResponseEstudanteAtivoJson> Executar(long idEstudante)
    {
        var estudante = await _readOnlyEstudantesRepository.BuscarAtivoPorId(idEstudante);

        if (estudante is null) throw new NotFoundException(ResourceErrorMessages.ESTUDANTE_NAO_ENCONTRADO);

        return new ResponseEstudanteAtivoJson
        {
            Id = estudante.Id,
            Nome = estudante.Nome,
            Turma = (Communication.Enums.Turma)estudante.Turma,
            Turno = (Communication.Enums.Turno)estudante.Turno,
            DataNascimento = estudante.DataNascimento,
            NomeResponsavel = estudante.NomeResponsavel,
            TelefoneResponsavel = estudante.TelefoneResponsavel,
        };
    }
}
