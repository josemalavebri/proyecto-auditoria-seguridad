using System;
using System.Collections.Generic;

namespace back_auditoria.Models;

public partial class RespuestaItem
{
    public int IdRespuestaItem { get; set; }

    public int IdItem { get; set; }

    public bool Marcado { get; set; }

    public string? PorcentajeCumplimiento { get; set; }

    public virtual Item IdItemNavigation { get; set; } = null!;

    public virtual ICollection<Seguimiento> Seguimiento { get; set; } = new List<Seguimiento>();
}
