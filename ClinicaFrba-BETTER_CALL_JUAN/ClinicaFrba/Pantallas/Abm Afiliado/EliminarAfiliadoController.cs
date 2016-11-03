using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class EliminarAfiliadoController
    {
        private EliminarAfiliadoDialog form;
        private Paciente pacienteAEliminar;

        public EliminarAfiliadoController(EliminarAfiliadoDialog form)
        {
            this.form = form;
        }

        internal void setPacienteAEliminar(Paciente paciente)
        {
            this.pacienteAEliminar = paciente;
        }

        internal void eliminarAfiliado()
        {
            PacienteManager pacienteManager = new PacienteManager();
            pacienteAEliminar = pacienteManager.buscarAfiliadoPorTipoyNroDoc(pacienteAEliminar.tipoDoc, pacienteAEliminar.nroDoc);

            if (pacienteAEliminar != null)
            {
                bool afiliadoEliminado = pacienteManager.eliminarAfiliado(pacienteAEliminar);

                if (afiliadoEliminado)
                {
                    this.form.showInformationDialog("El Afiliado fue eliminado correctamente.");
                }
                else
                {
                    this.form.showErrorMessage("Ocurrio un error al intentar eliminar el usuario.");
                }
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al intentar eliminar el usuario.");
            }
        }
    }
}
