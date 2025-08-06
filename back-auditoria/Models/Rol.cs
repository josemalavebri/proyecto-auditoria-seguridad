using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace auditoriaBackend.Models;

[Table("Rol")]
public partial class Rol
{
    [Key]
    public int IdRol { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("IdRolNavigation")]
    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
