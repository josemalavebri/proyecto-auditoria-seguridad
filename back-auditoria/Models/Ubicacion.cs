using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace auditoriaBackend.Models;

[Table("Ubicacion")]
public partial class Ubicacion
{
    [Key]
    public int IdUbicacion { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("IdUbicacionNavigation")]
    public virtual ICollection<UbicacionInstitucional> UbicacionInstitucionals { get; set; } = new List<UbicacionInstitucional>();
}
