using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace auditoriaBackend.Models;

[Table("UbicacionInstitucional")]
public partial class UbicacionInstitucional
{
    [Key]
    public int IdUbicacionInstitucional { get; set; }

    public int IdUbicacion { get; set; }

    public int IdFacultad { get; set; }

    public int IdDepartamento { get; set; }

    [InverseProperty("IdUbicacionInstitucionalNavigation")]
    public virtual ICollection<Auditorium> Auditoria { get; set; } = new List<Auditorium>();

    [ForeignKey("IdDepartamento")]
    [InverseProperty("UbicacionInstitucionals")]
    public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;

    [ForeignKey("IdFacultad")]
    [InverseProperty("UbicacionInstitucionals")]
    [JsonIgnore]

    public virtual Facultad IdFacultadNavigation { get; set; } = null!;

    [ForeignKey("IdUbicacion")]
    [InverseProperty("UbicacionInstitucionals")]
    public virtual Ubicacion IdUbicacionNavigation { get; set; } = null!;
}
