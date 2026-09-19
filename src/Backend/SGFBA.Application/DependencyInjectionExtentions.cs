using Microsoft.Extensions.DependencyInjection;
using SGFBA.Application.Ususarios.Registrar;

namespace SGFBA.Application;

public static class DependencyInjectionExtentions
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegistrarUsuarioUseCase, RegistrarUsuarioUseCase>();
    }
}
