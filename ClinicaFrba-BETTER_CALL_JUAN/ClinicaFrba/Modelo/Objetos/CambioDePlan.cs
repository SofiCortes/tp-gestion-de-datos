using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class CambioDePlan
    {
        public int id { get; set;  }
        public int pacienteId { get; set; }
        public DateTime fechaCambio { get; set; }
        public string motivoCambio { get; set; }
        public int planAnteriorId { get; set; }
        public int planNuevoId { get; set; }
    }
}
