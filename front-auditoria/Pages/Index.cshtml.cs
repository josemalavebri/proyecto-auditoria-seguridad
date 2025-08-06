using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_auditoria.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public JsonResult OnGetAuditorias()
        {
            return new JsonResult(ObtenerAuditorias());
        }

        private List<Auditoria> ObtenerAuditorias() => new()
        {
            new Auditoria { Id = 1, Nombre = "Auditor�a 1", Fecha = "2024-01-01" },
            new Auditoria { Id = 2, Nombre = "Auditor�a 2", Fecha = "2024-01-02" }
        };

        class Auditoria
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Fecha { get; set; }
        }

        public JsonResult OnGetSugerencias(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return new JsonResult(new List<string>());

            var lugaresMock = new List<string>
            {
                "Guayaquil",
                "Quito",
                "Cuenca",
                "Ibarra",
                "Manta",
                "Machala",
                "Ambato",
                "Riobamba",
                "Loja",
                "Esmeraldas",
                "Santo Domingo",
                "Latacunga"
            };

            var resultados = lugaresMock
                .Where(l => l.Contains(termino, StringComparison.OrdinalIgnoreCase))
                .Take(10)
                .ToList();

            return new JsonResult(resultados);
        }

        public JsonResult OnGetDetalleEncuesta(int id)
        {
            var detalle = ObtenerDetallePorEncuesta(id); // m�todo personalizado
            return new JsonResult(detalle);
        }

        private List<DetalleEncuesta> ObtenerDetallePorEncuesta(int id)
        {
            // Simulaci�n de datos
            var detallesEncuestas = new Dictionary<int, List<DetalleEncuesta>>
            {
                    {
                        1, new List<DetalleEncuesta>
                        {
                            new DetalleEncuesta { Pregunta = "�Est� satisfecho con el servicio?", Respuesta = "S�" },
                            new DetalleEncuesta { Pregunta = "�Recomendar�a este lugar?", Respuesta = "S�" },
                            new DetalleEncuesta { Pregunta = "�Qu� le gustar�a mejorar?", Respuesta = "La atenci�n" }
                        }
                    },
                    {
                        2, new List<DetalleEncuesta>
                        {
                            new DetalleEncuesta { Pregunta = "�C�mo califica el evento?", Respuesta = "Excelente" },
                            new DetalleEncuesta { Pregunta = "�Asistir�a nuevamente?", Respuesta = "S�" }
                        }
                    }
                };

                return detallesEncuestas.ContainsKey(id) ? detallesEncuestas[id] : new List<DetalleEncuesta>();
            }


        public class DetalleEncuesta
        {
            public string Pregunta { get; set; }
            public string Respuesta { get; set; }
        }

    }
}
