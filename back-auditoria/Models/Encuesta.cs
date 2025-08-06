using System;
using System.Collections.Generic;

namespace back_auditoria.Models;

public partial class Encuesta
{
    public int IdEncuesta { get; set; }

    public int IdAuditoria { get; set; }

    public int IdPersona { get; set; }

    public DateOnly FechaRealizacion { get; set; }

    public virtual Auditoria IdAuditoriaNavigation { get; set; } = null!;

    public virtual Persona IdPersonaNavigation { get; set; } = null!;

    public virtual ICollection<PreguntaEncuesta> PreguntaEncuesta { get; set; } = new List<PreguntaEncuesta>();
}
