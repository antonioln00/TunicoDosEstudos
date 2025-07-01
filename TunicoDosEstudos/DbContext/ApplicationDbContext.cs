using Microsoft.EntityFrameworkCore;
using TunicoDosEstudos.Models;

namespace TunicoDosEstudos;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Rotina> Rotina { get; set; }
    public DbSet<Tarefa> Tarefa { get; set; }
    public DbSet<PerfilUsuario> PerfilUsuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().HasKey(e => e.Id);
        modelBuilder.Entity<Rotina>().HasKey(e => e.Id);
        modelBuilder.Entity<Tarefa>().HasKey(e => e.Id);
        modelBuilder.Entity<PerfilUsuario>().HasKey(e => e.Id);

        modelBuilder.Entity<PerfilUsuario>()
            .HasOne(e => e.Usuario)
            .WithOne()
            .HasForeignKey<PerfilUsuario>(e => e.IdUsuario);

        modelBuilder.Entity<Rotina>()
            .HasOne(e => e.Usuario)
            .WithMany(e => e.Rotinas)
            .HasForeignKey(e => e.IdUsuario);

        modelBuilder.Entity<Tarefa>()
            .HasOne(e => e.Rotina)
            .WithMany(e => e.Tarefas)
            .HasForeignKey(e => e.IdRotina);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql("DefaultConnection");

        base.OnConfiguring(optionsBuilder); ;
    }
}