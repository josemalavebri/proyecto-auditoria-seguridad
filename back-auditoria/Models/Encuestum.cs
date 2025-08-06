using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace auditoriaBackend.Models;

public partial class Encuestum
{
    [Key]
    public int IdEncuesta { get; set; }

    public int IdAuditoria { get; set; }

    public int IdPersona { get; set; }

    public DateOnly FechaRealizacion { get; set; }

    [ForeignKey("IdAuditoria")]
    [InverseProperty("Encuesta")]
    public virtual Auditorium IdAuditoriaNavigation { get; set; } = null!;

    [ForeignKey("IdPersona")]
    [InverseProperty("Encuesta")]
    public virtual Persona IdPersonaNavigation { get; set; } = null!;

    [InverseProperty("IdEncuestaNavigation")]
    public virtual ICollection<PreguntaEncuestum> PreguntaEncuesta { get; set; } = new List<PreguntaEncuestum>();
}
