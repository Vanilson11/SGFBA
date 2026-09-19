using Microsoft.AspNetCore.Mvc;
using SGFBA.Application.Ususarios.Registrar;
using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;

namespace SGFBA.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegistrarUsuarioJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Registrar(
        [FromServices] IRegistrarUsuarioUseCase useCase,
        [FromBody] RequestRegistrarUsuarioJson request
        )
    {
        var response = await useCase.Executar(request);

        return Created(string.Empty, response);
    }
}
