using System;
using System.Collections.Generic;

namespace back_auditoria.Models;

public partial class Facultad
{
    public int IdFacultad { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<UbicacionInstitucional> UbicacionInstitucional { get; set; } = new List<UbicacionInstitucional>();
}
