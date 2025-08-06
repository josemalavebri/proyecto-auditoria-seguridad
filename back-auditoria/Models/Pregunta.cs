using System;
using System.Collections.Generic;

namespace back_auditoria.Models;

public partial class Pregunta
{
    public int IdPregunta { get; set; }

    public string Texto { get; set; } = null!;

    public int IdSeccion { get; set; }

    public virtual Seccion IdSeccionNavigation { get; set; } = null!;

    public virtual ICollection<Item> Item { get; set; } = new List<Item>();

    public virtual ICollection<PreguntaEncuesta> PreguntaEncuesta { get; set; } = new List<PreguntaEncuesta>();

    public virtual ICollection<PreguntaItem> PreguntaItem { get; set; } = new List<PreguntaItem>();
}
