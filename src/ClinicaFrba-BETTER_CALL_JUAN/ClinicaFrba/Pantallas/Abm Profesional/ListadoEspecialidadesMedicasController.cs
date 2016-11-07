using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class ListadoEspecialidadesMedicasController
    {
        private ListadoEspecialidadesMedicas form;

        public ListadoEspecialidadesMedicasController(ListadoEspecialidadesMedicas form)
        {
            this.form = form;
        }

        internal void llenarListadoTipoEspecialidades()
        {
            TipoEspecialidadManager tipoEspecialidadManager = new TipoEspecialidadManager();
            List<TipoEspecialidad> tipoEspecialidades = tipoEspecialidadManager.findAll();

            if (tipoEspecialidades != null)
            {
                this.form.completarComboTipoEspecialidades(tipoEspecialidades);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al buscar los Tipos de Especialidades.");
            }
        }

        internal void buscarEspecialidadesConFiltros(string query, TipoEspecialidad tipoEspecialidadSeleccionada)
        {
            EspecialidadMedicaManager especialidadMedicaManager = new EspecialidadMedicaManager();
            List<Especialidad> especialidades = especialidadMedicaManager.buscarConFiltros(query, tipoEspecialidadSeleccionada.codigo);

            if (especialidades != null)
            {
                this.form.llenarListadoConEspecialidades(especialidades);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al buscar las especialidades.");
            }
        }

        internal void buscarTodasLasEspecialidades()
        {
            EspecialidadMedicaManager especialidadMedicaManager = new EspecialidadMedicaManager();
            List<Especialidad> especialidades = especialidadMedicaManager.findAll();

            if (especialidades != null)
            {
                this.form.llenarListadoConEspecialidades(especialidades);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al traer las especialidades.");
            }
        }
    }
}
