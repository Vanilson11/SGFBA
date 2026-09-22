using FluentValidation;
using SGFBA.Communication.Requests;

namespace SGFBA.Application.UseCases.Ususarios.AlterarSenha;

public class AlterarSenhaValidator : AbstractValidator<RequestAlterarSenhaJson>
{
    public AlterarSenhaValidator()
    {
        RuleFor(request => request.NovaSenha).SetValidator(new SenhaValidator<RequestAlterarSenhaJson>());
    }
}
