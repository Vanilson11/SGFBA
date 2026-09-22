using FluentValidation;
using SGFBA.Communication.Requests;
using SGFBA.Exception;

namespace SGFBA.Application.UseCases.Estudantes;

public class EstudanteValidator : AbstractValidator<RequestEstudanteJson>
{
    public EstudanteValidator()
    {
        RuleFor(request => request.Nome).NotEmpty().WithMessage(ResourceErrorMessages.NOME_OBRIGATORIO)
            .MinimumLength(2).WithMessage(ResourceErrorMessages.NOME_MENOR_2_CARACTERES)
            .When(request => string.IsNullOrWhiteSpace(request.Nome) is false, ApplyConditionTo.CurrentValidator)
            .MaximumLength(100).WithMessage(ResourceErrorMessages.NOME_MAIOR_100_CARACTERES);
        RuleFor(request => request.Turma).IsInEnum().WithMessage(ResourceErrorMessages.TURMA_INVALIDA);
        RuleFor(request => request.Turno).IsInEnum().WithMessage(ResourceErrorMessages.TURNO_INVALIDO);
        RuleFor(request => request.DataNascimento).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.DATA_NASCIMENTO_INVALID);
        RuleFor(request => request.NomeResponsavel).NotEmpty().WithMessage(ResourceErrorMessages.NOME_OBRIGATORIO)
            .MinimumLength(2).WithMessage(ResourceErrorMessages.NOME_MENOR_2_CARACTERES)
            .When(request => string.IsNullOrWhiteSpace(request.NomeResponsavel) is false, ApplyConditionTo.CurrentValidator)
            .MaximumLength(100).WithMessage(ResourceErrorMessages.NOME_MAIOR_100_CARACTERES);
        RuleFor(request => request.TelefoneResponsavel).NotEmpty().WithMessage(ResourceErrorMessages.TELEFONE_OBRIGATORIO)
            .MinimumLength(10).WithMessage(ResourceErrorMessages.TELEFONE_MENOR_10_CARACTERES)
            .When(request => string.IsNullOrWhiteSpace(request.TelefoneResponsavel) is false, ApplyConditionTo.CurrentValidator)
            .MaximumLength(11).WithMessage(ResourceErrorMessages.TELEFONE_MAIOR_11_CARACTERES);
    }
}
