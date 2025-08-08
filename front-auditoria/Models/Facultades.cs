using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class Facultades
{
    public int idFacultad { get; set; }

    public string nombre { get; set; } = null!;

    public int idDireccion { get; set; }

    public virtual ICollection<Departamentos> Departamentos { get; set; } = new List<Departamentos>();

    public virtual Direcciones idDireccionNavigation { get; set; } = null!;
}
