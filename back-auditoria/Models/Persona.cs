using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace auditoriaBackend.Models;

[Table("Persona")]
public partial class Persona
{
    [Key]
    public int IdPersona { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(100)]
    public string Correo { get; set; } = null!;

    public int IdRol { get; set; }

    [InverseProperty("IdPersonaNavigation")]
    public virtual ICollection<Encuestum> Encuesta { get; set; } = new List<Encuestum>();

    [ForeignKey("IdRol")]
    [InverseProperty("Personas")]
    public virtual Rol IdRolNavigation { get; set; } = null!;
}
