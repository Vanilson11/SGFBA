using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGFBA.Domain.Repositories;
using SGFBA.Domain.Repositories.Fichas;
using SGFBA.Domain.Repositories.Usuarios;
using SGFBA.Domain.Security.Criptography;
using SGFBA.Domain.Security.Tokens;
using SGFBA.Domain.Services.LoggedUser;
using SGFBA.Infrastructure.DataAccess;
using SGFBA.Infrastructure.DataAccess.Repositories;
using SGFBA.Infrastructure.Security.Criptography;
using SGFBA.Infrastructure.Security.Tokens;
using SGFBA.Infrastructure.Services.LoggedUser;

namespace SGFBA.Infrastructure;

public static class DependencyInjectionExtentions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
        AddToken(services, configuration);

        services.AddScoped<IPasswordHasher, PasswordHashing>();
        services.AddScoped<ILoggedUser, LoggedUser>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("Connection");

        services.AddDbContext<SGFBADbContext>(config =>
        {
            config.UseMySQL(connection!);
        });
    }
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOffWork, UnitOffWork>();
        services.AddScoped<IReadOnlyUsuarioRepository, UsuariosRepository>();
        services.AddScoped<IWriteOnlyUsuariosRepository, UsuariosRepository>();
        services.AddScoped<IWriteOnlyFichasRepository, FichasRepository>();
    }

    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signinKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<IAccessTokenGenerator>(provider => new JwtTokenGenerator(expirationTimeMinutes, signinKey!));
    }
}
