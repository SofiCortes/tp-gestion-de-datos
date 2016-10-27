using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class RangoAtencion
    {
        public decimal id { get; set; }
        public int diaDeLaSemana { get; set; }
        public DateTime horaDesde { get; set; }
        public DateTime horaHasta { get; set; }
        public decimal medicoEspecialidadId { get; set; }
    }
}
