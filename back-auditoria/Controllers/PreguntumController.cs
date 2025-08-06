using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using auditoriaBackend.Models;

namespace back_auditoria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PreguntumController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public PreguntumController(EncuestaDbContext context)
        {
            _context = context;
        }

        // GET: api/Preguntum
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Preguntum>>> GetPreguntas()
        {
            var preguntas = await _context.Pregunta
                .Include(p => p.IdSeccionNavigation)
                .Include(p => p.Items)
                .Include(p => p.PreguntaEncuesta)
                .Include(p => p.PreguntaItems)
                .ToListAsync();

            return Ok(preguntas);
        }

        // GET: api/Preguntum/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Preguntum>> GetPregunta(int id)
        {
            var pregunta = await _context.Pregunta
                .Include(p => p.IdSeccionNavigation)
                .Include(p => p.Items)
                .Include(p => p.PreguntaEncuesta)
                .Include(p => p.PreguntaItems)
                .FirstOrDefaultAsync(p => p.IdPregunta == id);

            if (pregunta == null)
            {
                return NotFound();
            }

            return Ok(pregunta);
        }

        // POST: api/Preguntum
        [HttpPost]
        public async Task<ActionResult<Preguntum>> PostPregunta(Preguntum pregunta)
        {
            _context.Pregunta.Add(pregunta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPregunta), new { id = pregunta.IdPregunta }, pregunta);
        }

        // PUT: api/Preguntum/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPregunta(int id, Preguntum pregunta)
        {
            if (id != pregunta.IdPregunta)
            {
                return BadRequest();
            }

            _context.Entry(pregunta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Pregunta.Any(p => p.IdPregunta == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Preguntum/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePregunta(int id)
        {
            var pregunta = await _context.Pregunta.FindAsync(id);
            if (pregunta == null)
            {
                return NotFound();
            }

            _context.Pregunta.Remove(pregunta);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
