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
            if (this.listener.documentosNoSeRepitenParaFamiliar(paciente))
            {
                this.form.showErrorMessage("El Tipo y Numero de Documento ingresados corresponden a otro familiar.");
            }
            else
            {
                PacienteManager pacienteManager = new PacienteManager();
                bool puedeModificarse = pacienteManager.puedeGuardarseAfiliado(paciente.tipoDoc, paciente.nroDoc);

                if (puedeModificarse)
                {
                    this.listener.onFamiliarModificado(paciente);
                    this.form.Close();
                }
                else
                {
                    this.form.showErrorMessage("No puede ingresarse el Afiliado porque ya existe uno con el mismo Tipo y Numero de Documento");
                }
            }
        }
    }
}
