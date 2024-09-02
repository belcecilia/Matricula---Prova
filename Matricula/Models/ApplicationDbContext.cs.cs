using Microsoft.EntityFrameworkCore;

namespace Matricula.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(s => s.Id); // Define 'Id' como a chave primária

            modelBuilder.Entity<Student>()
                .Property(s => s.CPF)
                .HasMaxLength(14); // Define o comprimento máximo do CPF, ajustado para formatos comuns (com ou sem pontos e traço)

            modelBuilder.Entity<Student>()
                .Property(s => s.Email)
                .HasMaxLength(255); // Define o comprimento máximo do Email

            modelBuilder.Entity<Student>()
                .Property(s => s.Telefone)
                .HasMaxLength(20); // Define o comprimento máximo do Telefone

            modelBuilder.Entity<Student>()
                .Property(s => s.Curso)
                .HasMaxLength(100); // Define o comprimento máximo do Curso

            modelBuilder.Entity<Student>()
                .Property(s => s.Turno)
                .HasMaxLength(100); // Define o comprimento máximo do Turno
        }
    }
}
