using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using auditoriaBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_auditoria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncuestaController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public EncuestaController(EncuestaDbContext context)
        {
            _context = context;
        }

        // GET: api/Encuesta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Encuestum>>> GetEncuestas()
        {
            var encuestas = await _context.Encuesta
                .Include(e => e.IdAuditoriaNavigation)    // Trae datos de Auditorium
                .Include(e => e.IdPersonaNavigation)      // Trae datos de Persona
                .Include(e => e.PreguntaEncuesta)         // Trae PreguntaEncuestum
                .ToListAsync();

            return Ok(encuestas);
        }

        // GET: api/Encuesta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Encuestum>> GetEncuesta(int id)
        {
            var encuesta = await _context.Encuesta
                .Include(e => e.IdAuditoriaNavigation)
                .Include(e => e.IdPersonaNavigation)
                .Include(e => e.PreguntaEncuesta)
                .FirstOrDefaultAsync(e => e.IdEncuesta == id);

            if (encuesta == null)
                return NotFound();

            return Ok(encuesta);
        }

        // POST: api/Encuesta
        [HttpPost]
        public async Task<ActionResult<Encuestum>> CreateEncuesta(Encuestum encuesta)
        {
            _context.Encuesta.Add(encuesta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEncuesta), new { id = encuesta.IdEncuesta }, encuesta);
        }

        // PUT: api/Encuesta/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEncuesta(int id, Encuestum encuesta)
        {
            if (id != encuesta.IdEncuesta)
                return BadRequest("El id no coincide");

            _context.Entry(encuesta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EncuestaExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Encuesta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEncuesta(int id)
        {
            var encuesta = await _context.Encuesta.FindAsync(id);
            if (encuesta == null)
                return NotFound();

            _context.Encuesta.Remove(encuesta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EncuestaExists(int id)
        {
            return _context.Encuesta.Any(e => e.IdEncuesta == id);
        }
    }
}
