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

        internal void buscarProfesionalesConFiltros(string semestreSeleccionado, string anioSeleccionado, string mesSeleccionado, Especialidad especialidadSeleccionada)
        {
            decimal especialidadCod = especialidadSeleccionada.codigo;
            semestreSeleccionado = semestreSeleccionado.Equals("Primer semestre") ? "1" : "2";
            mesSeleccionado = StoredProcedureHelper.getNumeroMesConNombreMes(mesSeleccionado);
            EstadisticasManager estadisticasManager = new EstadisticasManager();
            List<MedicoDAO> medicos = estadisticasManager.getProfesionalesConMenosHoras(semestreSeleccionado, anioSeleccionado, mesSeleccionado, especialidadCod);

            if (medicos != null)
            {
                this.form.showListado(medicos);
            }
            else
            {
                this.form.showErrorMessage("No se encontro ningun Profesional para la busqueda realizada.");
            }
        }

    }
}
