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
    public class UbicacionesController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public UbicacionesController(EncuestaDbContext context)
        {
            _context = context;
        }

        // GET: api/Ubicaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ubicacion>>> GetUbicacion()
        {
            return await _context.Ubicacion.ToListAsync();
        }

        // GET: api/Ubicaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ubicacion>> GetUbicacion(int id)
        {
            var ubicacion = await _context.Ubicacion.FindAsync(id);

            if (ubicacion == null)
            {
                return NotFound();
            }

            return ubicacion;
        }

        // PUT: api/Ubicaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUbicacion(int id, Ubicacion ubicacion)
        {
            if (id != ubicacion.IdUbicacion)
            {
                return BadRequest();
            }

            _context.Entry(ubicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UbicacionExists(id))
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

        // POST: api/Ubicaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ubicacion>> PostUbicacion(Ubicacion ubicacion)
        {
            _context.Ubicacion.Add(ubicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUbicacion", new { id = ubicacion.IdUbicacion }, ubicacion);
        }

        // DELETE: api/Ubicaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUbicacion(int id)
        {
            var ubicacion = await _context.Ubicacion.FindAsync(id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            _context.Ubicacion.Remove(ubicacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UbicacionExists(int id)
        {
            return _context.Ubicacion.Any(e => e.IdUbicacion == id);
        }
    }
}
