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
    public class PreguntaEncuestasController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public PreguntaEncuestasController(EncuestaDbContext context)
        {
            _context = context;
        }

        // GET: api/PreguntaEncuestas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreguntaEncuesta>>> GetPreguntaEncuesta()
        {
            return await _context.PreguntaEncuesta.ToListAsync();
        }

        // GET: api/PreguntaEncuestas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreguntaEncuesta>> GetPreguntaEncuesta(int id)
        {
            var preguntaEncuesta = await _context.PreguntaEncuesta.FindAsync(id);

            if (preguntaEncuesta == null)
            {
                return NotFound();
            }

            return preguntaEncuesta;
        }

        // PUT: api/PreguntaEncuestas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreguntaEncuesta(int id, PreguntaEncuesta preguntaEncuesta)
        {
            if (id != preguntaEncuesta.IdPreguntaEncuesta)
            {
                return BadRequest();
            }

            _context.Entry(preguntaEncuesta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreguntaEncuestaExists(id))
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

        // POST: api/PreguntaEncuestas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PreguntaEncuesta>> PostPreguntaEncuesta(PreguntaEncuesta preguntaEncuesta)
        {
            _context.PreguntaEncuesta.Add(preguntaEncuesta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreguntaEncuesta", new { id = preguntaEncuesta.IdPreguntaEncuesta }, preguntaEncuesta);
        }

        // DELETE: api/PreguntaEncuestas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreguntaEncuesta(int id)
        {
            var preguntaEncuesta = await _context.PreguntaEncuesta.FindAsync(id);
            if (preguntaEncuesta == null)
            {
                return NotFound();
            }

            _context.PreguntaEncuesta.Remove(preguntaEncuesta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PreguntaEncuestaExists(int id)
        {
            return _context.PreguntaEncuesta.Any(e => e.IdPreguntaEncuesta == id);
        }
    }
}
