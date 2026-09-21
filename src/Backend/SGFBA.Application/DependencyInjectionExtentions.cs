using Microsoft.Extensions.DependencyInjection;
using SGFBA.Application.UseCases.Acoes.Registrar;
using SGFBA.Application.UseCases.DoLogin;
using SGFBA.Application.UseCases.Estudantes.Registrar;
using SGFBA.Application.UseCases.Fichas.Registrar;
using SGFBA.Application.UseCases.Ususarios.Registrar;

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
        services.AddScoped<IRegistrarFichaUseCase, RegistrarFichaUseCase>();
        services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
        services.AddScoped<IRegistrarEstudanteUseCase, RegistrarEstudanteUseCase>();
        services.AddScoped<IRegistrarAcaoUseCase, RegistrarAcaoUseCase>();
    }
}
