﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class Consulta
    {
        public int id { get; set; }
        public string sintomas { get; set; }
        public string enfermedades { get; set; }
        public decimal turnoNumero { get; set; }
        public DateTime fechaHoraLlegada { get; set; }
        public DateTime fechaHoraAtencion { get; set; }
        public decimal bonoConsultaId { get; set; }

        public Paciente paciente { get; set; }

        public Especialidad especialidad { get; set; }
    }
}
