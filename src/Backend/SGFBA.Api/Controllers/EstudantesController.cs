using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    [HttpPost]
    [Authorize(Roles = $"{Roles.ORIENTADOR},{Roles.COORDENADOR},{Roles.SECRETARIO},{Roles.GESTOR_ESCOLAR}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ResourceErrorMessages), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseRegistrarEstudanteJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Registrar([FromServices] IRegistrarEstudanteUseCase useCase, [FromBody] RequestRegistrarEstudanteJson request)
    {
        var response = await useCase.Executar(request);

        return Created(string.Empty, response);
    }
}
