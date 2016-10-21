using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Modelo.Objetos
{
    class Medico
    {
        public int matricula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string tipoDoc { get; set; }
        public int nroDoc { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public string mail { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public char sexo { get; set; }
        public int usuarioId { get; set; }

    }
}
