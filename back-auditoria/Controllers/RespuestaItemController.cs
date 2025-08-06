using auditoriaBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_auditoria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RespuestaItemController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public RespuestaItemController(EncuestaDbContext context)
        {
            _context = context;
        }

        // GET: api/respuestaitem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RespuestaItem>>> GetRespuestaItems()
        {
            return await _context.RespuestaItems
                .Include(r => r.IdItemNavigation)
                .ToListAsync();
        }

        // GET: api/respuestaitem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RespuestaItem>> GetRespuestaItem(int id)
        {
            var respuestaItem = await _context.RespuestaItems
                .Include(r => r.IdItemNavigation)
                .FirstOrDefaultAsync(r => r.IdRespuestaItem == id);

            if (respuestaItem == null)
                return NotFound();

            return respuestaItem;
        }

        // POST: api/respuestaitem
        [HttpPost]
        public async Task<ActionResult<RespuestaItem>> CrearRespuestaItem(RespuestaItem respuestaItem)
        {
            _context.RespuestaItems.Add(respuestaItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRespuestaItem), new { id = respuestaItem.IdRespuestaItem }, respuestaItem);
        }

        // PUT: api/respuestaitem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarRespuestaItem(int id, RespuestaItem respuestaItem)
        {
            if (id != respuestaItem.IdRespuestaItem)
                return BadRequest();

            _context.Entry(respuestaItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.RespuestaItems.Any(e => e.IdRespuestaItem == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/respuestaitem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarRespuestaItem(int id)
        {
            var respuestaItem = await _context.RespuestaItems.FindAsync(id);
            if (respuestaItem == null)
                return NotFound();

            _context.RespuestaItems.Remove(respuestaItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
