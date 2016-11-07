using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class Medico
    {
        public decimal matricula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string tipoDoc { get; set; }
        public decimal nroDoc { get; set; }
        public string direccion { get; set; }
        public decimal telefono { get; set; }
        public string mail { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public char sexo { get; set; }
        public decimal usuarioId { get; set; }

        public string fullName 
        {
            get
            {
                return apellido + " " + nombre;
            }
        }
    }
}
