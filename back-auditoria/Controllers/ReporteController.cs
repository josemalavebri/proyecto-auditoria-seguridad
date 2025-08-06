using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using auditoriaBackend.Models;


namespace back_auditoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly EncuestaDbContext _context;
 
        public ReporteController(EncuestaDbContext context)
        {
            _context = context;
        }

        // GET: api/Reporte
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reporte>>> GetReportes()
        {
            var reporte = await _context.Reportes
                .Include(r => r.IdSeguimientoNavigation)
                .ToListAsync();
            return Ok(reporte);
        }

        // GET: api/Reporte/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reporte>> GetReporte(int id)
        {
            var reporte = await _context.Reportes
                .Include(r => r.IdSeguimientoNavigation)
                .FirstOrDefaultAsync(r => r.IdReporte == id);

            if (reporte == null)
            {
                return NotFound();
            }

            return Ok(reporte);
        }

        // POST: api/Reporte
        [HttpPost]
        public async Task<ActionResult<Reporte>> PostReporte(Reporte reporte)
        {
            _context.Reportes.Add(reporte);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReporte), new { id = reporte.IdReporte }, reporte);
        }

        // DELETE: api/Reporte/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReporte(int id)
        {
            var reporte = await _context.Reportes.FindAsync(id);
            if (reporte == null)
            {
                return NotFound();
            }

            _context.Reportes.Remove(reporte);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
