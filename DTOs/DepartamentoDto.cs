using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DepartamentoDto
    {
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }
        public List<object> UbicacionInstitucional { get; set; }
    }
}
