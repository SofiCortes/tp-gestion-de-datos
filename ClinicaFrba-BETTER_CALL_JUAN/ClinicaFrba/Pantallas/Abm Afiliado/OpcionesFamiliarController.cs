using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class OpcionesFamiliarController
    {
        private Paciente paciente;
        private OpcionesFamiliarListener listener;
        private OpcionesFamiliarDialog form;

        public OpcionesFamiliarController(OpcionesFamiliarDialog form)
        {
            this.form = form;
        }

        public void setPaciente(Paciente paciente)
        {
            this.paciente = paciente;
        }

        public void setOpcionesFamiliarListener(OpcionesFamiliarListener listener)
        {
            this.listener = listener;
        }

        internal void botonModificarSeleccionado()
        {
            this.listener.onModificarFamiliarSelected(paciente);
        }

        internal void botonEliminarSeleccionado()
        {
            this.listener.onEliminarFamiliarSelected(paciente);
        }
    }
}
