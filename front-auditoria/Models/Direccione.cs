using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class Direccione
{
    public int IdDireccion { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<UbicacionesInstitucionale> UbicacionesInstitucionales { get; set; } = new List<UbicacionesInstitucionale>();
}
