using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using auditoriaBackend.Models;

namespace back_auditoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntaItemController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public PreguntaItemController(EncuestaDbContext context)
        {
            _context = context;
        }

        // GET: api/PreguntaItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreguntaItem>>> GetPreguntaItems()
        {
            return await _context.PreguntaItems
                                 .Include(p => p.IdItemNavigation)
                                 .Include(p => p.IdPreguntaNavigation)
                                 .ToListAsync();
        }

        // GET: api/PreguntaItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreguntaItem>> GetPreguntaItem(int id)
        {
            var preguntaItem = await _context.PreguntaItems
                                             .Include(p => p.IdItemNavigation)
                                             .Include(p => p.IdPreguntaNavigation)
                                             .FirstOrDefaultAsync(p => p.IdPreguntaItem == id);

            if (preguntaItem == null)
            {
                return NotFound();
            }

            return preguntaItem;
        }

        // POST: api/PreguntaItem
        [HttpPost]
        public async Task<ActionResult<PreguntaItem>> PostPreguntaItem(PreguntaItem preguntaItem)
        {
            _context.PreguntaItems.Add(preguntaItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPreguntaItem), new { id = preguntaItem.IdPreguntaItem }, preguntaItem);
        }

        // DELETE: api/PreguntaItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreguntaItem(int id)
        {
            var preguntaItem = await _context.PreguntaItems.FindAsync(id);
            if (preguntaItem == null)
            {
                return NotFound();
            }

            _context.PreguntaItems.Remove(preguntaItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
