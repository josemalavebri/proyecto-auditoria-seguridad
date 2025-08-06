using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace auditoriaBackend.Models;

[Table("Facultad")]
public partial class Facultad
{
    [Key]
    public int IdFacultad { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("IdFacultadNavigation")]
    public virtual ICollection<UbicacionInstitucional> UbicacionInstitucionals { get; set; } = new List<UbicacionInstitucional>();
}
