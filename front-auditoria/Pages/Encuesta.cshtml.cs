using front_auditoria.Data;
using front_auditoria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace front_auditoria.Pages
{
    public class EncuestaModel : PageModel
    {
        private readonly NombreDelContexto _context;

        public EncuestaModel(NombreDelContexto context)
        {
            _context = context;
        }

        // Para nueva direcci�n
        [BindProperty]
        public string NuevaDireccionNombre { get; set; }

        // Para nueva facultad
        [BindProperty]
        public string NuevaFacultadNombre { get; set; }

        [BindProperty]
        public int? NuevaFacultadDireccionId { get; set; }

        public List<Direcciones> Direcciones { get; set; }
        public List<Facultades> Facultades { get; set; }

        public SelectList DireccionesSelectList { get; set; }

        public void OnGet()
        {
            CargarListas();
        }

        public IActionResult OnPostAgregarDireccion()
        {
            CargarListas();

            if (string.IsNullOrWhiteSpace(NuevaDireccionNombre))
            {
                ModelState.AddModelError("NuevaDireccionNombre", "El nombre de la direcci�n es requerido.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var nuevaDireccion = new Direcciones
            {
                nombre = NuevaDireccionNombre.Trim()
            };

            _context.Direcciones.Add(nuevaDireccion);
            _context.SaveChanges();

            NuevaDireccionNombre = string.Empty;

            CargarListas();

            return Page();
        }

        public IActionResult OnPostAgregarFacultad()
        {
            CargarListas();

            if (string.IsNullOrWhiteSpace(NuevaFacultadNombre))
            {
                ModelState.AddModelError("NuevaFacultadNombre", "El nombre de la facultad es requerido.");
            }

            if (!NuevaFacultadDireccionId.HasValue)
            {
                ModelState.AddModelError("NuevaFacultadDireccionId", "Debe seleccionar una direcci�n.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var nuevaFacultad = new Facultades
            {
                nombre = NuevaFacultadNombre.Trim(),
                idDireccion = NuevaFacultadDireccionId.Value
            };

            _context.Facultades.Add(nuevaFacultad);
            _context.SaveChanges();

            NuevaFacultadNombre = string.Empty;
            NuevaFacultadDireccionId = null;

            CargarListas();

            return Page();
        }

        private void CargarListas()
        {
            Direcciones = _context.Direcciones.OrderBy(d => d.nombre).ToList() ?? new List<Direcciones>();
            Facultades = _context.Facultades.OrderBy(f => f.nombre).ToList() ?? new List<Facultades>();

            DireccionesSelectList = new SelectList(Direcciones, "idDireccion", "nombre");
        }

    }
}
