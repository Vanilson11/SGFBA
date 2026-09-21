using Microsoft.EntityFrameworkCore;
using SGFBA.Domain.Entities;
using SGFBA.Domain.Security.Tokens;
using SGFBA.Domain.Services.LoggedUser;
using SGFBA.Infrastructure.DataAccess;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SGFBA.Infrastructure.Services.LoggedUser;

internal class LoggedUser : ILoggedUser
{
    private readonly SGFBADbContext _dbContext;
    private readonly ITokenProvider _tokenProvider;
    public LoggedUser(SGFBADbContext dbContext, ITokenProvider tokenProvider)
    {
        _dbContext = dbContext;
        _tokenProvider = tokenProvider;
    }
    public async Task<Usuario> Get()
    {
        var token = _tokenProvider.TokenOnRequest();
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = jwtSecurityTokenHandler.ReadJwtToken(token);
        var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

        return await _dbContext.Usuarios.AsNoTracking().FirstAsync(usuario => usuario.UserIdentifier == Guid.Parse(identifier));
    }
}
