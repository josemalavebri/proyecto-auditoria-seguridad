using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace auditoriaBackend.Models;

[Table("RespuestaItem")]
public partial class RespuestaItem
{
    [Key]
    public int IdRespuestaItem { get; set; }

    public int IdItem { get; set; }

    public bool Marcado { get; set; }

    [StringLength(50)]
    public string? PorcentajeCumplimiento { get; set; }

    [ForeignKey("IdItem")]
    [InverseProperty("RespuestaItems")]
    public virtual Item IdItemNavigation { get; set; } = null!;

    [InverseProperty("IdRespuestaItemNavigation")]
    public virtual ICollection<Seguimiento> Seguimientos { get; set; } = new List<Seguimiento>();
}
