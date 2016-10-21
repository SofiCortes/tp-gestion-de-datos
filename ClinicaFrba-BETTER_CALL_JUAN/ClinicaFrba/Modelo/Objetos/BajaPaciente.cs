using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Modelo.Objetos
{
    class BajaPaciente
    {
        public int id { get; set; }
        public int pacienteId { get; set; }
        public DateTime fechaBaja { get; set; }
    }
}
