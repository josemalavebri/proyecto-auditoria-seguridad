using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace auditoriaBackend.Models;

[Table("Reporte")]
public partial class Reporte
{
    [Key]
    public int IdReporte { get; set; }

    public int IdSeguimiento { get; set; }

    [StringLength(100)]
    public string Titulo { get; set; } = null!;

    [StringLength(4000)]
    public string? Detalles { get; set; }

    public DateOnly? FechaReporte { get; set; }

    [ForeignKey("IdSeguimiento")]
    [InverseProperty("Reportes")]
    public virtual Seguimiento IdSeguimientoNavigation { get; set; } = null!;
}
