using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba
{
    class HorariosTurnosController
    {
         private HorariosTurnos form;

         public HorariosTurnosController(HorariosTurnos form)
        {
            this.form = form;
        }

        

         internal void llenarHorariosParaFecha(Medico medico, Especialidad especialidad, string fechaElegida)
         {
             TurnoManager managerTurnos = new TurnoManager();

             List<string> horariosDisponibles = managerTurnos.getHorariosDisponiblesParaFecha(medico,especialidad,fechaElegida);

             if (horariosDisponibles != null)
             {
                 this.form.llenarHorarios(horariosDisponibles);
             }
             else
             {
                 this.form.showErrorMessage("Ocurrio un error al buscar las Fechas.");
             }
         }

         internal void pedirTurno(Medico medico, Especialidad especialidad, string fechaElegida, string horarioElegido)
         {
             TurnoManager managerTurnos = new TurnoManager();

             managerTurnos.pedirTurno(medico, especialidad, fechaElegida, horarioElegido);
         }
    }
}
