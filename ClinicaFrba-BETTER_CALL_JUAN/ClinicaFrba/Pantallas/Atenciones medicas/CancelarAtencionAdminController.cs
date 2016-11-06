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
            throw new NotImplementedException();
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
                this.form.showErrorMessage("Ocurrio un error al buscar los turnos");
            }
        }
    }
}
