using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class AfiliadosConMasBonosController
    {
        private AfiliadosConMasBonos form;

        public AfiliadosConMasBonosController(AfiliadosConMasBonos form)
        {
            this.form = form;
        }


        internal void buscarAfiliadosConFiltros(string anioSeleccionado, string mesSeleccionado, string semestreSeleccionado)
        {
            mesSeleccionado = StoredProcedureHelper.getNumeroMesConNombreMes(mesSeleccionado);
            semestreSeleccionado = semestreSeleccionado.Equals("Primer semestre") ? "1" : "2";
            EstadisticasManager estadisticasManager = new EstadisticasManager();
            List<PacienteDAO> pacientes = estadisticasManager.getAfiliadosConMasBonos(anioSeleccionado, mesSeleccionado, semestreSeleccionado);

            if (pacientes != null)
            {
                this.form.showPacientes(pacientes);
            }
            else
            {
                this.form.showErrorMessage("No se pudieron encontrar afiliados que coincidan con su busqueda.");
            }
        
        }
    }
}
