using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Modelo.Objetos
{
    class OperacionCompra
    {
        public int id { get; set; }
        public int cantidadBonos { get; set; }
        public Decimal montoTotal { get; set; }
        public int pacienteId { get; set; }
    }
}
