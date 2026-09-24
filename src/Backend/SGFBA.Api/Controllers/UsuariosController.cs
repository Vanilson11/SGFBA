using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGFBA.Application.UseCases.Ususarios.AlterarSenha;
using SGFBA.Application.UseCases.Ususarios.Atualizar;
using SGFBA.Application.UseCases.Ususarios.AtualizarPerfil;
using SGFBA.Application.UseCases.Ususarios.BuscarCoordenadoresOrientadores;
using SGFBA.Application.UseCases.Ususarios.BuscarCoordenadoresOrientadoresAtivos;
using SGFBA.Application.UseCases.Ususarios.BuscarCoordenadorOrientadorAtivoPorId;
using SGFBA.Application.UseCases.Ususarios.BuscarCoordenadorOrientadorPorId;
using SGFBA.Application.UseCases.Ususarios.BuscarPorId;
using SGFBA.Application.UseCases.Ususarios.BuscarTodos;
using SGFBA.Application.UseCases.Ususarios.BuscarTodosAtivos;
using SGFBA.Application.UseCases.Ususarios.Desativar;
using SGFBA.Application.UseCases.Ususarios.Registrar;
using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Enums;
using SGFBA.Exception;

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
    [Authorize(Roles = $"{Roles.GESTOR_ESCOLAR}, {Roles.SECRETARIO}, {Roles.COORDENADOR}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ResponseUsuariosAtivosJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> BuscarTodosAtivos([FromServices] IBuscarTodosAtivosUseCase useCase)
    {
        var response = await useCase.Executar();

        return Ok(response);
    }

    [HttpGet("coordenadores/orientadores/ativos")]
    [Authorize(Roles = $"{Roles.GESTOR_ESCOLAR}, {Roles.SECRETARIO}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ResponseCoordenadoresOrientadoresAtivosJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> BuscarCoordenadoresOrientadoresAtivos(
        [FromServices] IBuscarCoordenadoresOrientadoresAtivosUseCase useCase
        )
    {
        var response = await useCase.Executar();

        return Ok(response);
    }

    [HttpGet("coordenadores/orientadores")]
    [Authorize(Roles = Roles.ADMIN)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ResponseCoordenadoresOrientadoresJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> BuscarCoordenaoresOrientadores(
        [FromServices] IBuscarCoordenadoresOrientadoresUseCase useCase
        )
    {
        var response = await useCase.Executar();

        return Ok(response);
    }

    [HttpGet("coordenadores/orientadores/ativos/{id}")]
    [Authorize(Roles = $"{Roles.GESTOR_ESCOLAR}, {Roles.SECRETARIO}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ResponseCoordenadorOrientadorJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResourceErrorMessages), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> BuscarCoordenadorOrientadorAtivoPorId(
        [FromServices] IBuscarCoordenadorOrientadorAtivoPorIdUseCase useCase,
        [FromRoute] long id
        )
    {
        var response = await useCase.Executar(id);

        return Ok(response);
    }

    [HttpGet("coordenadores/orientadores/{id}")]
    [Authorize(Roles = $"{Roles.ADMIN}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ResponseCoordenadorOrientadorJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResourceErrorMessages), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> BuscarCoordenadorOrientadorPorId(
        [FromServices] IBuscarCoordenadorOrientadorPorIdUseCase useCase,
        [FromRoute] long id
        )
    {
        var response = await useCase.Executar(id);

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

    [HttpPut("atualizar-perfil")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResourceErrorMessages), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AtualizarPerfil(
        [FromServices] IAtualizarPerfilUseCase useCase,
        [FromBody] RequestAtualizarPerfilJson request)
    {
        await useCase.Executar(request);

        return NoContent();
    }

    [HttpPut]
    [Route("{idUsuario}")]
    [Authorize(Roles = Roles.ADMIN)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ResourceErrorMessages), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResourceErrorMessages), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Atualizar(
        [FromServices] IAtualizarUsuarioUseCase useCase,
        [FromBody] RequestAtualizarUsuarioJson request,
        [FromRoute] long idUsuario
        )
    {
        await useCase.Executar(request, idUsuario);

        return NoContent();
    }

    [HttpPut("alterar-senha")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ResourceErrorMessages), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AlterarSenha(
        [FromServices] IAlterarSenhaUsuarioUseCase useCase,
        [FromBody] RequestAlterarSenhaJson request
        )
    {
        await useCase.Executar(request);

        return NoContent();
    }

    [HttpDelete]
    [Route("{idUsuario}")]
    [Authorize(Roles = Roles.ADMIN)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ResourceErrorMessages), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Desativar(
        [FromServices] IDesativarUsuarioUseCase useCase,
        [FromRoute] long idUsuario
        )
    {
        await useCase.Executar(idUsuario);

        return NoContent();
    }
}
