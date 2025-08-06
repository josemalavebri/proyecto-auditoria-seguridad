using auditoriaBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_auditoria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UbicacionController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public UbicacionController(EncuestaDbContext context)
        {
            _context = context;
        }

        // GET: api/ubicacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ubicacion>>> GetUbicacions()
        {
            var ubicacion = await _context.Ubicacions
               .Include(u => u.UbicacionInstitucionals)
               .ToListAsync();
            return Ok(ubicacion);
        }

        // GET: api/ubicacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ubicacion>> GetUbicacion(int id)
        {
            var ubicacion = await _context.Ubicacions
                .Include(u => u.UbicacionInstitucionals)
                .FirstOrDefaultAsync(u => u.IdUbicacion == id);

            if (ubicacion == null)
                return NotFound();

            return Ok(ubicacion);
        }

    }
}
