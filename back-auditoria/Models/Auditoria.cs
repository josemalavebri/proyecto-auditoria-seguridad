using System;
using System.Collections.Generic;

namespace back_auditoria.Models;

public partial class Auditoria
{
    public int IdAuditoria { get; set; }

    public string Titulo { get; set; } = null!;

    public int IdUbicacionInstitucional { get; set; }

    public DateOnly Fecha { get; set; }

    public virtual ICollection<Encuesta> Encuesta { get; set; } = new List<Encuesta>();

    public virtual UbicacionInstitucional IdUbicacionInstitucionalNavigation { get; set; } = null!;
}
