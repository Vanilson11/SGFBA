using FluentValidation;
using SGFBA.Communication.Requests;
using SGFBA.Exception;

namespace SGFBA.Application.UseCases.Acoes;

public class AcaoValidator : AbstractValidator<RequestRegistrarAcaoJson>
{
    public AcaoValidator()
    {
        RuleFor(request => request.Tipo).IsInEnum().WithMessage(ResourceErrorMessages.TIPO_ACAO_INVALIDO);
        RuleFor(request => request.Data).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.DATA_ACAO_FUTURO);
        RuleFor(request => request.Observacao).MaximumLength(500).WithMessage(ResourceErrorMessages.CAMPO_500_CARACTERES);
    }
}
