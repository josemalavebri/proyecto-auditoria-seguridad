using back_auditoria.Data;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_auditoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriasDTOController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public AuditoriasDTOController(EncuestaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuditoriaEncuestaDto>>> Get()
        {
            var query = _context.Encuesta
        .Include(e => e.IdAuditoriaNavigation)
        .Include(e => e.IdPersonaNavigation)
        .Select(e => new AuditoriaEncuestaDto
        {
            IdAuditoria = e.IdAuditoria,
            TituloAuditoria = e.IdAuditoriaNavigation.Titulo,
            NombrePersona = e.IdPersonaNavigation.Nombre,
            FechaRealizacion = e.FechaRealizacion
        });

            var resultado = await query.ToListAsync();

            return Ok(resultado);
        }
    }
}
