using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class Seccione
{
    public int IdSeccion { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Pregunta> Pregunta { get; set; } = new List<Pregunta>();
}
