using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using auditoriaBackend.Models;


namespace back_auditoria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public ItemController(EncuestaDbContext context)
        {
            _context = context;
        }

        // GET: api/Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            var item = await _context.Items
                .Include(i => i.IdPreguntaNavigation)
                .Include(i => i.PreguntaItems)
                .Include(i => i.RespuestaItems)
                .ToListAsync();

            return Ok(item);
        }

        // GET: api/Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.Items
                .Include(i => i.IdPreguntaNavigation)
                .Include(i => i.PreguntaItems)
                .Include(i => i.RespuestaItems)
                .FirstOrDefaultAsync(i => i.IdItem == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // POST: api/Item
        [HttpPost]
        public async Task<ActionResult<Item>> CreateItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItem), new { id = item.IdItem }, item);
        }

        // PUT: api/Item/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, Item item)
        {
            if (id != item.IdItem)
                return BadRequest("El id no coincide");

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(i => i.IdItem == id);
        }
    }
}
