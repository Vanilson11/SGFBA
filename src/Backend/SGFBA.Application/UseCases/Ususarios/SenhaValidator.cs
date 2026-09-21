using FluentValidation;
using FluentValidation.Validators;
using SGFBA.Exception;
using System.Text.RegularExpressions;

namespace SGFBA.Application.UseCases.Ususarios;

public class SenhaValidator<T> : PropertyValidator<T, string>
{
    private const string ERROR_MESSAGE_KEY = "ErrorMessage";
    public override string Name => "SenhaValidator";
    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return $"{{{ERROR_MESSAGE_KEY}}}";
    }

    public override bool IsValid(ValidationContext<T> context, string senha)
    {
        if (string.IsNullOrWhiteSpace(senha))
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.SENHA_OBRIGATORIA);
            return false;
        }

        if (senha.Length < 8)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.SENHA_INVALIDA);
            return false;
        }

        if (Regex.IsMatch(senha, @"[A-Z]+") == false)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.SENHA_INVALIDA);
            return false;
        }

        if (Regex.IsMatch(senha, @"[a-z]+") == false)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.SENHA_INVALIDA);
            return false;
        }

        if (Regex.IsMatch(senha, @"[0-9]+") == false)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.SENHA_INVALIDA);
            return false;
        }

        if (Regex.IsMatch(senha, @"[\!\*\@\#\$\.]+") == false)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.SENHA_INVALIDA);
            return false;
        }

        return true;
    }
}
