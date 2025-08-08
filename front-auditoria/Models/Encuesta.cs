using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class Encuesta
{
    public int idEncuesta { get; set; }

    public int idDepartamento { get; set; }

    public virtual ICollection<EncuestasPreguntas> EncuestasPreguntas { get; set; } = new List<EncuestasPreguntas>();

    public virtual Departamentos idDepartamentoNavigation { get; set; } = null!;
}
