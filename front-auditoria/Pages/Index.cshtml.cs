using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text.Json;

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

        public async Task<JsonResult>OnGetAuditorias()
        {
            using var httpClient = new HttpClient();

            try
            {
                var respuesta = await httpClient.GetAsync("http://localhost:5111/api/AuditoriasDTO");
                respuesta.EnsureSuccessStatusCode();

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var auditorias = JsonSerializer.Deserialize<List<AuditoriaEncuestaDto>>(contenido, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return new JsonResult(auditorias);
            }
            catch
            {
                return new JsonResult(new List<AuditoriaEncuestaDto>());
            }
        }

        public async Task<JsonResult> OnGetSugerenciasAsync(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return new JsonResult(new List<string>());

            using var httpClient = new HttpClient();

            try
            {
                var respuesta = await httpClient.GetAsync("http://localhost:5111/api/Ubicaciones");
                respuesta.EnsureSuccessStatusCode();

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var ubicaciones = JsonSerializer.Deserialize<List<UbicacionDto>>(contenido, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var resultados = ubicaciones
                    .Where(u => u.Nombre.Contains(termino, StringComparison.OrdinalIgnoreCase))
                    .Select(u => u.Nombre)
                    .Take(10)
                    .ToList();

                return new JsonResult(resultados);
            }
            catch
            {
                return new JsonResult(new List<string>());
            }
        }


        public async Task<JsonResult> OnGetDetalleEncuesta(int id)
        {
            using var client = new HttpClient();
            string url = $"http://localhost:5111/api/DetalleEncuestas/respuesta/{id}";

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                // Opcional: manejar error o devolver NotFound, etc.
                return new JsonResult(null);
            }

            var jsonString = await response.Content.ReadAsStringAsync();

            // Aquí puedes definir una clase para mapear el JSON o usar dynamic
            var detalle = JsonSerializer.Deserialize<object>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return new JsonResult(detalle);
        }



        private List<DetalleEncuesta> ObtenerDetallePorEncuesta(int id)
        {
            // Simulación de datos
            var detallesEncuestas = new Dictionary<int, List<DetalleEncuesta>>
            {
                    {
                        1, new List<DetalleEncuesta>
                        {
                            new DetalleEncuesta { Pregunta = "¿Está satisfecho con el servicio?", Respuesta = "Sí" },
                            new DetalleEncuesta { Pregunta = "¿Recomendaría este lugar?", Respuesta = "Sí" },
                            new DetalleEncuesta { Pregunta = "¿Qué le gustaría mejorar?", Respuesta = "La atención" }
                        }
                    },
                    {
                        2, new List<DetalleEncuesta>
                        {
                            new DetalleEncuesta { Pregunta = "¿Cómo califica el evento?", Respuesta = "Excelente" },
                            new DetalleEncuesta { Pregunta = "¿Asistiría nuevamente?", Respuesta = "Sí" }
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


        public async Task<JsonResult> OnGetSugerenciasFacultadAsync(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return new JsonResult(new List<string>());

            using var httpClient = new HttpClient();

            try
            {
                var respuesta = await httpClient.GetAsync("http://localhost:5111/api/Facultad");
                respuesta.EnsureSuccessStatusCode();

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var facultades = JsonSerializer.Deserialize<List<FacultadDto>>(contenido, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var resultados = facultades
                    .Where(f => f.Nombre.Contains(termino, StringComparison.OrdinalIgnoreCase))
                    .Select(f => f.Nombre)
                    .Take(10)
                    .ToList();

                return new JsonResult(resultados);
            }
            catch
            {
                return new JsonResult(new List<string>());
            }
        }

        public async Task<JsonResult> OnGetSugerenciasDepartamentoAsync(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return new JsonResult(new List<string>());

            using var httpClient = new HttpClient();

            try
            {
                var respuesta = await httpClient.GetAsync("http://localhost:5111/api/Departamento");
                respuesta.EnsureSuccessStatusCode();

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var departamentos = JsonSerializer.Deserialize<List<DepartamentoDto>>(contenido, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var resultados = departamentos
                    .Where(d => d.Nombre.Contains(termino, StringComparison.OrdinalIgnoreCase))
                    .Select(d => d.Nombre)
                    .Take(10)
                    .ToList();

                return new JsonResult(resultados);
            }
            catch
            {
                return new JsonResult(new List<string>());
            }
        }

    }
}
