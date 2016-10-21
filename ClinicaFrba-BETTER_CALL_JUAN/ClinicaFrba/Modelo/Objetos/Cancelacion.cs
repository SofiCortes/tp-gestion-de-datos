using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Modelo.Objetos
{
    class Cancelacion
    {
        public int id { get; set; }
        public int tipoCancelacionId { get; set; }
        public string motivo { get; set; }
    }
}
