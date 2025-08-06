using System;
using System.Collections.Generic;

namespace back_auditoria.Models;

public partial class PreguntaItem
{
    public int IdPreguntaItem { get; set; }

    public string Texto { get; set; } = null!;

    public int IdItem { get; set; }

    public int IdPregunta { get; set; }

    public virtual Item IdItemNavigation { get; set; } = null!;

    public virtual Pregunta IdPreguntaNavigation { get; set; } = null!;
}
