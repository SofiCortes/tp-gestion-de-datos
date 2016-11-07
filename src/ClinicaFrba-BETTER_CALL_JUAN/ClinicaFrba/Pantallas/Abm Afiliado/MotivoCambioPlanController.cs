using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class MotivoCambioPlanController
    {
        private MotivoCambioPlanDialog form;
        private MotivoCambioPlanListener listener;
        private Paciente pacienteParaModificar;

        public MotivoCambioPlanController(MotivoCambioPlanDialog form)
        {
            this.form = form;
        }

        public void setMotivoCambioPlanListener(MotivoCambioPlanListener listener)
        {
            this.listener = listener;
        }


        internal void cambiarDePlan(string motivoCambioPlan)
        {
            this.listener.onMotivoCambioPlanSeleccionado(motivoCambioPlan, this.pacienteParaModificar);
            this.form.Close();
        }

        internal void setPacienteModificado(Paciente paciente)
        {
            this.pacienteParaModificar = paciente;
        }
    }
}
