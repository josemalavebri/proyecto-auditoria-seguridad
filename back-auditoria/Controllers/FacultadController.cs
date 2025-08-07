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
    public class FacultadController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public FacultadController(EncuestaDbContext context)
        {
            _context = context;
        }

        // GET: api/Facultad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facultad>>> GetFacultad()
        {
            return await _context.Facultad.ToListAsync();
        }

        // GET: api/Facultad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Facultad>> GetFacultad(int id)
        {
            var facultad = await _context.Facultad.FindAsync(id);

            if (facultad == null)
            {
                return NotFound();
            }

            return facultad;
        }

        // PUT: api/Facultad/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacultad(int id, Facultad facultad)
        {
            if (id != facultad.IdFacultad)
            {
                return BadRequest();
            }

            _context.Entry(facultad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacultadExists(id))
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

        // POST: api/Facultad
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Facultad>> PostFacultad(Facultad facultad)
        {
            _context.Facultad.Add(facultad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacultad", new { id = facultad.IdFacultad }, facultad);
        }

        // DELETE: api/Facultad/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacultad(int id)
        {
            var facultad = await _context.Facultad.FindAsync(id);
            if (facultad == null)
            {
                return NotFound();
            }

            _context.Facultad.Remove(facultad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacultadExists(int id)
        {
            return _context.Facultad.Any(e => e.IdFacultad == id);
        }
    }
}
