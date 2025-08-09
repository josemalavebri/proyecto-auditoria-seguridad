using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class PreguntasItem
{
    public int IdPreguntasItems { get; set; }

    public int IdItem { get; set; }

    public int IdPregunta { get; set; }

    public virtual Item IdItemNavigation { get; set; } = null!;

    public virtual Pregunta IdPreguntaNavigation { get; set; } = null!;

    public virtual ICollection<RespuestasItem> RespuestasItems { get; set; } = new List<RespuestasItem>();
}
