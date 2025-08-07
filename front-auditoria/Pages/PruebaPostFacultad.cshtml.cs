using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace front_auditoria.Pages.Shared
{
    public class PruebaPostFacultadModel : PageModel
    {
        [BindProperty]
        public Facultad? facultad { get; set; }

        private readonly IHttpClientFactory _httpClientFactory;

        public PruebaPostFacultadModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public void OnGet()
        {
            // Mostrar formulario
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || facultad is null)
            {
                return Page();
            }

            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.PostAsJsonAsync("http://localhost:5111/api/Facultad", facultad);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("ListaFacultades");
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, "Error al guardar en la API: " + error);
                return Page();
            }
        }

        public class Facultad
        {
            public int IdFacultad { get; set; }

            [Required(ErrorMessage = "El nombre es obligatorio")]
            public string Nombre { get; set; } = string.Empty;
        }
    }
}
