using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace auditoriaBackend.Models;

public partial class PreguntaEncuestum
{
    [Key]
    public int IdPreguntaEncuesta { get; set; }

    public int IdEncuesta { get; set; }

    public int IdPregunta { get; set; }

    [ForeignKey("IdEncuesta")]
    [InverseProperty("PreguntaEncuesta")]
    public virtual Encuestum IdEncuestaNavigation { get; set; } = null!;

    [ForeignKey("IdPregunta")]
    [InverseProperty("PreguntaEncuesta")]
    public virtual Preguntum IdPreguntaNavigation { get; set; } = null!;
}
