using Microsoft.Extensions.DependencyInjection;
using SGFBA.Application.UseCases.Acoes.Atualizar;
using SGFBA.Application.UseCases.Acoes.BuscarPorId;
using SGFBA.Application.UseCases.Acoes.BuscarTodas;
using SGFBA.Application.UseCases.Acoes.Registrar;
using SGFBA.Application.UseCases.DoLogin;
using SGFBA.Application.UseCases.Estudantes.Atualizar;
using SGFBA.Application.UseCases.Estudantes.BuscarAtivoPorId;
using SGFBA.Application.UseCases.Estudantes.BuscarPorId;
using SGFBA.Application.UseCases.Estudantes.BuscarTodos;
using SGFBA.Application.UseCases.Estudantes.BuscarTodosAtivos;
using SGFBA.Application.UseCases.Estudantes.Desativar;
using SGFBA.Application.UseCases.Estudantes.Registrar;
using SGFBA.Application.UseCases.Fichas.Atualizar;
using SGFBA.Application.UseCases.Fichas.BuscarAtivaPorId;
using SGFBA.Application.UseCases.Fichas.BuscarPorId;
using SGFBA.Application.UseCases.Fichas.BuscarTodas;
using SGFBA.Application.UseCases.Fichas.BuscarTodasAtivas;
using SGFBA.Application.UseCases.Fichas.Cancelar;
using SGFBA.Application.UseCases.Fichas.Registrar;
using SGFBA.Application.UseCases.Ususarios.AlterarSenha;
using SGFBA.Application.UseCases.Ususarios.Atualizar;
using SGFBA.Application.UseCases.Ususarios.AtualizarPerfil;
using SGFBA.Application.UseCases.Ususarios.BuscarCoordenadoresOrientadores;
using SGFBA.Application.UseCases.Ususarios.BuscarCoordenadoresOrientadoresAtivos;
using SGFBA.Application.UseCases.Ususarios.BuscarPorId;
using SGFBA.Application.UseCases.Ususarios.BuscarTodos;
using SGFBA.Application.UseCases.Ususarios.BuscarTodosAtivos;
using SGFBA.Application.UseCases.Ususarios.Desativar;
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
        services.AddScoped<IBuscarUsuarioPorIdUseCase, BuscarUsuarioPorIdUseCase>();
        services.AddScoped<IBuscarTodosAtivosUseCase, BuscarTodosAtivosUseCase>();
        services.AddScoped<IBuscarTodosUseCase, BuscarTodosUseCase>();
        services.AddScoped<IAtualizarPerfilUseCase, AtualizarPerfilUseCase>();
        services.AddScoped<IAtualizarUsuarioUseCase, AtualizarUsuarioUseCase>();
        services.AddScoped<IDesativarUsuarioUseCase, DesativarUsuarioUseCase>();
        services.AddScoped<IAlterarSenhaUsuarioUseCase, AlterarSenhaUsuarioUseCase>();
        services.AddScoped<IBuscarTodosEstudantesUseCase, BuscarTodosEstudantesUseCase>();
        services.AddScoped<IBuscarTodosEstudantesAtivosUseCase, BuscarTodosEstudantesAtivosUseCase>();
        services.AddScoped<IBuscarEstudanteAtivoPorIdUseCase, BuscarEstudanteAtivoPorIdUseCase>();
        services.AddScoped<IBuscarEstudantePorIdeUseCase, BuscarEstudantePorIdeUseCase>();
        services.AddScoped<IAtualizarEstudanteUseCase, AtualizarEstudanteUseCase>();
        services.AddScoped<IDesativarEstudanteUseCase, DesativarEstudanteUseCase>();
        services.AddScoped<IAtualizarFichaUseCase, AtualizarFichaUseCase>();
        services.AddScoped<ICancelarFichaUseCase, CancelarFichaUseCase>();
        services.AddScoped<IBuscarTodasFichasAtivasUseCase, BuscarTodasFichasAtivasUseCase>();
        services.AddScoped<IBuscarTodasFichasUseCase, BuscarTodasFichasUseCase>();
        services.AddScoped<IBuscarFichaAtivaPorIdUseCase, BuscarFichaAtivaPorIdUseCase>();
        services.AddScoped<IBuscarPorIdUseCase, BuscarPorIdUseCase>();
        services.AddScoped<IAtualizarAcaoUseCase, AtualizarAcaoUseCase>();
        services.AddScoped<IBuscarTodasAcoesUseCase, BuscarTodasAcoesUseCase>();
        services.AddScoped<IBuscarAcaoFichaPorIdUseCase, BuscarAcaoFichaPorIdUseCase>();
        services.AddScoped<IBuscarCoordenadoresOrientadoresAtivosUseCase, BuscarCoordenadoresOrientadoresAtivosUseCase>();
        services.AddScoped<IBuscarCoordenadoresOrientadoresUseCase, BuscarCoordenadoresOrientadoresUseCase>();
    }
}
