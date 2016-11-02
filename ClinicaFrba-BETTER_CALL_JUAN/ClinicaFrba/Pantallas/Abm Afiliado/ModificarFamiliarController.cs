using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class ModificarFamiliarController
    {
        private Paciente pacienteAModificar { get; set; }
        private ModificarFamiliarListener listener { get; set; }
        private ModificarFamiliar form;

        public ModificarFamiliarController(ModificarFamiliar form)
        {
            this.form = form;
        }

        internal void setModificarFamiliarListener(ModificarFamiliarListener listener)
        {
            this.listener = listener;
        }

        internal void setPacienteAModificar(Paciente pacienteAModificar)
        {
            this.pacienteAModificar = pacienteAModificar;
        }

        internal Paciente getPacienteAModificar()
        {
            return this.pacienteAModificar;
        }

        internal void modificarFamiliar(Paciente paciente)
        {
            this.listener.onFamiliarModificado(paciente);
        }
    }
}
