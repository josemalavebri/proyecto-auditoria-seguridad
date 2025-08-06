using System;
using System.Collections.Generic;

namespace back_auditoria.Models;

public partial class Seccion
{
    public int IdSeccion { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Pregunta> Pregunta { get; set; } = new List<Pregunta>();
}
