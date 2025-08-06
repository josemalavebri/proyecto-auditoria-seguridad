using auditoriaBackend.Models;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_auditoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriasController : ControllerBase
    {
        private readonly EncuestaDbContext _context;

        public AuditoriasController(EncuestaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuditoriaEncuestaDto>>> Get()
        {
            var query = from encuesta in _context.Encuesta
                         join auditoria in _context.Auditoria
                             on encuesta.IdAuditoria equals auditoria.IdAuditoria
                         join persona in _context.Personas
                             on encuesta.IdPersona equals persona.IdPersona
                         select new AuditoriaEncuestaDto
                         {
                             IdAuditoria = auditoria.IdAuditoria,
                             TituloAuditoria = auditoria.Titulo,
                             NombrePersona = persona.Nombre,
                             FechaRealizacion = encuesta.FechaRealizacion
                         };

            var resultado = await query.ToListAsync();

            return Ok(resultado);
        }
    }
}
