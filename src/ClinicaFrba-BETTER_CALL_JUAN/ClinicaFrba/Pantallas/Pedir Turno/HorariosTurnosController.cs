using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba
{
    class HorariosTurnosController
    {
        private HorariosTurnosListener listener;
        private HorariosTurnos form;

        public HorariosTurnosController(HorariosTurnos form)
        {
            this.form = form;
        }

        internal void llenarHorariosParaFecha(Medico medico, Especialidad especialidad, string fechaElegida)
        {
            TurnoManager managerTurnos = new TurnoManager();

            List<string> horariosDisponibles = managerTurnos.getHorariosDisponiblesParaFecha(medico, especialidad, fechaElegida);

            if (horariosDisponibles != null)
            {
                this.form.llenarHorarios(horariosDisponibles);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al buscar las Fechas.");
            }
        }

        internal void pedirTurno(decimal paciente_id,Medico medico, Especialidad especialidad, string fechaElegida, string horarioElegido)
        {
            TurnoManager managerTurnos = new TurnoManager();
            bool turnoPedido;

            if(paciente_id!=0)
             turnoPedido = managerTurnos.pedirTurnoAdministrativo(paciente_id,medico, especialidad, fechaElegida, horarioElegido);
            else
                turnoPedido = managerTurnos.pedirTurnoAfiliado(medico, especialidad, fechaElegida, horarioElegido);

            if (turnoPedido)
            {
                this.form.showInformationMessage("Su turno fue solicitado con exito");
                this.listener.onHorariosTurnosClosed();
                this.form.Close();
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al solicitar el Turno, por favor intentelo de nuevo.");
                this.form.Close();
            }
        }

        internal void setHorariosTurnosListener(HorariosTurnosListener listener)
        {
            this.listener = listener;
        }
    }
}
