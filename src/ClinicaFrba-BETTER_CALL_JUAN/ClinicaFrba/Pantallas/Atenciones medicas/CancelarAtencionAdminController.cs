using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class CancelarAtencionAdminController : IngresarMotivoYTipoCancelacionListener
    {
        private CancelarAtencionAdmin form;

        public CancelarAtencionAdminController(CancelarAtencionAdmin form)
        {
            this.form = form;
        }

        public void onMotivoYTipoCancelacionIngresados(string motivo, TipoCancelacion tipoCancelacion)
        {
            Turno turnoSeleccionado = this.form.getTurnoSeleccionado();
            TurnoManager turnoManager = new TurnoManager();
            bool turnoCancelado = turnoManager.cancelarTurnoSinUsuarioId(turnoSeleccionado, motivo, tipoCancelacion);

            if (turnoCancelado)
            {
                this.form.showInformationMessage("El turno fue cancelado correctamente");
            }
            else
            {
                this.form.showErrorMessage("Ocurrió un error al cancelar el turno");
            }
        }

        internal void buscarTurnos(DateTime fechaBuscar, string nombreMedico, string apellidoMedico, string nombrePaciente, string apellidoPaciente)
        {
            TurnoManager turnoManager = new TurnoManager();
            List<Turno> turnos = turnoManager.buscarTurnosConFiltros(fechaBuscar, nombreMedico, apellidoMedico, nombrePaciente, apellidoPaciente);

            if (turnos != null)
            {
                this.form.llenarGrillaConTurnos(turnos);
            }
            else
            {
                this.form.showErrorMessage("Ocurrió un error al buscar los turnos");
            }
        }
    }
}
