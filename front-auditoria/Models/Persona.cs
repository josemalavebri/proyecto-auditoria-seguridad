using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public int Rol { get; set; }

    public virtual Role RolNavigation { get; set; } = null!;
}
