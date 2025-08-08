using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class EncuestasPreguntas
{
    public int idEncuestaPregunta { get; set; }

    public int idEncuesta { get; set; }

    public int idPregunta { get; set; }

    public virtual Encuesta idEncuestaNavigation { get; set; } = null!;

    public virtual Preguntas idPreguntaNavigation { get; set; } = null!;
}
