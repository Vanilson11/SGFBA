using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGFBA.Application.UseCases.Fichas.Atualizar;
using SGFBA.Application.UseCases.Fichas.BuscarAtivaPorId;
using SGFBA.Application.UseCases.Fichas.BuscarTodas;
using SGFBA.Application.UseCases.Fichas.BuscarTodasAtivas;
using SGFBA.Application.UseCases.Fichas.Cancelar;
using SGFBA.Application.UseCases.Fichas.Registrar;
using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Enums;
using SGFBA.Exception;

namespace SGFBA.Api.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class FichasController : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = $"{Roles.SECRETARIO},{Roles.GESTOR_ESCOLAR}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ResponseFichasJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> BuscarTodas([FromServices] IBuscarTodasFichasUseCase useCase)
    {
        var response = await useCase.Executar();

        return Ok(response);
    }

    [HttpGet("ativas")]
    [Authorize(Roles = $"{Roles.COORDENADOR},{Roles.ORIENTADOR}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ResponseFichasJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> BuscarTodasAtivas([FromServices] IBuscarTodasFichasAtivasUseCase useCase)
    {
        var response = await useCase.Executar();

        return Ok(response);
    }

    [HttpGet]
    [Route("ativa/{idFicha}")]
    [Authorize(Roles = $"{Roles.COORDENADOR},{Roles.ORIENTADOR}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ResponseFichaJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResourceErrorMessages), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> BuscarAtivaPorId(
        [FromServices] IBuscarFichaAtivaPorIdUseCase useCase,
        [FromRoute] long idFicha
        )
    {
        var response = await useCase.Executar(idFicha);

        return Ok(response);
    }


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
