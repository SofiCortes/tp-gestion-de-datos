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

        internal void buscarAnios()
        {
            EstadisticasManager manager = new EstadisticasManager();
            List<int> anios = manager.getAniosProfesionalesMasConsultados();

            if (anios != null)
            {
                if (anios.Count > 0)
                {
                    List<string> aniosString = anios.ConvertAll<string>(delegate(int i) { return i.ToString(); });
                    this.form.llenarComboAnios(aniosString);
                }
                else
                {
                    this.form.showInformationMessage("No se pudieron encontrar anios para consultar.");
                    this.form.Close();
                }
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al obtener las fechas posibles de consulta");
                this.form.Close();
            }
        }
    }
}
