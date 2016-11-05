using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class CancelarAtencionAfiliadoController : IngresarMotivoYTipoCancelacionListener
    {
        private CancelarAtencionAfiliado form;

        public CancelarAtencionAfiliadoController(CancelarAtencionAfiliado form)
        {
            this.form = form;
        }

        internal void llenarComboMedicos()
        {
            TurnoManager turnoManager = new TurnoManager();
            List<Medico> medicosParaAfiliado = turnoManager.obtenerMedicosDeTurnosParaUsuario(UsuarioConfiguracion.getInstance().getUsuarioId());

            if (medicosParaAfiliado != null)
            {
                this.form.llenarComboMedicos(medicosParaAfiliado);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al buscar medicos asociados a sus turnos.");
            }
        }

        internal void buscarTurnos()
        {
            TurnoManager turnoManager = new TurnoManager();
            List<Turno> turnos = turnoManager.buscarTurnosParaUsuario(UsuarioConfiguracion.getInstance().getUsuarioId());

            if (turnos != null)
            {
                this.form.llenarGrillaConTurnos(turnos);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al buscar sus turnos.");
            }
        }


        internal void buscarTurnosConFiltros(DateTime fechaBuscar, decimal medicoMatricula)
        {
            decimal usuarioId = UsuarioConfiguracion.getInstance().getUsuarioId();
            TurnoManager turnoManager = new TurnoManager();
            List<Turno> turnos = turnoManager.buscarTurnosParaUsuarioConFiltros(fechaBuscar, medicoMatricula, usuarioId);

            if (turnos != null)
            {
                this.form.llenarGrillaConTurnos(turnos);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al buscar sus turnos.");
            }
        }

        public void onMotivoYTipoCancelacionIngresados(string motivo, TipoCancelacion tipoCancelacion)
        {
            Turno turno = this.form.getTurnoSeleccionado();
            decimal usuarioId = UsuarioConfiguracion.getInstance().getUsuarioId();

            TurnoManager turnoManager = new TurnoManager();
            bool turnoCancelado = turnoManager.cancelarTurno(usuarioId, turno, motivo, tipoCancelacion);

            if (turnoCancelado)
            {
                this.form.showInformationMessage("El turno fue cancelado correctamente");
                this.form.Close();
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al cancelar turno");
            }
        }
    }
}
