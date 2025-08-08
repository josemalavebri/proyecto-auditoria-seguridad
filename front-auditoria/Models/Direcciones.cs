using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class Direcciones
{
    public int idDireccion { get; set; }

    public string nombre { get; set; } = null!;

    public virtual ICollection<Facultades> Facultades { get; set; } = new List<Facultades>();
}
