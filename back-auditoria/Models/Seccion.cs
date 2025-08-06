using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace auditoriaBackend.Models;

[Table("Seccion")]
public partial class Seccion
{
    [Key]
    public int IdSeccion { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("IdSeccionNavigation")]
    public virtual ICollection<Preguntum> Pregunta { get; set; } = new List<Preguntum>();
}
