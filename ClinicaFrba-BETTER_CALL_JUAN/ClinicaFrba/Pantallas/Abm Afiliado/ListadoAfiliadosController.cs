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

        internal void llenarComboPlanes()
        {
            PlanManager planManager = new PlanManager();
            List<PlanMedico> planes = planManager.getPlanesMedicos();
            if (planes != null)
            {
                this.form.llenarComboPlanes(planes);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al obtener los Planes.");
            }
        }

        internal void buscarAfiliados(string queryNombre, string queryApellido, PlanMedico planMedicoSeleccionado)
        {
            PacienteManager pacienteManager = new PacienteManager();
            List<Paciente> pacientes = pacienteManager.buscarAfiliadosPorNombreYPlan(queryNombre, queryApellido, planMedicoSeleccionado.codigo);

            if (pacientes != null)
            {
                this.form.llenarListaConPacientes(pacientes);
            }
            else
            {
                this.form.showErrorMessage("No se encontraron afiliados que coincidan con su busqueda");
            }
        }
    }
}
