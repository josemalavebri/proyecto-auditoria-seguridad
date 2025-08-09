using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class EncuestasPregunta
{
    public int IdEncuestaPregunta { get; set; }

    public int IdEncuesta { get; set; }

    public int IdPregunta { get; set; }

    public virtual Encuesta IdEncuestaNavigation { get; set; } = null!;

    public virtual Pregunta IdPreguntaNavigation { get; set; } = null!;
}
