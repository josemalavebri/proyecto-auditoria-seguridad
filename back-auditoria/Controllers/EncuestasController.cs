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
    public class EncuestasController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public EncuestasController(EncuestaDbContext context)
        {
            _context = context;
        }

        // GET: api/Encuestas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Encuesta>>> GetEncuesta()
        {
            return await _context.Encuesta.ToListAsync();
        }

        // GET: api/Encuestas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Encuesta>> GetEncuesta(int id)
        {
            var encuesta = await _context.Encuesta.FindAsync(id);

            if (encuesta == null)
            {
                return NotFound();
            }

            return encuesta;
        }

        // PUT: api/Encuestas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEncuesta(int id, Encuesta encuesta)
        {
            if (id != encuesta.IdEncuesta)
            {
                return BadRequest();
            }

            _context.Entry(encuesta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EncuestaExists(id))
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

        // POST: api/Encuestas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Encuesta>> PostEncuesta(Encuesta encuesta)
        {
            _context.Encuesta.Add(encuesta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEncuesta", new { id = encuesta.IdEncuesta }, encuesta);
        }

        // DELETE: api/Encuestas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEncuesta(int id)
        {
            var encuesta = await _context.Encuesta.FindAsync(id);
            if (encuesta == null)
            {
                return NotFound();
            }

            _context.Encuesta.Remove(encuesta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EncuestaExists(int id)
        {
            return _context.Encuesta.Any(e => e.IdEncuesta == id);
        }
    }
}
