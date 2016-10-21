using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Modelo.Objetos
{
    class Turno
    {
        public int numero { get; set; }
        public DateTime fechaHora { get; set; }
        public int pacienteId { get; set; }
        public int medicoEspecialidadId { get; set; }
        public int cancelacionId { get; set; }

    }
}
