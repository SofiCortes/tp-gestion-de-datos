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
    }
}
