using System;
using System.Collections.Generic;

namespace back_auditoria.Models;

public partial class UbicacionInstitucional
{
    public int IdUbicacionInstitucional { get; set; }

    public int IdUbicacion { get; set; }

    public int IdFacultad { get; set; }

    public int IdDepartamento { get; set; }

    public virtual ICollection<Auditoria> Auditoria { get; set; } = new List<Auditoria>();

    public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;

    public virtual Facultad IdFacultadNavigation { get; set; } = null!;

    public virtual Ubicacion IdUbicacionNavigation { get; set; } = null!;
}
