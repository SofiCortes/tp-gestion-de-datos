using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Modelo.Objetos
{
    class BonoConsulta
    {
        public int id { get; set; }
        public DateTime fechaCompra { get; set; }
        public DateTime fechaImpresion { get; set; }
        public int numeroConsultaPaciente { get; set; }
        public int pacienteCompraId { get; set; }
        public int pacienteUsaId { get; set; }
        public int planId { get; set; }
    }
}
