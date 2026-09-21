using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGFBA.Application.UseCases.Acoes.Registrar;
using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Enums;

namespace SGFBA.Api.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class AcoesController : ControllerBase
{
    [HttpPost]
    [Route("{idFicha}")]
    [Authorize(Roles = $"{Roles.ORIENTADOR}, {Roles.COORDENADOR}")]
    [ProducesResponseType(typeof(ResponseRegistrarAcaoJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Registrar(
        [FromServices] IRegistrarAcaoUseCase useCase,
        [FromBody] RequestRegistrarAcaoJson request,
        [FromRoute] long idFicha
        )
    {
        var response = await useCase.Executar(request, idFicha);

        return Created(string.Empty, response);
    }
}
