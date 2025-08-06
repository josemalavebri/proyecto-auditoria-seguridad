using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using auditoriaBackend.Models;

namespace back_auditoria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public PersonaController(EncuestaDbContext context)
        {
            _context = context;
        }

        // GET: api/persona
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            var persona = await _context.Personas
                .Include(p => p.IdRolNavigation)
                .ToListAsync();
            return Ok(persona);
        }

        // GET: api/persona/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            var persona = await _context.Personas
                .Include(p => p.IdRolNavigation)
                .FirstOrDefaultAsync(p => p.IdPersona == id);

            if (persona == null)
                return NotFound();

            return Ok(persona);
        }

        // POST: api/persona
        [HttpPost]
        public async Task<ActionResult<Persona>> CrearPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersona), new { id = persona.IdPersona }, persona);
        }

        // PUT: api/persona/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPersona(int id, Persona persona)
        {
            if (id != persona.IdPersona)
                return BadRequest();

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Personas.Any(e => e.IdPersona == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/persona/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
                return NotFound();

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
