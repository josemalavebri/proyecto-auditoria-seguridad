using System;
using System.Collections.Generic;

namespace back_auditoria.Models;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public int IdRol { get; set; }

    public virtual ICollection<Encuesta> Encuesta { get; set; } = new List<Encuesta>();

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
