using System;
using System.Collections.Generic;

namespace front_auditoria.Models;

public partial class Encuesta
{
    public int IdEncuesta { get; set; }

    public int IdUbicacionInstitucional { get; set; }

    public int? IdEncuestaOrigen { get; set; }

    public virtual ICollection<EjecucionesEncuestum> EjecucionesEncuesta { get; set; } = new List<EjecucionesEncuestum>();

    public virtual ICollection<EncuestasPregunta> EncuestasPregunta { get; set; } = new List<EncuestasPregunta>();

    public virtual Encuesta? IdEncuestaOrigenNavigation { get; set; }

    public virtual UbicacionesInstitucionale IdUbicacionInstitucionalNavigation { get; set; } = null!;

    public virtual ICollection<Encuesta> InverseIdEncuestaOrigenNavigation { get; set; } = new List<Encuesta>();
}
