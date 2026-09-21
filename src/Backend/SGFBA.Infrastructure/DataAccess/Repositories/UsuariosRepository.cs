using Microsoft.EntityFrameworkCore;
using SGFBA.Domain.Entities;
using SGFBA.Domain.Repositories.Usuarios;

namespace SGFBA.Infrastructure.DataAccess.Repositories;

internal class UsuariosRepository : IReadOnlyUsuarioRepository, IWriteOnlyUsuariosRepository
{
    private readonly SGFBADbContext _dbContext;

    public UsuariosRepository(SGFBADbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Adicionar(Usuario usuario) => await _dbContext.Usuarios.AddAsync(usuario);

    public async Task<Usuario?> BuscarPorEmail(string email)
    {
        return await _dbContext.Usuarios.AsNoTracking().FirstOrDefaultAsync(usuario => usuario.Ativo && usuario.Email.Equals(email));
    }

    public async Task<Usuario?> BuscarPorId(long id)
    {
        return await _dbContext.Usuarios.AsNoTracking().FirstOrDefaultAsync(usuario => usuario.Ativo && usuario.Id.Equals(id));
    }

    public async Task<bool> BuscarPorMatricula(string matricula)
    {
        return await _dbContext.Usuarios.AsNoTracking().AnyAsync(usuario => usuario.Ativo && usuario.Matricula.Equals(matricula));
    }
}
