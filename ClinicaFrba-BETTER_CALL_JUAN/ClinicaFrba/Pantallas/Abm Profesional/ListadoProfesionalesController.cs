using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class ListadoProfesionalesController
    {
        private ListadoProfesionales form;

        public ListadoProfesionalesController(ListadoProfesionales form)
        {
            this.form = form;
        }

        internal void llenarComboEspecialidades()
        {
            EspecialidadMedicaManager especialidadMedicaManager = new EspecialidadMedicaManager();
            List<Especialidad> especialidades = especialidadMedicaManager.findAll();

            if (especialidades != null)
            {
                this.form.llenarComboEspecialidades(especialidades);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al obtener las Especialidades.");
            }
        }

        internal void llenarListadoProfesionales()
        {
            ProfesionalManager profesionalManager = new ProfesionalManager();
            List<Medico> medicos = profesionalManager.findAll();

            if (medicos != null)
            {
                this.form.llenarListadoProfesionales(medicos);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al obtener los Profesionales.");
            }
        }

        internal void buscarProfesionalesConFiltros(string queryNombre, string queryApellido, string tipoDocSeleccionado, string queryDocumento, string queryMatricula, Especialidad especialidadSeleccionada)
        {
            decimal documento = queryDocumento.Length > 0 ? decimal.Parse(queryDocumento) : 0;
            decimal matricula = queryMatricula.Length > 0 ? decimal.Parse(queryMatricula) : 0;
            tipoDocSeleccionado = tipoDocSeleccionado.Equals("Seleccionar Tipo de Documento")
                || tipoDocSeleccionado.Equals("Todos")  ? "" : tipoDocSeleccionado;

            ProfesionalManager profesionalManager = new ProfesionalManager();
            List<Medico> medicosFiltrados = profesionalManager.buscarMedicosPorFiltro(queryNombre, queryApellido, tipoDocSeleccionado, documento, matricula, especialidadSeleccionada.codigo);

            if (medicosFiltrados != null)
            {
                this.form.llenarListadoProfesionales(medicosFiltrados);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al buscar los Profesionales.");
            }
        }
    }
}
