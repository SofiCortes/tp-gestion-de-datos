﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    public class Paciente
    {
        public decimal id { get; set; }
        public decimal nroRaiz { get; set; }
        public decimal nroPersonal { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string tipoDoc { get; set; }
        public decimal nroDoc { get; set; }
        public string direccion { get; set; }
        public decimal telefono { get; set; }
        public string mail { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public char sexo { get; set; }
        public string estadoCivil { get; set; }
        public int cantidadFamiliares { get; set; }
        public decimal planMedicoCod { get; set; }
        public bool habilitado { get; set; }
        public decimal nroUltimaConsulta { get; set; }
        public decimal usuarioId { get; set; }

        public string planMedicoDescripcion { get; set; }

        public PlanMedico planMedico { get; set; }
        public List<Paciente> familiares { get; set; }

        public void addPaciente(Paciente paciente)
        {
            if (familiares == null)
            {
                this.familiares = new List<Paciente>();
            }
            this.familiares.Add(paciente);
        }

        public void removePaciente(Paciente paciente)
        {
            this.familiares.Remove(paciente);
        }

        public override bool Equals(object obj)
        {
            return ((Paciente)obj).tipoDoc == this.tipoDoc && ((Paciente)obj).nroDoc == this.nroDoc;
        }
    }
}
