using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class EspecialidadConMasCancelacionesController
    {
        private EspecialidadConMasCancelaciones form;

        public EspecialidadConMasCancelacionesController(EspecialidadConMasCancelaciones form)
        {
            this.form = form;
        }

        internal void buscarEspecialidadesConFiltros(string autorCancelacion, string anioSeleccionado, string mesSeleccionado, string semestreSeleccionado)
        {
            char autorCancelacionChar = StoredProcedureHelper.getAutorCancelacionConTipo(autorCancelacion);
            mesSeleccionado = StoredProcedureHelper.getNumeroMesConNombreMes(mesSeleccionado);
            semestreSeleccionado = semestreSeleccionado.Equals("Primer semestre") ? "1" : "2";
            EstadisticasManager estadisticasManager = new EstadisticasManager();
            List<EspecialidadDAO> especialidades = estadisticasManager.getEspecialidadesConMasCancelaciones(autorCancelacionChar, anioSeleccionado, mesSeleccionado, semestreSeleccionado);

            if (especialidades != null)
            {
                this.form.showEspecialidades(especialidades);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al obtener las especialidades");
            }
        }

        internal void buscarAnios()
        {
            EstadisticasManager manager = new EstadisticasManager();
            List<int> anios = manager.getAniosEspecialidadesConMasCancelaciones();

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
