using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DetalleEncuestaDTOs
    {
        public int IdRespuesta { get; set; }
        public string Pregunta { get; set; }
        public string[] ItemsAsociados { get; set; }
        public string Marcado { get; set; }
    }
}
