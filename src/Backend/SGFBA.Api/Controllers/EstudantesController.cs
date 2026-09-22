using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGFBA.Application.UseCases.Estudantes.Atualizar;
using SGFBA.Application.UseCases.Estudantes.BuscarAtivoPorId;
using SGFBA.Application.UseCases.Estudantes.BuscarPorId;
using SGFBA.Application.UseCases.Estudantes.BuscarTodos;
using SGFBA.Application.UseCases.Estudantes.BuscarTodosAtivos;
using SGFBA.Application.UseCases.Estudantes.Desativar;
using SGFBA.Application.UseCases.Estudantes.Registrar;
using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Enums;
using SGFBA.Exception;

namespace SGFBA.Api.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class EstudantesController : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = $"{Roles.ADMIN},{Roles.GESTOR_ESCOLAR},{Roles.SECRETARIO}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ResponseEstudantesJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> BuscarTodos([FromServices] IBuscarTodosEstudantesUseCase useCase)
    {
        var response = await useCase.Executar();

        return Ok(response);
    }

    [HttpGet("ativos")]
    [Authorize(Roles = $"{Roles.ORIENTADOR},{Roles.COORDENADOR}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ResponseEstudantesAtivosJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> BuscarTodosAtivos([FromServices] IBuscarTodosEstudantesAtivosUseCase useCase)
    {
        var response = await useCase.Executar();

        return Ok(response);
    }

    [HttpGet]
    [Route("ativo/{idEstudante}")]
    [Authorize(Roles = $"{Roles.ORIENTADOR},{Roles.COORDENADOR},{Roles.SECRETARIO},{Roles.GESTOR_ESCOLAR},{Roles.ADMIN}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ResponseEstudanteAtivoJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResourceErrorMessages), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> BuscarAtivoPorId(
        [FromServices] IBuscarEstudanteAtivoPorIdUseCase useCase,
        [FromRoute] long idEstudante)
    {
        var response = await useCase.Executar(idEstudante);

        return Ok(response);
    }

    [HttpGet]
    [Route("{idEstudante}")]
    [Authorize(Roles = $"{Roles.SECRETARIO},{Roles.GESTOR_ESCOLAR},{Roles.ADMIN}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ResponseEstudanteJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResourceErrorMessages), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> BuscarPorId(
        [FromServices] IBuscarEstudantePorIdeUseCase useCase,
        [FromRoute] long idEstudante)
    {
        var response = await useCase.Executar(idEstudante);

        return Ok(response);
    }

    [HttpPost]
    [Authorize(Roles = $"{Roles.ORIENTADOR},{Roles.COORDENADOR},{Roles.SECRETARIO},{Roles.GESTOR_ESCOLAR}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ResourceErrorMessages), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseRegistrarEstudanteJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Registrar([FromServices] IRegistrarEstudanteUseCase useCase, [FromBody] RequestEstudanteJson request)
    {
        var response = await useCase.Executar(request);

        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{idEstudante}")]
    [Authorize(Roles = $"{Roles.ORIENTADOR},{Roles.COORDENADOR},{Roles.SECRETARIO},{Roles.GESTOR_ESCOLAR},{Roles.ADMIN}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResourceErrorMessages), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResourceErrorMessages), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AtualizarEstudante(
        [FromServices] IAtualizarEstudanteUseCase useCase,
        [FromBody] RequestEstudanteJson request,
        [FromRoute] long idEstudante
        )
    {
        await useCase.Executar(request, idEstudante);

        return NoContent();
    }

    [HttpDelete]
    [Route("{idEstudante}")]
    [Authorize(Roles = $"{Roles.SECRETARIO},{Roles.GESTOR_ESCOLAR},{Roles.ADMIN}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResourceErrorMessages), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Desativar(
        [FromServices] IDesativarEstudanteUseCase useCase,
        [FromRoute] long idEstudante
        )
    {
        await useCase.Executar(idEstudante);

        return NoContent();
    }
}
