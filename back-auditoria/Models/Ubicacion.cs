using System;
using System.Collections.Generic;

namespace back_auditoria.Models;

public partial class Ubicacion
{
    public int IdUbicacion { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<UbicacionInstitucional> UbicacionInstitucional { get; set; } = new List<UbicacionInstitucional>();
}
