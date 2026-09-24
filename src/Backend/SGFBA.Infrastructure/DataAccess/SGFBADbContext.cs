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
        modelBuilder.Entity<Usuario>().HasQueryFilter(u => u.Ativo);

        modelBuilder.Entity<Estudante>()
            .HasOne(e => e.Usuario)
            .WithMany()
            .HasForeignKey(e => e.UserId);
        modelBuilder.Entity<Estudante>().ToTable("estudantes");
        modelBuilder.Entity<Estudante>().HasQueryFilter(e => e.Ativo);

        modelBuilder.Entity<Ficha>()
            .HasOne(f => f.Usuario)
            .WithMany(u => u.Fichas)
            .HasForeignKey(f => f.IdUsuario);
        modelBuilder.Entity<Ficha>()
            .HasOne(f => f.Estudante)
            .WithMany(e => e.Fichas)
            .HasForeignKey(e => e.IdEstudante);
        modelBuilder.Entity<Ficha>().ToTable("fichas");
        modelBuilder.Entity<Ficha>().HasQueryFilter(f => f.Status != Domain.Enums.StatusFicha.Cancelada);


        modelBuilder.Entity<Acao>()
            .HasOne(a => a.Ficha)
            .WithMany(f => f.Acoes)
            .HasForeignKey(e => e.IdFicha);
        modelBuilder.Entity<Acao>().ToTable("acoes");
    }
}
