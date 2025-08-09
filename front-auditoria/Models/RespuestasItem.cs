using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class RespuestasItem
{
    public int IdRespuestasItems { get; set; }

    public int IdPreguntasItems { get; set; }

    public int IdEjecucion { get; set; }

    public bool Respuesta { get; set; }

    public int PorcentajeCumplimiento { get; set; }

    public virtual EjecucionesEncuestum IdEjecucionNavigation { get; set; } = null!;

    public virtual PreguntasItem IdPreguntasItemsNavigation { get; set; } = null!;
}
