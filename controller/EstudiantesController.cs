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
    public class EstudiantesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EstudiantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiantes()
        {
            var estudiantes = await _context.Estudiantes.ToListAsync();
            return Ok(estudiantes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            // Buscar el estudiante por ID
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound(); // Estudiante no encontrado
            }

            // Eliminar el estudiante
            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();

            return NoContent(); // Respuesta exitosa sin contenido
        }
    }
}