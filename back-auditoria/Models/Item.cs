using System;
using System.Collections.Generic;

namespace back_auditoria.Models;

public partial class Item
{
    public int IdItem { get; set; }

    public string Descripcion { get; set; } = null!;

    public int IdPregunta { get; set; }

    public virtual Pregunta IdPreguntaNavigation { get; set; } = null!;

    public virtual ICollection<PreguntaItem> PreguntaItem { get; set; } = new List<PreguntaItem>();

    public virtual ICollection<RespuestaItem> RespuestaItem { get; set; } = new List<RespuestaItem>();
}
