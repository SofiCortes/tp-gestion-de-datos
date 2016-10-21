using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Modelo.Objetos
{
    class Consulta
    {
        public int id { get; set; }
        public string sintomas { get; set; }
        public string enfermedades { get; set; }
        public int turnoNumero { get; set; }
        public DateTime fechaHoraLlegada { get; set; }
        public DateTime fechaHoraAtencion { get; set; }
        public int bonoConsultaId { get; set; }
    }
}
