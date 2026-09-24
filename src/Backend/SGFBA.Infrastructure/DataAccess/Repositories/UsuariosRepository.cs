using Microsoft.EntityFrameworkCore;
using SGFBA.Domain.Entities;
using SGFBA.Domain.Enums;
using SGFBA.Domain.Repositories.Usuarios;

namespace SGFBA.Infrastructure.DataAccess.Repositories;

internal class UsuariosRepository : IReadOnlyUsuarioRepository, IWriteOnlyUsuariosRepository, IUpdateOnlyUsuariosRepository
{
    private readonly SGFBADbContext _dbContext;

    public UsuariosRepository(SGFBADbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Adicionar(Usuario usuario) => await _dbContext.Usuarios.AddAsync(usuario);

    async Task<Usuario?> IReadOnlyUsuarioRepository.BuscarPorEmail(string email)
    {
        return await _dbContext.Usuarios.AsNoTracking().FirstOrDefaultAsync(usuario => usuario.Ativo && usuario.Email.Equals(email));
    }

    async Task<bool> IUpdateOnlyUsuariosRepository.BuscarPorEmail(string email)
    {
        return await _dbContext.Usuarios.AsNoTracking().AnyAsync(usuario => usuario.Ativo && usuario.Email.Equals(email));
    }

    async Task<Usuario?> IReadOnlyUsuarioRepository.BuscarPorId(long id)
    {
        return await _dbContext.Usuarios.AsNoTracking().FirstOrDefaultAsync(usuario => usuario.Ativo && usuario.Id.Equals(id));
    }

    async Task<Usuario?> IUpdateOnlyUsuariosRepository.BuscarPorId(long id)
    {
        return await _dbContext.Usuarios.FirstOrDefaultAsync(usuario => usuario.Ativo && usuario.Id.Equals(id));
    }

    public async Task<bool> BuscarPorMatricula(string matricula)
    {
        return await _dbContext.Usuarios.AsNoTracking().AnyAsync(usuario => usuario.Ativo && usuario.Matricula.Equals(matricula));
    }

    public async Task<List<Usuario>> BuscarTodos()
    {
        return await _dbContext.Usuarios.AsNoTracking().IgnoreQueryFilters().ToListAsync();
    }

    public async Task<List<Usuario>> BuscarTodosAtivos()
    {
        return await _dbContext.Usuarios.AsNoTracking().ToListAsync();
    }

    public void Atualizar(Usuario usuario)
    {
        _dbContext.Usuarios.Update(usuario);
    }

    public async Task<bool> Desativar(Usuario usuario)
    {
        var usuarioExiste = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id.Equals(usuario.Id));

        if (usuarioExiste is null) return false;

        usuarioExiste.Ativo = false;

        return true;
    }

    public async Task<List<Usuario>> BuscarCoordenadoresOrientadoresAtivos()
    {
        return await _dbContext.Usuarios.AsNoTracking()
            .Where(usuario => usuario.Cargo.Equals(CargoUsuario.CoordenadorPedagogico) || usuario.Cargo.Equals(CargoUsuario.OrientadorEducacional))
            .Include(usuario => usuario.Fichas).ThenInclude(ficha => ficha.Acoes)
            .ToListAsync();
    }

    public async Task<List<Usuario>> BuscarCoordenadoresOrientadores()
    {
        return await _dbContext.Usuarios.AsNoTracking()
            .IgnoreQueryFilters()
            .Where(usuario => usuario.Cargo.Equals(CargoUsuario.CoordenadorPedagogico) || usuario.Cargo.Equals(CargoUsuario.OrientadorEducacional))
            .Include(usuario => usuario.Fichas).ThenInclude(ficha => ficha.Acoes)
            .ToListAsync();
    }

    public async Task<Usuario?> BuscarCoordenadorOrientadorAtivoPorId(long id)
    {
        return await _dbContext.Usuarios.AsNoTracking()
            .Where(usuario => usuario.Cargo.Equals(CargoUsuario.CoordenadorPedagogico) || usuario.Cargo.Equals(CargoUsuario.OrientadorEducacional))
            .Include(usuario => usuario.Fichas).ThenInclude(ficha => ficha.Acoes)
            .FirstOrDefaultAsync(usuario => usuario.Id.Equals(id));
    }

    public async Task<Usuario?> BuscarCoordenadorOrientadorPorId(long id)
    {
        return await _dbContext.Usuarios.AsNoTracking()
            .IgnoreQueryFilters()
            .Where(usuario => usuario.Cargo.Equals(CargoUsuario.CoordenadorPedagogico) || usuario.Cargo.Equals(CargoUsuario.OrientadorEducacional))
            .Include(usuario => usuario.Fichas).ThenInclude(ficha => ficha.Acoes)
            .FirstOrDefaultAsync(usuario => usuario.Id.Equals(id));
    }
}
