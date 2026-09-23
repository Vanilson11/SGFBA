using FluentValidation;
using SGFBA.Communication.Requests;
using SGFBA.Exception;

namespace SGFBA.Application.UseCases.Fichas;

public class FichaValidator : AbstractValidator<RequestFichaJson>
{
    public FichaValidator()
    {
        RuleFor(request => request.DataAbertura).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.DATA_FICHA_DO_FUTURO);
        RuleFor(request => request.Motivo).IsInEnum().WithMessage(ResourceErrorMessages.MOTIVO_INVALIDO);
        RuleFor(request => request.Status).IsInEnum().WithMessage(ResourceErrorMessages.STATUS_INVALIDO);
    }
}
