using Microsoft.EntityFrameworkCore;
using SGFBA.Domain.Entities;

namespace SGFBA.Infrastructure.DataAccess;

internal class SGFBADbContext : DbContext
{
    public SGFBADbContext(DbContextOptions options): base(options) {}

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Estudante> Estudantes { get; set; }
    public DbSet<Ficha> Fichas { get; set; }
    public DbSet<Acao> Acoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>().ToTable("usuarios");
        modelBuilder.Entity<Estudante>().ToTable("estudantes");
        modelBuilder.Entity<Ficha>().ToTable("fichas");
        modelBuilder.Entity<Acao>().ToTable("acoes");
    }
}
