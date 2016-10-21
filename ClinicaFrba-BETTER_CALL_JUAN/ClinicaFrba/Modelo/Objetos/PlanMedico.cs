using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class PlanMedico
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }
        public Decimal precioBonoConsulta { get; set; }
        public Decimal precioBonoFarmacia { get; set; }
    }
}
