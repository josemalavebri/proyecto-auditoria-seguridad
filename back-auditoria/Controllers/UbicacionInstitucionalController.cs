using auditoriaBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_auditoria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UbicacionInstitucionalController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public UbicacionInstitucionalController(EncuestaDbContext context)
        {
            _context = context;
        }

        // GET: api/ubicacioninstitucional
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UbicacionInstitucional>>> GetUbicacionInstitucionals()
        {
            var lista = await _context.UbicacionInstitucionals
                   .Include(u => u.IdDepartamentoNavigation)
                   .Include(u => u.IdFacultadNavigation)
                   .Include(u => u.IdUbicacionNavigation)
                   .Include(u => u.Auditoria)
                   .ToListAsync();
            return Ok(lista);
        }

        // GET: api/ubicacioninstitucional/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UbicacionInstitucional>> GetUbicacionInstitucional(int id)
        {
            var ubicacionInstitucional = await _context.UbicacionInstitucionals
                .Include(u => u.IdDepartamentoNavigation)
                .Include(u => u.IdFacultadNavigation)
                .Include(u => u.IdUbicacionNavigation)
                .Include(u => u.Auditoria)
                .FirstOrDefaultAsync(u => u.IdUbicacionInstitucional == id);

            if (ubicacionInstitucional == null)
                return NotFound();

            return ubicacionInstitucional;
        }

        // POST: api/ubicacioninstitucional
        [HttpPost]
        public async Task<ActionResult<UbicacionInstitucional>> CrearUbicacionInstitucional(UbicacionInstitucional ubicacionInstitucional)
        {
            _context.UbicacionInstitucionals.Add(ubicacionInstitucional);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUbicacionInstitucional), new { id = ubicacionInstitucional.IdUbicacionInstitucional }, ubicacionInstitucional);
        }

        // PUT: api/ubicacioninstitucional/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUbicacionInstitucional(int id, UbicacionInstitucional ubicacionInstitucional)
        {
            if (id != ubicacionInstitucional.IdUbicacionInstitucional)
                return BadRequest();

            _context.Entry(ubicacionInstitucional).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.UbicacionInstitucionals.Any(e => e.IdUbicacionInstitucional == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/ubicacioninstitucional/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUbicacionInstitucional(int id)
        {
            var ubicacionInstitucional = await _context.UbicacionInstitucionals.FindAsync(id);
            if (ubicacionInstitucional == null)
                return NotFound();

            _context.UbicacionInstitucionals.Remove(ubicacionInstitucional);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
