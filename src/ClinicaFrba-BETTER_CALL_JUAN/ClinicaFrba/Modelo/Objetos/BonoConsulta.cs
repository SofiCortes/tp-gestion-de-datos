using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class BonoConsulta
    {
        public decimal id { get; set; }
        public DateTime fechaCompra { get; set; }
        public DateTime fechaImpresion { get; set; }
        public decimal numeroConsultaPaciente { get; set; }
        public decimal pacienteCompraId { get; set; }
        public decimal pacienteUsaId { get; set; }
        public decimal planId { get; set; }
    }
}
