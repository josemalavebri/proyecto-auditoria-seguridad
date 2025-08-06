using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace auditoriaBackend.Models;

[Table("Item")]
public partial class Item
{
    [Key]
    public int IdItem { get; set; }

    [StringLength(200)]
    public string Descripcion { get; set; } = null!;

    public int IdPregunta { get; set; }

    [ForeignKey("IdPregunta")]
    [InverseProperty("Items")]
    public virtual Preguntum IdPreguntaNavigation { get; set; } = null!;

    [InverseProperty("IdItemNavigation")]
    public virtual ICollection<PreguntaItem> PreguntaItems { get; set; } = new List<PreguntaItem>();

    [InverseProperty("IdItemNavigation")]
    public virtual ICollection<RespuestaItem> RespuestaItems { get; set; } = new List<RespuestaItem>();
}
