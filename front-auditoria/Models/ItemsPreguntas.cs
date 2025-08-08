using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class ItemsPreguntas
{
    public int idItemsPreguntas { get; set; }

    public int idItem { get; set; }

    public int idPregunta { get; set; }

    public virtual Item idItemNavigation { get; set; } = null!;

    public virtual Preguntas idPreguntaNavigation { get; set; } = null!;
}
