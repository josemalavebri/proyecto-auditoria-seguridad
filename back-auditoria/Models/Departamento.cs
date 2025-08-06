using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace auditoriaBackend.Models;

[Table("Departamento")]
public partial class Departamento
{
    [Key]
    public int IdDepartamento { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("IdDepartamentoNavigation")]
    public virtual ICollection<UbicacionInstitucional> UbicacionInstitucionals { get; set; } = new List<UbicacionInstitucional>();
}
