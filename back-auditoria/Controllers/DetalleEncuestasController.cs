using back_auditoria.Data;
using back_auditoria.Models;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_auditoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleEncuestasController : ControllerBase
    {

        private readonly EncuestaDbContext _context;

        public DetalleEncuestasController(EncuestaDbContext context)
        {
            _context = context;
        }


        [HttpGet("respuesta/{idRespuesta}")]
        public IActionResult ObtenerRespuestaPorId(int idRespuesta)
        {
            var resultado =
                (from e in _context.Encuesta
                 join pe in _context.PreguntaEncuesta on e.IdEncuesta equals pe.IdEncuesta
                 join p in _context.Pregunta on pe.IdPregunta equals p.IdPregunta
                 join pi in _context.PreguntaItem on p.IdPregunta equals pi.IdPregunta
                 join i in _context.Item on pi.IdItem equals i.IdItem
                 join ri in _context.RespuestaItem on i.IdItem equals ri.IdItem
                 where ri.IdRespuestaItem == idRespuesta
                 group i by new { ri.IdRespuestaItem, p.Texto, ri.Marcado } into g
                 select new
                 {
                     IdRespuesta = g.Key.IdRespuestaItem,
                     Pregunta = g.Key.Texto,
                     ItemsAsociados = string.Join(", ", g.Select(x => x.Descripcion)),
                     Marcado = g.Key.Marcado
                 }).FirstOrDefault();

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

    }
}
