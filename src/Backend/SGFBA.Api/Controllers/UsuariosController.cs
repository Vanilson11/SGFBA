using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGFBA.Application.UseCases.Ususarios.BuscarPorId;
using SGFBA.Application.UseCases.Ususarios.BuscarTodos;
using SGFBA.Application.UseCases.Ususarios.BuscarTodosAtivos;
using SGFBA.Application.UseCases.Ususarios.Registrar;
using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Enums;

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

    [HttpGet]
    [Authorize(Roles = Roles.ADMIN)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ResponseUsuariosJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> BuscarTodos([FromServices] IBuscarTodosUseCase useCase)
    {
        var response = await useCase.Executar();

        return Ok(response);
    }

    [HttpGet("ativos")]
    [Authorize(Roles = $"{Roles.ADMIN}, {Roles.GESTOR_ESCOLAR}, {Roles.SECRETARIO}, {Roles.COORDENADOR}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ResponseUsuariosAtivosJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> BuscarTodosAtivos([FromServices] IBuscarTodosAtivosUseCase useCase)
    {
        var response = await useCase.Executar();

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [Authorize(Roles = $"{Roles.ADMIN}, {Roles.GESTOR_ESCOLAR}, {Roles.SECRETARIO}, {Roles.COORDENADOR}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseBuscarUsuarioJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> BuscarPorId(
        [FromServices] IBuscarUsuarioPorIdUseCase useCase,
        [FromRoute] long id)
    {
        var response = await useCase.Executar(id);

        return Ok(response);
    }
}
