using auditoriaBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_auditoria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PreguntaEncuestaController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public PreguntaEncuestaController(EncuestaDbContext context)
        {
            _context = context;
        }

        // GET: api/preguntaencuesta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreguntaEncuestum>>> GetPreguntaEncuestas()
        {
            return await _context.PreguntaEncuesta
                .Include(p => p.IdEncuestaNavigation)
                .Include(p => p.IdPreguntaNavigation)
                .ToListAsync();
        }

        // GET: api/preguntaencuesta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreguntaEncuestum>> GetPreguntaEncuesta(int id)
        {
            var preguntaEncuesta = await _context.PreguntaEncuesta
                .Include(p => p.IdEncuestaNavigation)
                .Include(p => p.IdPreguntaNavigation)
                .FirstOrDefaultAsync(p => p.IdPreguntaEncuesta == id);

            if (preguntaEncuesta == null)
                return NotFound();

            return preguntaEncuesta;
        }

        // POST: api/preguntaencuesta
        [HttpPost]
        public async Task<ActionResult<PreguntaEncuestum>> CrearPreguntaEncuesta(PreguntaEncuestum preguntaEncuesta)
        {
            _context.PreguntaEncuesta.Add(preguntaEncuesta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPreguntaEncuesta), new { id = preguntaEncuesta.IdPreguntaEncuesta }, preguntaEncuesta);
        }

        // PUT: api/preguntaencuesta/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPreguntaEncuesta(int id, PreguntaEncuestum preguntaEncuesta)
        {
            if (id != preguntaEncuesta.IdPreguntaEncuesta)
                return BadRequest();

            _context.Entry(preguntaEncuesta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.PreguntaEncuesta.Any(p => p.IdPreguntaEncuesta == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/preguntaencuesta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPreguntaEncuesta(int id)
        {
            var preguntaEncuesta = await _context.PreguntaEncuesta.FindAsync(id);
            if (preguntaEncuesta == null)
                return NotFound();

            _context.PreguntaEncuesta.Remove(preguntaEncuesta);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
