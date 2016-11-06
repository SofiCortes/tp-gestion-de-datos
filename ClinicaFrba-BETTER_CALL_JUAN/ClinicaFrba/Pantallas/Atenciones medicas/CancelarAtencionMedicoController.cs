using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class CancelarAtencionMedicoController
    {
        private CancelarAtencionMedico form;

        public CancelarAtencionMedicoController(CancelarAtencionMedico form)
        {
            this.form = form;
        }

        internal void cancelarRango(DateTime fechaDesde, DateTime fechaHasta)
        {
            decimal usuarioId = UsuarioConfiguracion.getInstance().getUsuarioId();
            TurnoManager turnoManager = new TurnoManager();
            bool rangoCancelado = turnoManager.cancelarRango(fechaDesde, fechaHasta, usuarioId);

            if (rangoCancelado)
            {
                this.form.showInformationMessage("Los turnos dentro del rango fueron cancelados correctamente.");
            }
            else
            {
                this.form.showInformationMessage("No se pudieron cancelar turnos en el rango de fecha");
            }
        }

        internal void cancelarDia(DateTime fecha)
        {
            decimal usuarioId = UsuarioConfiguracion.getInstance().getUsuarioId();
            TurnoManager turnoManager = new TurnoManager();
            bool rangoCancelado = turnoManager.cancelarFecha(fecha, usuarioId);

            if (rangoCancelado)
            {
                this.form.showInformationMessage("Los turnos del dia seleccionado fueron cancelados correctamente.");
            }
            else
            {
                this.form.showInformationMessage("No se pudieron cancelar turnos en el rango de fecha");
            }
        }
    }
}
