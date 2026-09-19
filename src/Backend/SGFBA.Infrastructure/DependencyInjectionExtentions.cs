using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SGFBA.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace SGFBA.Infrastructure;

public static class DependencyInjectionExtentions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("Connection");

        services.AddDbContext<SGFBADbContext>(config =>
        {
            config.UseMySQL(connection!);
        });
    }
}
