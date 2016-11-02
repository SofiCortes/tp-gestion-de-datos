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
        private List<Paciente> familiaresAgregados;

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

        public void onFamiliarCreado(Paciente paciente)
        {
            if (this.familiaresAgregados == null)
            {
                this.familiaresAgregados = new List<Paciente>();
            }
            this.familiaresAgregados.Add(paciente);
        }

        internal void agregarAfiliado(Paciente paciente)
        {
            paciente.familiares = this.familiaresAgregados;
            PacienteManager pacienteManager = new PacienteManager();
            bool afiliadoAgregado = pacienteManager.agregarAfiliado(paciente);

            if (afiliadoAgregado)
            {
                this.form.showInformationMessage("El Afiliado fue dado de alta correctamente junto a toda su informacion");
                this.form.Close();
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al agregar el Afiliado");
            }
        }
    }
}
