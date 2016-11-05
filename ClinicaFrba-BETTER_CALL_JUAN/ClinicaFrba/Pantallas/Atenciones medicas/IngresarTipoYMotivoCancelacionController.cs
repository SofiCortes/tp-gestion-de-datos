using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class IngresarTipoYMotivoCancelacionController
    {
        private IngresarMotivoYTipoCancelacion form;
        private IngresarMotivoYTipoCancelacionListener listener;

        public IngresarTipoYMotivoCancelacionController(IngresarMotivoYTipoCancelacion form)
        {
            this.form = form;
        }

        internal void setIngresarMotivoYTipoCancelacionListener(IngresarMotivoYTipoCancelacionListener listener)
        {
            this.listener = listener;
        }

        internal void registrarCancelacion(string motivoCancelacion, TipoCancelacion tipoCancelacion)
        {
            this.listener.onMotivoYTipoCancelacionIngresados(motivoCancelacion, tipoCancelacion);
            this.form.Close();
        }

        internal void llenarComboTipoCancelaciones()
        {
            TipoCancelacionManager tipoCancelacionmanager = new TipoCancelacionManager();
            List<TipoCancelacion> tipoCancelaciones = tipoCancelacionmanager.findAll();

            if (tipoCancelaciones != null)
            {
                this.form.llenarComboTipoCancelaciones(tipoCancelaciones);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al buscar los Tipos de Cancelaciones");
            }
        }
    }
}
