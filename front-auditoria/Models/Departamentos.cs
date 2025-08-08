using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class Departamentos
{
    public int idDepartamento { get; set; }

    public string nombre { get; set; } = null!;

    public int idFacultad { get; set; }

    public virtual ICollection<Encuesta> Encuesta { get; set; } = new List<Encuesta>();

    public virtual Facultades idFacultadNavigation { get; set; } = null!;
}
