using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using auditoriaBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_auditoria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public DepartamentoController(EncuestaDbContext context)
        {
            _context = context;
        }

        // GET: api/Departamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamentos()
        {
            // Incluye UbicacionInstitucional para evitar problemas con carga perezosa
            var departamentos = await _context.Departamentos
                .Include(d => d.UbicacionInstitucionals)
                .ToListAsync();

            return Ok(departamentos);
        }

        // GET: api/Departamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> GetDepartamento(int id)
        {
            var departamento = await _context.Departamentos
                .Include(d => d.UbicacionInstitucionals)
                .FirstOrDefaultAsync(d => d.IdDepartamento == id);

            if (departamento == null)
                return NotFound();

            return Ok(departamento);
        }

    }
}
