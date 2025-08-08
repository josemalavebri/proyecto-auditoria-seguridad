using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class Secciones
{
    public int idSeccion { get; set; }

    public string descripcion { get; set; } = null!;

    public virtual ICollection<Preguntas> Preguntas { get; set; } = new List<Preguntas>();
}
