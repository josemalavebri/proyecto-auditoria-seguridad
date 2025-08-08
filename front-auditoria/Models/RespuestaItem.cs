using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class RespuestaItem
{
    public int idRespuestaItem { get; set; }

    public int idItem { get; set; }

    public bool respuesta { get; set; }

    public int porcentajeCumplimiento { get; set; }

    public virtual Item idItemNavigation { get; set; } = null!;
}
