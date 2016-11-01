using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class DiasTurnoMedicoController
    {
        private DiasTurnoMedico form;

        public DiasTurnoMedicoController(DiasTurnoMedico form)
        {
            this.form = form;
        }


        internal void getFechasDisponibles(Medico medico, Especialidad especialidad)
        {
            TurnoManager turnoManager = new TurnoManager();

            List<string> fechasDisponibles = turnoManager.getFechasDisponibles(medico, especialidad);

            if (fechasDisponibles != null)
            {
                this.form.llenarFechas(fechasDisponibles);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al buscar las Fechas.");
            }
        }
    }
}
