using Microsoft.EntityFrameworkCore;
using LaboratorioF.models;

namespace LaboratorioF.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options) { }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Livro>()
                .HasMany(l => l.Emprestimos)
                .WithOne(e => e.Livro)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
