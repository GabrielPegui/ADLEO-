using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADLEO.Models;

namespace ADLEO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InscripcionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InscripcionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtiene todos los estudiantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiantes()
        {
            var estudiantes = await _context.Estudiantes.ToListAsync();
            return Ok(estudiantes);
        }

        // Agrega un nuevo estudiante
        [HttpPost]
        public async Task<IActionResult> PostEstudiante([FromForm] EstudianteInputModel input)
        {
            // Buscar el maestro correspondiente
            var maestro = await _context.Maestros
                .Where(m => m.maestro_curso == input.Curso && m.maestro_sesion == input.Sesion)
                .FirstOrDefaultAsync();

            if (maestro == null)
            {
                return BadRequest("No se encontró un maestro para el curso y la sesión seleccionados.");
            }

            var estudiante = new Estudiante
            {
                n_estudiante = input.n_estudiante,
                Maestro = maestro.n_maestro, // Asignar el maestro encontrado
                Curso = input.Curso,
                Sesion = input.Sesion
            };

            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();

            // Redirige a la página HTML después de la inserción
            return Redirect("/estudiantes"); // Redirige a la página HTML de estudiantes
        }
    }

    // Modelo para la entrada del estudiante
    public class EstudianteInputModel
    {
        public string n_estudiante { get; set; } = string.Empty;
        public string Curso { get; set; } = string.Empty;
        public string Sesion { get; set; } = string.Empty;

         public string Maestro { get; set; } = string.Empty;

    }
}