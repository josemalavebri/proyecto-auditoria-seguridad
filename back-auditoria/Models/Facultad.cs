using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace back_auditoria.Models;

public partial class Facultad
{
    public int IdFacultad { get; set; }

    public string Nombre { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<UbicacionInstitucional> UbicacionInstitucional { get; set; } = new List<UbicacionInstitucional>();
}
