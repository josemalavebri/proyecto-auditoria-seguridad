using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class Item
{
    public int IdItem { get; set; }

    public string Titulo { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<PreguntasItem> PreguntasItems { get; set; } = new List<PreguntasItem>();
}
