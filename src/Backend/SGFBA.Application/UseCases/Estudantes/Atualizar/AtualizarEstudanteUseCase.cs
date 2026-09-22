using SGFBA.Communication.Requests;
using SGFBA.Domain.Repositories;
using SGFBA.Domain.Repositories.Estudantes;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Estudantes.Atualizar;

public class AtualizarEstudanteUseCase : IAtualizarEstudanteUseCase
{
    private readonly IUpdateOnlyEstudantesRepository _updateOnlyEstudantesRepository;
    private readonly IUnitOffWork _unitOffWork;

    public AtualizarEstudanteUseCase(
        IUpdateOnlyEstudantesRepository updateOnlyEstudantesRepository,
        IUnitOffWork unitOffWork)
    {
        _updateOnlyEstudantesRepository = updateOnlyEstudantesRepository;
        _unitOffWork = unitOffWork;
    }
    public async Task Executar(RequestEstudanteJson request, long idEstudante)
    {
        Validar_Request(request);

        var estudante = await _updateOnlyEstudantesRepository.BuscarPorId(idEstudante);

        if (estudante is null) throw new NotFoundException(ResourceErrorMessages.ESTUDANTE_NAO_ENCONTRADO);

        estudante.Nome = request.Nome;
        estudante.Turma = (Domain.Enums.Turma)request.Turma;
        estudante.Turno = (Domain.Enums.Turno)request.Turno;
        estudante.DataNascimento = request.DataNascimento;
        estudante.NomeResponsavel = request.NomeResponsavel;
        estudante.TelefoneResponsavel = request.TelefoneResponsavel;

        _updateOnlyEstudantesRepository.Atualizar(estudante);

        await _unitOffWork.Commit();
    }

    private void Validar_Request(RequestEstudanteJson request)
    {
        var resultado = new EstudanteValidator().Validate(request);

        if(resultado.IsValid is false)
        {
            var mensagensErro = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrosNaValidacaoException(mensagensErro);
        }
    }
}
