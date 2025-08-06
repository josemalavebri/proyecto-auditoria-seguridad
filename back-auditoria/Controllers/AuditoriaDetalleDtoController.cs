using Microsoft.AspNetCore.Mvc;


namespace back_auditoria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditoriaDetalleDtoController : ControllerBase
    {

        private readonly RepositorioDatos _repo = RepositorioDatos.Instancia;




        [HttpGet("auditoriaDetallado")]
        public IActionResult GetAuditoriasDetalladas()
        {
            /*
            var resultado = _repo.ListaAuditorias.SelectMany(auditoria =>
            {
                // Obtener la Ubicación Institucional a partir de la auditoría
                var ubicacionInstitucional = _repo.ListaUbicacionInstitucional
                    .FirstOrDefault(ui => ui.Ubicacion.IdUbicacion == auditoria.Ubicacion.IdUbicacion);

                var encuestas = auditoria.Encuestas;

                return encuestas.Select(encuesta =>
                {
                    var persona = _repo.ListaPersonas.FirstOrDefault(p => p.IdPersona == encuesta.IdPersona);

                    return new AuditoriaDetalleDto
                    {
                        IdAuditoria = auditoria.IdAuditoria,
                        Titulo = auditoria.Titulo,
                        Ubicacion = ubicacionInstitucional?.Ubicacion?.Nombre ?? "No definida",
                        Facultad = ubicacionInstitucional?.Facultad?.Nombre ?? "No definida",
                        Departamento = ubicacionInstitucional?.Departamento?.Nombre ?? "No definido",
                        PersonaEncuestada = persona?.Nombre ?? "No definida",
                        Estado = "Finalizada", // Puedes modificar este campo según tus reglas
                        Fecha = auditoria.Fecha
                    };
                });

            }).ToList();
            */

            return Ok();
        }
            

    }
}
