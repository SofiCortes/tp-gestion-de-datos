using ClinicaFrba.Modelo.BD.Manager.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class ListadoPlanesController
    {
        private ListadoPlanes form;

        public ListadoPlanesController(ListadoPlanes form)
        {
            this.form = form;
        }

        internal void llenarPlanesMedicos()
        {
            PlanManager manager = new PlanManager();
            List<PlanMedico> planes = manager.getPlanesMedicos();

            if (planes != null)
            {
                this.form.mostrarPlanesMedicos(planes);
            }
            else
            {
                this.form.showErroMessage("Ocurrio un error al mostrar los Planes Medicos.");
            }
        }

        internal void buscarPlanPorNombre(string queryPlan)
        {
            PlanManager manager = new PlanManager();
            List<PlanMedico> planes = manager.buscarPlanesMedicosPorNombre(queryPlan);

            if (planes != null)
            {
                this.form.mostrarPlanesMedicos(planes);
            }
            else
            {
                this.form.showErroMessage("Ocurrio un error al mostrar los Planes Medicos.");
            }
        }
    }
}
