using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace auditoriaBackend.Models;

public partial class Preguntum
{
    [Key]
    public int IdPregunta { get; set; }

    [StringLength(300)]
    public string Texto { get; set; } = null!;

    public int IdSeccion { get; set; }

    [ForeignKey("IdSeccion")]
    [InverseProperty("Pregunta")]
    public virtual Seccion IdSeccionNavigation { get; set; } = null!;

    [InverseProperty("IdPreguntaNavigation")]
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    [InverseProperty("IdPreguntaNavigation")]
    public virtual ICollection<PreguntaEncuestum> PreguntaEncuesta { get; set; } = new List<PreguntaEncuestum>();

    [InverseProperty("IdPreguntaNavigation")]
    public virtual ICollection<PreguntaItem> PreguntaItems { get; set; } = new List<PreguntaItem>();
}
