using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class Turno
    {
        public decimal numero { get; set; }
        public DateTime fechaHora { get; set; }
        public decimal pacienteId { get; set; }
        public decimal medicoEspecialidadId { get; set; }

        public Paciente paciente { get; set; }
    }
}
