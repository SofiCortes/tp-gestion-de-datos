﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class ComprarBonoController
    {
        private ComprarBono form;
        private PlanMedico planMedicoUsuario;

        public ComprarBonoController(ComprarBono form)
        {
            this.form = form;
        }

        internal void buscarPlanMedicoDelAfiliado()
        {
            PlanManager planManager = new PlanManager();
            PlanMedico planMedico = planManager.buscarPorUsuarioId(UsuarioConfiguracion.getInstance().getUsuarioId());

            if (planMedico != null)
            {
                if (planMedico.descripcion == null)
                {
                    this.form.showErrorMessage("Usted no posee un plan medico");
                    this.form.Close();
                }
                else
                {
                    this.planMedicoUsuario = planMedico;
                    this.form.showPlanMedico(planMedico.descripcion, planMedico.precioBonoConsulta);
                }
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al buscar su Plan medico.");
            }
        }

        internal void comprarBonos(decimal cantBonos)
        {
            decimal planCodigo = this.planMedicoUsuario.codigo;
            decimal usuarioId = UsuarioConfiguracion.getInstance().getUsuarioId();

            BonoManager bonoManager = new BonoManager();
            decimal montoAPagar = bonoManager.comprarBono(usuarioId, cantBonos, planCodigo);

            if (montoAPagar >= 0)
            {
                this.form.showInformationMessage("La compra fue realizada con exito. El monto a pagar es de $ " + Convert.ToString(montoAPagar));
                this.form.Close();
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al realizar la compra.");
            }
        }
    }
}
