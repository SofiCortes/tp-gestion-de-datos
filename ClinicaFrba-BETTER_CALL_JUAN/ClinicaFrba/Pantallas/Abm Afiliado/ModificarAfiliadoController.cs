using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class ModificarAfiliadoController : MotivoCambioPlanListener
    {
        private Paciente pacienteAModificar;
        private ModificarAfiliado form;

        public ModificarAfiliadoController(ModificarAfiliado form)
        {
            this.form = form;
        }

        public void setPacienteAModificar(Paciente pacienteAModificar)
        {
            PacienteManager pacienteManager = new PacienteManager();
            Paciente paciente = pacienteManager.buscarAfiliadoPorTipoyNroDoc(pacienteAModificar.tipoDoc, pacienteAModificar.nroDoc);
            this.pacienteAModificar = paciente;
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

        internal void modificarAfiliado(Paciente paciente)
        {
            PacienteManager pacienteManager = new PacienteManager();
            paciente.id = this.pacienteAModificar.id;

            bool puedeModificar;
            if (paciente.tipoDoc.Equals(this.pacienteAModificar.tipoDoc) && paciente.nroDoc.Equals(this.pacienteAModificar.nroDoc))
            {
                puedeModificar = true;
            }
            else
            {
                puedeModificar = pacienteManager.puedeGuardarseAfiliado(paciente.tipoDoc, paciente.nroDoc);
            }

            if (puedeModificar)
            {
                if(!paciente.planMedicoCod.Equals(this.pacienteAModificar.planMedicoCod))
                {
                    MotivoCambioPlanDialog form = new MotivoCambioPlanDialog();
                    form.setMotivoCambioPlanListener(this);
                    form.setPacienteModificado(paciente);
                    form.ShowDialog();
                }
                else
                {
                    bool pacienteModificado = pacienteManager.modificarAfiliado(this.pacienteAModificar.planMedicoCod, paciente, "");
                    if (pacienteModificado)
                    {
                        this.form.showInformationMessage("El Afiliado fue modificado correctamente");
                        this.form.Close();
                    }
                    else
                    {
                        this.form.showErrorMessage("Ocurrio un error al modificar el Afiliado. Intentelo nuevamente");
                    }
                }
            }
            else
            {
                this.form.showErrorMessage("El Afiliado no pude utilizar un Tipo y Numero de Documento ya existente.");
            }
        }

        internal Paciente getPacienteAModificar()
        {
            return this.pacienteAModificar;
        }

        public void onMotivoCambioPlanSeleccionado(string motivo, Paciente pacienteModificado)
        {
            PacienteManager pacienteManager = new PacienteManager();
            bool modificado = pacienteManager.modificarAfiliado(this.pacienteAModificar.planMedicoCod, pacienteModificado, motivo);
            if (modificado)
            {
                this.form.showInformationMessage("El Afiliado fue modificado correctamente");
                this.form.Close();
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al modificar el Afiliado. Intentelo nuevamente");
            }
        }
    }
}
