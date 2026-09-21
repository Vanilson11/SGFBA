using FluentValidation;
using SGFBA.Communication.Requests;
using SGFBA.Exception;

namespace SGFBA.Application.UseCases.Ususarios;

public class UsuarioValidator : AbstractValidator<RequestRegistrarUsuarioJson>
{
    public UsuarioValidator()
    {
        RuleFor(request => request.Nome).NotEmpty().WithMessage(ResourceErrorMessages.NOME_OBRIGATORIO)
            .MinimumLength(2).WithMessage(ResourceErrorMessages.NOME_MENOR_2_CARACTERES)
            .When(request => string.IsNullOrWhiteSpace(request.Nome) is false, ApplyConditionTo.CurrentValidator)
            .MaximumLength(100).WithMessage(ResourceErrorMessages.NOME_MAIOR_100_CARACTERES);
        RuleFor(request => request.Matricula).NotEmpty().WithMessage(ResourceErrorMessages.MATRICULA_OBRIGATORIA)
            .MinimumLength(10).WithMessage(ResourceErrorMessages.MATRICULA_10_CARACTERES)
            .When(request => string.IsNullOrWhiteSpace(request.Matricula) == false, ApplyConditionTo.CurrentValidator)
            .MaximumLength(10).WithMessage(ResourceErrorMessages.MATRICULA_MAIOR_10_CARACTERES);
        RuleFor(request => request.Cargo).IsInEnum().WithMessage(ResourceErrorMessages.CARGO_INVALIDO);
        RuleFor(request => request.Email).NotEmpty().WithMessage(ResourceErrorMessages.EMAIL_OBRIGATORIO)
            .EmailAddress().WithMessage(ResourceErrorMessages.EMAIL_INVALIDO)
            .When(request => string.IsNullOrWhiteSpace(request.Email) is false, ApplyConditionTo.CurrentValidator);
        RuleFor(request => request.Senha).SetValidator(new SenhaValidator<RequestRegistrarUsuarioJson>());
    }
}
