using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace auditoriaBackend.Models;

[Table("Seguimiento")]
public partial class Seguimiento
{
    [Key]
    public int IdSeguimiento { get; set; }

    public int IdRespuestaItem { get; set; }

    [StringLength(50)]
    public string Estado { get; set; } = null!;

    [StringLength(500)]
    public string? Descripcion { get; set; }

    [StringLength(100)]
    public string? Supervisor { get; set; }

    [StringLength(100)]
    public string? ResponsableTratamiento { get; set; }

    [StringLength(100)]
    public string? ResponsableImplementacion { get; set; }

    [StringLength(500)]
    public string? Evidencia { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    [StringLength(500)]
    public string? ObservacionEstado { get; set; }

    [ForeignKey("IdRespuestaItem")]
    [InverseProperty("Seguimientos")]
    public virtual RespuestaItem IdRespuestaItemNavigation { get; set; } = null!;

    [InverseProperty("IdSeguimientoNavigation")]
    public virtual ICollection<Reporte> Reportes { get; set; } = new List<Reporte>();
}
