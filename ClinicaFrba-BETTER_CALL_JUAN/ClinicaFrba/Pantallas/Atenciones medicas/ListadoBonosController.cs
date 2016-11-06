﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba
{
    class ListadoBonosController
    {
        private ListadoBonos form;
        
        public ListadoBonosController(ListadoBonos form)
        {
            this.form = form;
        }


        public void registrarLlegadaConsulta(Turno turno, decimal bonoId)
        {
            /*DataGridViewRow row = this.form.getConsultaSeleccionada();

            decimal idConsulta = Decimal.Parse(row.Cells[0].Value.ToString());*/

            ConsultaManager consultaManager = new ConsultaManager();
            int registroConsulta = consultaManager.registrarLlegada(turno, DateTime.Now, bonoId);
            
            if (registroConsulta > 0)
            {
                this.form.showInformationMessage("La consulta fue registrada con éxito");
                this.form.Close();
            }
            else
            {
                this.form.showErrorMessage("Ocurrió un error al registrar la consulta");
            }
        }

        internal void listarBonosDelPaciente(decimal pacienteId)
        {
            BonoManager bonoManager = new BonoManager();

            List<BonoConsulta> bonosDisponibles = bonoManager.getBonosDisponibles(pacienteId);

            if (bonosDisponibles != null)
            {
                this.form.llenarBonos(bonosDisponibles);
            }
            else
            {
                this.form.showErrorMessage("Ocurrió un error al buscar los bonos");
            }
        }
    }
}
