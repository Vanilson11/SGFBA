using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGFBA.Application.UseCases.Fichas.Atualizar;
using SGFBA.Application.UseCases.Fichas.Cancelar;
using SGFBA.Application.UseCases.Fichas.Registrar;
using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Enums;

namespace SGFBA.Api.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class FichasController : ControllerBase
{
    [HttpPost]
    [Route("{idEstudante}")]
    [Authorize(Roles = $"{Roles.ORIENTADOR}, {Roles.COORDENADOR}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ResponseRegistrarFichaJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Registrar(
        [FromServices] IRegistrarFichaUseCase useCase,
        [FromBody] RequestFichaJson request,
        [FromRoute] long idEstudante
        )
    {
        var response = await useCase.Executar(request, idEstudante);

        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{idFicha}")]
    [Authorize(Roles = $"{Roles.ORIENTADOR}, {Roles.COORDENADOR}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Atualizar(
        [FromServices] IAtualizarFichaUseCase useCase,
        [FromBody] RequestFichaJson request,
        [FromRoute] long idFicha
        )
    {
        await useCase.Executar(request, idFicha);

        return NoContent();
    }

    [HttpDelete]
    [Route("{idFicha}")]
    [Authorize(Roles = $"{Roles.ORIENTADOR}, {Roles.COORDENADOR}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Cancelar(
        [FromServices] ICancelarFichaUseCase useCase,
        [FromRoute] long idFicha
        )
    {
        await useCase.Executar(idFicha);

        return NoContent();
    }
}
