using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class EjecucionesEncuestum
{
    public int IdEjecucion { get; set; }

    public int IdEncuesta { get; set; }

    public DateTime FechaEjecucion { get; set; }

    public virtual Encuesta IdEncuestaNavigation { get; set; } = null!;

    public virtual ICollection<RespuestasItem> RespuestasItems { get; set; } = new List<RespuestasItem>();
}
