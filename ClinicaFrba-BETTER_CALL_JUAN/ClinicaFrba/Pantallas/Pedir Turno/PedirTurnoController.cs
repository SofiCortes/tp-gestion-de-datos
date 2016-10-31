using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class PedirTurnoController
    {

        private PedirTurnoForm form;

        public PedirTurnoController(PedirTurnoForm form)
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



        internal void buscarProfesionalesConFiltros(string queryNombre, string queryApellido, Especialidad especialidadSeleccionada)
        {
            ProfesionalManager profesionalManager = new ProfesionalManager();
            Dictionary<Medico,String> medicosFiltrados = profesionalManager.buscarMedicosConSuEspecialidad(queryNombre, queryApellido, especialidadSeleccionada.codigo);

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
