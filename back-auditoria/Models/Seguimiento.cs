using System;
using System.Collections.Generic;

namespace back_auditoria.Models;

public partial class Seguimiento
{
    public int IdSeguimiento { get; set; }

    public int IdRespuestaItem { get; set; }

    public string Estado { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Supervisor { get; set; }

    public string? ResponsableTratamiento { get; set; }

    public string? ResponsableImplementacion { get; set; }

    public string? Evidencia { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public string? ObservacionEstado { get; set; }

    public virtual RespuestaItem IdRespuestaItemNavigation { get; set; } = null!;

    public virtual ICollection<Reporte> Reporte { get; set; } = new List<Reporte>();
}
