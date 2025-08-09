using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class Pregunta
{
    public int IdPregunta { get; set; }

    public string Descripcion { get; set; } = null!;

    public int IdSeccion { get; set; }

    public virtual ICollection<EncuestasPregunta> EncuestasPregunta { get; set; } = new List<EncuestasPregunta>();

    public virtual Seccione IdSeccionNavigation { get; set; } = null!;

    public virtual ICollection<PreguntasItem> PreguntasItems { get; set; } = new List<PreguntasItem>();
}
