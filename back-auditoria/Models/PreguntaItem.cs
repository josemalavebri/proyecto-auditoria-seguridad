using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace auditoriaBackend.Models;

[Table("PreguntaItem")]
public partial class PreguntaItem
{
    [Key]
    public int IdPreguntaItem { get; set; }

    [StringLength(300)]
    public string Texto { get; set; } = null!;

    public int IdItem { get; set; }

    public int IdPregunta { get; set; }

    [ForeignKey("IdItem")]
    [InverseProperty("PreguntaItems")]
    public virtual Item IdItemNavigation { get; set; } = null!;

    [ForeignKey("IdPregunta")]
    [InverseProperty("PreguntaItems")]
    public virtual Preguntum IdPreguntaNavigation { get; set; } = null!;
}
