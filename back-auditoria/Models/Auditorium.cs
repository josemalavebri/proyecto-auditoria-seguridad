using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace auditoriaBackend.Models;

public partial class Auditorium
{
    [Key]
    public int IdAuditoria { get; set; }

    [StringLength(100)]
    public string Titulo { get; set; } = null!;

    public int IdUbicacionInstitucional { get; set; }

    public DateOnly Fecha { get; set; }

    [InverseProperty("IdAuditoriaNavigation")]
    public virtual ICollection<Encuestum> Encuesta { get; set; } = new List<Encuestum>();

    [ForeignKey("IdUbicacionInstitucional")]
    [InverseProperty("Auditoria")]
    public virtual UbicacionInstitucional IdUbicacionInstitucionalNavigation { get; set; } = null!;
}
