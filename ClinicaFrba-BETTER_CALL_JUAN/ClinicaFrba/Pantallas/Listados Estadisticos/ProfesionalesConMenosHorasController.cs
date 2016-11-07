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
            EspecialidadMedicaManager especialidadMedicaManager = new EspecialidadMedicaManager();
            List<Especialidad> especialidades = especialidadMedicaManager.findAll();

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

        internal void buscarAnios()
        {
            EstadisticasManager manager = new EstadisticasManager();
            List<int> anios = manager.getAniosProfesionalesConMenosHoras();

            if (anios != null)
            {
                if (anios.Count > 0)
                {
                    List<string> aniosString = anios.ConvertAll<string>(delegate(int i) { return i.ToString(); });
                    this.form.llenarComboAnios(aniosString);
                }
                else
                {
                    this.form.showInformationMessage("No se pudieron encontrar años para consultar.");
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
