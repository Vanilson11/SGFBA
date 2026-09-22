using Microsoft.EntityFrameworkCore;
using SGFBA.Domain.Entities;
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

    public async Task<Usuario?> BuscarPorId(long id)
    {
        return await _dbContext.Usuarios.AsNoTracking().FirstOrDefaultAsync(usuario => usuario.Ativo && usuario.Id.Equals(id));
    }

    public async Task<bool> BuscarPorMatricula(string matricula)
    {
        return await _dbContext.Usuarios.AsNoTracking().AnyAsync(usuario => usuario.Ativo && usuario.Matricula.Equals(matricula));
    }

    public async Task<List<Usuario>> BuscarTodos()
    {
        return await _dbContext.Usuarios.AsNoTracking().ToListAsync();
    }

    public async Task<List<Usuario>> BuscarTodosAtivos()
    {
        return await _dbContext.Usuarios.AsNoTracking().Where(usuario => usuario.Ativo).ToListAsync();
    }

    public void Atualizar(Usuario usuario)
    {
        _dbContext.Usuarios.Update(usuario);
    }
}
