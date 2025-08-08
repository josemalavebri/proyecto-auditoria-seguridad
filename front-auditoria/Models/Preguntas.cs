using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class Preguntas
{
    public int idPregunta { get; set; }

    public string descripcion { get; set; } = null!;

    public int idSeccion { get; set; }

    public virtual ICollection<EncuestasPreguntas> EncuestasPreguntas { get; set; } = new List<EncuestasPreguntas>();

    public virtual ICollection<ItemsPreguntas> ItemsPreguntas { get; set; } = new List<ItemsPreguntas>();

    public virtual Secciones idSeccionNavigation { get; set; } = null!;
}
