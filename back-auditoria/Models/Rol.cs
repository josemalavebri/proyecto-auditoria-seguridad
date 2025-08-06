using System;
using System.Collections.Generic;

namespace back_auditoria.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Persona> Persona { get; set; } = new List<Persona>();
}
