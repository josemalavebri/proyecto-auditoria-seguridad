using Microsoft.AspNetCore.Mvc;
using auditoriaBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace back_auditoria.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FacultadController : ControllerBase
{
    private readonly EncuestaDbContext _context;

    public FacultadController(EncuestaDbContext context)
    {
        _context = context;
    }

    // GET: api/facultad
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Facultad>>> GetFacultades()
    {
        var facultades = await _context.Facultads
            .Include(f => f.UbicacionInstitucionals)
            .ToListAsync();

        return Ok(facultades);
    }


}
