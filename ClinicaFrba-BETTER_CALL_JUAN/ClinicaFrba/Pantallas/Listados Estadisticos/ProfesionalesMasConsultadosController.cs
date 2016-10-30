using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class ProfesionalesMasConsultadosController
    {
        private ProfesionalesMasConsultados form;

        public ProfesionalesMasConsultadosController(ProfesionalesMasConsultados form)
        {
            this.form = form;
        }

        internal void buscarPlanes()
        {
            PlanManager planManager = new PlanManager();
            List<PlanMedico> planes = planManager.getPlanesMedicos();

            if (planes != null)
            {
                this.form.completarComboPlanes(planes);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al obtener los Planes");
            }
        }

        internal void buscarProfesionalesConFiltros(string semestreSeleccionado, string anioSeleccionado, string mesSeleccionado, PlanMedico planMedicoSeleccionado)
        {
            decimal planMedicoCod = planMedicoSeleccionado.codigo;
            semestreSeleccionado = semestreSeleccionado.Equals("Primer semestre") ? "1" : "2";
            mesSeleccionado = StoredProcedureHelper.getNumeroMesConNombreMes(mesSeleccionado);
            EstadisticasManager estadisticasManager = new EstadisticasManager();
            List<MedicoDAO> medicos = estadisticasManager.getProfesionalesMasConsultados(semestreSeleccionado, anioSeleccionado, mesSeleccionado, planMedicoCod);

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
