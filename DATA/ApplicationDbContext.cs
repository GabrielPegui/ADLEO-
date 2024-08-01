using Microsoft.EntityFrameworkCore;

namespace ADLEO
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Maestro> Maestros { get; set; }  // Añadido para la tabla de maestros
    }

    public class Estudiante
    {
        public int Id { get; set; }
        public string n_estudiante { get; set; } = string.Empty;
        public string Maestro { get; set; } = string.Empty;
        public string Curso { get; set; } = string.Empty;
        public string Sesion { get; set; } = string.Empty;
    }

    public class Maestro
    {
        public int Id { get; set; }  
        public string n_maestro { get; set; } = string.Empty;
        public string maestro_curso { get; set; } = string.Empty;
        public string maestro_sesion { get; set; } = string.Empty;
    }
}