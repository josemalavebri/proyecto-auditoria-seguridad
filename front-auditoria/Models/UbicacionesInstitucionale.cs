using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class UbicacionesInstitucionale
{
    public int IdUbicacionInstitucional { get; set; }

    public int? IdFacultad { get; set; }

    public int IdDireccion { get; set; }

    public int IdDepartamento { get; set; }

    public virtual ICollection<Encuesta> Encuesta { get; set; } = new List<Encuesta>();

    public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;

    public virtual Direccione IdDireccionNavigation { get; set; } = null!;

    public virtual Facultade? IdFacultadNavigation { get; set; }
}
