using auditoriaBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_auditoria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public RolController(EncuestaDbContext context)
        {
            _context = context;
        }

        // GET: api/rol
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRoles()
        {
            var rol = await _context.Rols
                .Include(r => r.Personas)
                .ToListAsync();
            return Ok(rol);
        }

        // GET: api/rol/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            var rol = await _context.Rols
                .Include(r => r.Personas)
                .FirstOrDefaultAsync(r => r.IdRol == id);

            if (rol == null)
                return NotFound();

            return Ok(rol);
        }
    }
}
