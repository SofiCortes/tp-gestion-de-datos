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

        internal void buscarAnios()
        {
            EstadisticasManager manager = new EstadisticasManager();
            List<int> anios = manager.getAniosAfiliadosConMasBonos();

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
