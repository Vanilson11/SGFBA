using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGFBA.Application.UseCases.Acoes.Atualizar;
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
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ResponseRegistrarAcaoJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Registrar(
        [FromServices] IRegistrarAcaoUseCase useCase,
        [FromBody] RequestAcaoJson request,
        [FromRoute] long idFicha
        )
    {
        var response = await useCase.Executar(request, idFicha);

        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{idAcao}/fichas/{idFicha}")]
    [Authorize(Roles = $"{Roles.COORDENADOR},{Roles.ORIENTADOR}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Atualizar(
        [FromServices] IAtualizarAcaoUseCase useCase,
        [FromBody] RequestAcaoJson request,
        [FromRoute] long idAcao,
        [FromRoute] long idFicha
        )
    {
        await useCase.Executar(request, idAcao, idFicha);

        return NoContent();
    }
}
