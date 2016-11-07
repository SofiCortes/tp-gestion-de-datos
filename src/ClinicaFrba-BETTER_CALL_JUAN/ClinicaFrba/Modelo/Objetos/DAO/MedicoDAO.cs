using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class MedicoDAO
    {
        public Medico medico { get; set; }
        public int cantHorasTrabajadas { get; set; }
        public int cantConsultas { get; set; }

        public Especialidad especialidadMedico { get; set; }
    }
}
