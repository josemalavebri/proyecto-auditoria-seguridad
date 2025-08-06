using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using auditoriaBackend.Models;


namespace back_auditoria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeccionController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public SeccionController(EncuestaDbContext context)
        {
            _context = context;
        }

        // GET: api/seccion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seccion>>> GetSecciones()
        {
            var seccion = await _context.Seccions
               .Include(s => s.Pregunta)
               .ToListAsync();
            return Ok(seccion);
        }

        // GET: api/seccion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seccion>> GetSeccion(int id)
        {
            var seccion = await _context.Seccions
                .Include(s => s.Pregunta)
                .FirstOrDefaultAsync(s => s.IdSeccion == id);

            if (seccion == null)
                return NotFound();

            return Ok(seccion);
        }

        // POST: api/seccion
        [HttpPost]
        public async Task<ActionResult<Seccion>> CrearSeccion(Seccion seccion)
        {
            _context.Seccions.Add(seccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSeccion), new { id = seccion.IdSeccion }, seccion);
        }

        // PUT: api/seccion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarSeccion(int id, Seccion seccion)
        {
            if (id != seccion.IdSeccion)
                return BadRequest();

            _context.Entry(seccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Seccions.Any(e => e.IdSeccion == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/seccion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarSeccion(int id)
        {
            var seccion = await _context.Seccions.FindAsync(id);
            if (seccion == null)
                return NotFound();

            _context.Seccions.Remove(seccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
