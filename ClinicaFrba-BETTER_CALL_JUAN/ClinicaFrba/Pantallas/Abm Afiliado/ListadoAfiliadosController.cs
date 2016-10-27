using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class ListadoAfiliadosController
    {
        private ListadoAfiliados form;

        public ListadoAfiliadosController(ListadoAfiliados form)
        {
            this.form = form;
        }

        internal void llenarListadoAfiliados()
        {
            PacienteManager pacienteManager = new PacienteManager();
            List<Paciente> pacientes = pacienteManager.findAll();
            if (pacientes != null)
            {
                this.form.llenarListaConPacientes(pacientes);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al mostrar los Afiliados.");
            }
        }
    }
}
