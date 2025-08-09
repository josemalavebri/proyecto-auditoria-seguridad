using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class Facultade
{
    public int IdFacultad { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<UbicacionesInstitucionale> UbicacionesInstitucionales { get; set; } = new List<UbicacionesInstitucionale>();
}
