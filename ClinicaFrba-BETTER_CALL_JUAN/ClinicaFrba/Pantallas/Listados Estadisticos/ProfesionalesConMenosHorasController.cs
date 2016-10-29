using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class ProfesionalesConMenosHorasController
    {
        private ProfesionalesConMenosHoras form;

        public ProfesionalesConMenosHorasController(ProfesionalesConMenosHoras form)
        {
            this.form = form;
        }


        internal void buscarEspecialidades()
        {
            ProfesionalManager profesionalManager = new ProfesionalManager();
            List<Especialidad> especialidades = profesionalManager.buscarEspecialidades();

            if (especialidades != null)
            {
                this.form.completarComboEspecialidades(especialidades);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al obtener las Especialidades");
            }
        }

        internal void buscarProfesionalesConFiltros(string anioSeleccionado, string semestreSeleccionado, string mesSeleccionado, string especialidadSeleccionada)
        {

        }
    }
}
