using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    class HorariosConsultasController
    {
        private HorariosConsultas form;

        public HorariosConsultasController(HorariosConsultas form)
        {
            this.form = form;
        }

        internal void buscarTurnosParaFechaActual(Medico medico, Especialidad especialidad)
        {
            ConsultaManager managerConsultas = new ConsultaManager();
            List<Turno> turnos = managerConsultas.getTurnosParaFechaDeHoy(medico, especialidad);

            if (turnos != null)
            {
                this.form.llenarTablaConTurnos(turnos);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al buscar los horarios.");
            }
        }

        internal Turno obtenerTurno(DataGridView gridTurnos)
        {
            DataGridViewSelectedCellCollection dataSelectedCell = gridTurnos.SelectedCells;
            DataGridViewCell dgvc = dataSelectedCell[0];
            DataGridViewRow row = dgvc.OwningRow;
            
            Turno turno = new Turno();
            turno.numero = Decimal.Parse(row.Cells[0].Value.ToString());
            turno.pacienteId = Decimal.Parse(row.Cells[1].Value.ToString());
            
            return turno;
        }

        internal void buscarBonosAfiliado(Turno turno)
        {
            BonoManager bonoManager = new BonoManager();
            int bonosDisponibles = bonoManager.getCantBonosAfiliado(turno.pacienteId);

            if (bonosDisponibles > -1)
            {
                if(bonosDisponibles > 0)
                {
                    ListadoBonos listadoBonos = new ListadoBonos();
                    listadoBonos.showBonos(turno);
                }
                else
                {
                   this.form.showErrorMessage("El afiliado no tiene bonos disponibles para la consulta.");
                }
                
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al buscar los bonos.");
            }

        }
    }
}
