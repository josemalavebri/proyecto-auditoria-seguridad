using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_auditoria.Data;
using back_auditoria.Models;

namespace back_auditoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntaItemsController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public PreguntaItemsController(EncuestaDbContext context)
        {
            _context = context;
        }

        // GET: api/PreguntaItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreguntaItem>>> GetPreguntaItem()
        {
            return await _context.PreguntaItem.ToListAsync();
        }

        // GET: api/PreguntaItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreguntaItem>> GetPreguntaItem(int id)
        {
            var preguntaItem = await _context.PreguntaItem.FindAsync(id);

            if (preguntaItem == null)
            {
                return NotFound();
            }

            return preguntaItem;
        }

        // PUT: api/PreguntaItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreguntaItem(int id, PreguntaItem preguntaItem)
        {
            if (id != preguntaItem.IdPreguntaItem)
            {
                return BadRequest();
            }

            _context.Entry(preguntaItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreguntaItemExists(id))
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

        // POST: api/PreguntaItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PreguntaItem>> PostPreguntaItem(PreguntaItem preguntaItem)
        {
            _context.PreguntaItem.Add(preguntaItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreguntaItem", new { id = preguntaItem.IdPreguntaItem }, preguntaItem);
        }

        // DELETE: api/PreguntaItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreguntaItem(int id)
        {
            var preguntaItem = await _context.PreguntaItem.FindAsync(id);
            if (preguntaItem == null)
            {
                return NotFound();
            }

            _context.PreguntaItem.Remove(preguntaItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PreguntaItemExists(int id)
        {
            return _context.PreguntaItem.Any(e => e.IdPreguntaItem == id);
        }
    }
}
