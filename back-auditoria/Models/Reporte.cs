using System;
using System.Collections.Generic;

namespace back_auditoria.Models;

public partial class Reporte
{
    public int IdReporte { get; set; }

    public int IdSeguimiento { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Detalles { get; set; }

    public DateOnly? FechaReporte { get; set; }

    public virtual Seguimiento IdSeguimientoNavigation { get; set; } = null!;
}
