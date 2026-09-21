using Microsoft.AspNetCore.Mvc;
using SGFBA.Application.UseCases.DoLogin;
using SGFBA.Communication.Requests;
using SGFBA.Exception;

namespace SGFBA.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResourceErrorMessages), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DoLogin([FromServices] IDoLoginUseCase useCase, [FromBody] RequestDoLoginJson request)
    {
        var response = await useCase.Executar(request);

        return Ok(response);
    }
}
