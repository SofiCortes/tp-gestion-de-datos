using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class CambioDePlan
    {
        public decimal id { get; set;  }
        public decimal pacienteId { get; set; }
        public DateTime fechaCambio { get; set; }
        public string motivoCambio { get; set; }
        public decimal planAnteriorId { get; set; }
        public decimal planNuevoId { get; set; }
    }
}
