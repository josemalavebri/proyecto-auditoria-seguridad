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
    public class RespuestaItemsController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public RespuestaItemsController(EncuestaDbContext context)
        {
            _context = context;
        }

        // GET: api/RespuestaItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RespuestaItem>>> GetRespuestaItem()
        {
            return await _context.RespuestaItem.ToListAsync();
        }

        // GET: api/RespuestaItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RespuestaItem>> GetRespuestaItem(int id)
        {
            var respuestaItem = await _context.RespuestaItem.FindAsync(id);

            if (respuestaItem == null)
            {
                return NotFound();
            }

            return respuestaItem;
        }

        // PUT: api/RespuestaItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRespuestaItem(int id, RespuestaItem respuestaItem)
        {
            if (id != respuestaItem.IdRespuestaItem)
            {
                return BadRequest();
            }

            _context.Entry(respuestaItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RespuestaItemExists(id))
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

        // POST: api/RespuestaItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RespuestaItem>> PostRespuestaItem(RespuestaItem respuestaItem)
        {
            _context.RespuestaItem.Add(respuestaItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRespuestaItem", new { id = respuestaItem.IdRespuestaItem }, respuestaItem);
        }

        // DELETE: api/RespuestaItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRespuestaItem(int id)
        {
            var respuestaItem = await _context.RespuestaItem.FindAsync(id);
            if (respuestaItem == null)
            {
                return NotFound();
            }

            _context.RespuestaItem.Remove(respuestaItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RespuestaItemExists(int id)
        {
            return _context.RespuestaItem.Any(e => e.IdRespuestaItem == id);
        }
    }
}
