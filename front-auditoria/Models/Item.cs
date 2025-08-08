using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class Item
{
    public int idItem { get; set; }

    public string titulo { get; set; } = null!;

    public string? codigo { get; set; }

    public string? descripcion { get; set; }

    public virtual ICollection<ItemsPreguntas> ItemsPreguntas { get; set; } = new List<ItemsPreguntas>();

    public virtual ICollection<RespuestaItem> RespuestaItem { get; set; } = new List<RespuestaItem>();
}
