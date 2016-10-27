using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class PlanMedico
    {
        public decimal codigo { get; set; }
        public string descripcion { get; set; }
        public decimal precioBonoConsulta { get; set; }
        public decimal precioBonoFarmacia { get; set; }
    }
}
