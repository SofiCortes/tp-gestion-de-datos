using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class Paciente
    {
        public int id { get; set; }
        public int nroRaiz { get; set; }
        public int nroPersonal { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string tipoDoc { get; set; }
        public int nroDoc { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public string mail { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public char sexo { get; set; }
        public string estadoCivil { get; set; }
        public int cantidadFamiliares { get; set; }
        public int planMedicoCod { get; set; }
        public bool habilitado { get; set; }
        public int nro_ultima_consulta { get; set; }
        public int usuarioId { get; set; }
    }
}
