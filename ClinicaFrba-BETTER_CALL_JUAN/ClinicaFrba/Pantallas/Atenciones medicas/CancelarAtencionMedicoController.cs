using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class CancelarAtencionMedicoController : IngresarMotivoYTipoCancelacionListener
    {
        private CancelarAtencionMedico form;
        private bool cancelarDiaSeleccionado;

        public CancelarAtencionMedicoController(CancelarAtencionMedico form)
        {
            this.form = form;
        }

        internal void cancelarRango(string motivo, TipoCancelacion tipoCancelacion)
        {
            decimal usuarioId = UsuarioConfiguracion.getInstance().getUsuarioId();
            DateTime fechaDesde = this.form.getFechaDesde();
            DateTime fechaHasta = this.form.getFechaHasta();

            TurnoManager turnoManager = new TurnoManager();
            bool rangoCancelado = turnoManager.cancelarRango(fechaDesde, fechaHasta, usuarioId, motivo, tipoCancelacion);

            if (rangoCancelado)
            {
                this.form.showInformationMessage("Los turnos dentro del rango fueron cancelados correctamente.");
                this.form.Close();
            }
            else
            {
                this.form.showInformationMessage("No se pudieron cancelar turnos en el rango de fecha");
            }
        }

        internal void cancelarDia(string motivo, TipoCancelacion tipoCancelacion)
        {
            this.cancelarDiaSeleccionado = true;
            decimal usuarioId = UsuarioConfiguracion.getInstance().getUsuarioId();
            DateTime fecha = this.form.getFecha();

            TurnoManager turnoManager = new TurnoManager();
            bool rangoCancelado = turnoManager.cancelarFecha(fecha, usuarioId, motivo, tipoCancelacion);

            if (rangoCancelado)
            {
                this.form.showInformationMessage("Los turnos del dia seleccionado fueron cancelados correctamente.");
                this.form.Close();
            }
            else
            {
                this.form.showInformationMessage("No se pudieron cancelar turnos en el rango de fecha");
            }
        }

        public void onMotivoYTipoCancelacionIngresados(string motivo, TipoCancelacion tipoCancelacion)
        {
            if (this.cancelarDiaSeleccionado)
            {
                this.cancelarDia(motivo, tipoCancelacion);
            }
            else
            {
                this.cancelarRango(motivo, tipoCancelacion);
            }
        }

        internal void mostrarIngresarMotivoYTipoCancelacionRango()
        {
            this.cancelarDiaSeleccionado = false;
            this.mostrarIngresarMotivoYTipoDialog();
        }

        internal void mostrarIngresarMotivoYTipoCancelacionDia()
        {
            this.cancelarDiaSeleccionado = true;
            this.mostrarIngresarMotivoYTipoDialog();
        }

        private void mostrarIngresarMotivoYTipoDialog()
        {
            IngresarMotivoYTipoCancelacion form = new IngresarMotivoYTipoCancelacion();
            form.setIngresarMotivoYTipoCancelacionListener(this);
            form.Show();
        }
    }
}
