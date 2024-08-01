namespace ADLEO.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string n_estudiante { get; set; } = string.Empty;
        public string Maestro { get; set; } = string.Empty; // Puede ser manejado por otro controlador si es necesario
        public string Curso { get; set; } = string.Empty;
        public string Sesion { get; set; } = string.Empty;
    }

    public class EstudianteInputModel
    {
        public string n_estudiante { get; set; } = string.Empty;
        public string Curso { get; set; } = string.Empty;
        public string Sesion { get; set; } = string.Empty;
    }
}