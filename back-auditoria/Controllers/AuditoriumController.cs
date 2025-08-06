using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using auditoriaBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_auditoria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditoriumController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public AuditoriumController(EncuestaDbContext context)
        {
            _context = context;
        }

        // GET: api/Auditorium
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Auditorium>>> GetAuditoriums()
        {
            var auditoriums = await _context.Auditoria
                .Include(a => a.Encuesta)
                .Include(a => a.IdUbicacionInstitucionalNavigation)
                .ToListAsync();

            return Ok(auditoriums);
        }

        // GET: api/Auditorium/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Auditorium>> GetAuditorium(int id)
        {
            var auditorium = await _context.Auditoria
                .Include(a => a.Encuesta)
                .Include(a => a.IdUbicacionInstitucionalNavigation)
                .FirstOrDefaultAsync(a => a.IdAuditoria == id);

            if (auditorium == null)
                return NotFound();

            return Ok(auditorium);
        }

        // POST: api/Auditorium
        [HttpPost]
        public async Task<ActionResult<Auditorium>> CreateAuditorium(Auditorium auditorium)
        {
            _context.Auditoria.Add(auditorium);
            await _context.SaveChangesAsync();

            // Retorna el objeto creado con su URI
            return CreatedAtAction(nameof(GetAuditorium), new { id = auditorium.IdAuditoria }, auditorium);
        }

        // PUT: api/Auditorium/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuditorium(int id, Auditorium auditorium)
        {
            if (id != auditorium.IdAuditoria)
                return BadRequest("El ID no coincide");

            _context.Entry(auditorium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditoriumExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent(); // 204, actualización exitosa pero sin contenido en respuesta
        }

        // DELETE: api/Auditorium/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuditorium(int id)
        {
            var auditorium = await _context.Auditoria.FindAsync(id);
            if (auditorium == null)
                return NotFound();

            _context.Auditoria.Remove(auditorium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuditoriumExists(int id)
        {
            return _context.Auditoria.Any(a => a.IdAuditoria == id);
        }
    }
}
