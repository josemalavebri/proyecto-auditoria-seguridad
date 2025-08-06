using auditoriaBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_auditoria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguimientoController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public SeguimientoController(EncuestaDbContext context)
        {
            _context = context;
        }

        // GET: api/seguimiento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seguimiento>>> GetSeguimientos()
        {
            return await _context.Seguimientos
                .Include(s => s.IdRespuestaItemNavigation)
                .Include(s => s.Reportes)
                .ToListAsync();
        }

        // GET: api/seguimiento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seguimiento>> GetSeguimiento(int id)
        {
            var seguimiento = await _context.Seguimientos
                .Include(s => s.IdRespuestaItemNavigation)
                .Include(s => s.Reportes)
                .FirstOrDefaultAsync(s => s.IdSeguimiento == id);

            if (seguimiento == null)
                return NotFound();

            return seguimiento;
        }

        // POST: api/seguimiento
        [HttpPost]
        public async Task<ActionResult<Seguimiento>> CrearSeguimiento(Seguimiento seguimiento)
        {
            _context.Seguimientos.Add(seguimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSeguimiento), new { id = seguimiento.IdSeguimiento }, seguimiento);
        }

        // PUT: api/seguimiento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarSeguimiento(int id, Seguimiento seguimiento)
        {
            if (id != seguimiento.IdSeguimiento)
                return BadRequest();

            _context.Entry(seguimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Seguimientos.Any(e => e.IdSeguimiento == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/seguimiento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarSeguimiento(int id)
        {
            var seguimiento = await _context.Seguimientos.FindAsync(id);
            if (seguimiento == null)
                return NotFound();

            _context.Seguimientos.Remove(seguimiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
