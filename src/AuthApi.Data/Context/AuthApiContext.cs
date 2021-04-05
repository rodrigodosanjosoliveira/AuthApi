using AuthApi.Domain.Entities;
using AuthApi.Domain.ValueTypes;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Data.Context
{
    public class AuthApiContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AuthApiDb;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuario>(
                p =>
                {
                    p.HasKey("Id");
                    p.Property(e => e.Nome);
                    p.Property(e => e.Email);
                    p.Property(e => e.Senha);
                }
            );

            modelBuilder.Entity<Usuario>().OwnsMany<Telefone>("Telefones", t =>
            {
                t.WithOwner()
                    .HasForeignKey(ca => ca.UsuarioId)
                    .HasConstraintName("FK_Usuarios");
                t.Property(ca => ca.Ddd);
                t.Property(ca => ca.Numero);
                t.HasKey("UsuarioId", "Ddd", "Numero");
            });

        }
    }
}
