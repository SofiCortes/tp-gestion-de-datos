using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    public class AltaAfiliadoController : AgregarFamiliarListener
    {
        private AltaAfiliado form;

        public AltaAfiliadoController(AltaAfiliado form)
        {
            this.form = form;
        }

        internal void buscarPlanesParaCombo()
        {
            PlanManager planManager = new PlanManager();
            List<PlanMedico> planesMedicos = planManager.getPlanesMedicos();

            if (planesMedicos != null)
            {
                this.form.llenarComboPlanesMedicos(planesMedicos);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al obtener los Planes Medicos");
            }
        }
    }
}
