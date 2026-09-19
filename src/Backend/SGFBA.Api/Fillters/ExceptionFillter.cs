using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SGFBA.Communication.Responses;
using SGFBA.Exception;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Api.Fillters;

public class ExceptionFillter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is SGFBAException)
        {
            HandleException(context);
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    private void HandleException(ExceptionContext context)
    {
        var exception = context.Exception as SGFBAException;
        var mensagensErro = new ResponseErrorMessagesJson(exception!.GetErros());

        context.HttpContext.Response.StatusCode = exception.StatusCode;
        context.Result = new ObjectResult(mensagensErro);
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        var mensagensErro = new ResponseErrorMessagesJson(ResourceErrorMessages.ERRO_DESCONHECIDO);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(mensagensErro);
    }
}
