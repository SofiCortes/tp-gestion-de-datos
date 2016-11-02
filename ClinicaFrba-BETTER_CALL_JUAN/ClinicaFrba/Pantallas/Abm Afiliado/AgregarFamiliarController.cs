using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class AgregarFamiliarController
    {
        private AgregarFamiliar form;
        private AgregarFamiliarListener listener;

        public AgregarFamiliarController(AgregarFamiliar form)
        {
            this.form = form;
        }

        internal void setAgregarFamiliarListener(AgregarFamiliarListener listener)
        {
            this.listener = listener;
        }

        internal void agregarFamiliar(Paciente paciente)
        {
            if (!this.listener.documentosNoSeRepitenParaFamiliar(paciente))
            {
                PacienteManager pacienteManager = new PacienteManager();
                bool puedeModificarse = pacienteManager.puedeGuardarseAfiliado(paciente.tipoDoc, paciente.nroDoc);

                if (puedeModificarse)
                {
                    this.listener.onFamiliarCreado(paciente);
                    this.form.Close();
                }
                else
                {
                    this.form.showErrorMessage("No puede ingresarse el Afiliado porque ya existe uno con el mismo Tipo y Numero de Documento");
                }
            }
            else
            {
                this.form.showErrorMessage("El Tipo y Numero de Documento ingresados corresponden a otro familiar.");
            }
        }
    }
}
