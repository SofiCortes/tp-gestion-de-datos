using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Modelo.Objetos
{
    class RangoAtencion
    {
        public int id { get; set; }
        public int diaDeLaSemana { get; set; }
        public DateTime horaDesde { get; set; }
        public DateTime horaHasta { get; set; }
        public int medicoEspecialidadId { get; set; }
    }
}
