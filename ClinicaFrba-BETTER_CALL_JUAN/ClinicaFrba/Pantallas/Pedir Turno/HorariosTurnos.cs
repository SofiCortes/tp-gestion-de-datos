using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    public partial class HorariosTurnos : Form
    {
        private HorariosTurnosController controller;
        private Medico medico;
        private Especialidad especialidad;
        private string fechaElegida;

        public HorariosTurnos()
        {
            this.controller = new HorariosTurnosController(this);
            InitializeComponent();
        }

        internal void setHorariosTurnosListener(HorariosTurnosListener listener)
        {
            this.controller.setHorariosTurnosListener(listener);
        }

        internal void showHorarios(Medico medico, Especialidad especialidad, string fechaElegida)
        {
            this.medico = medico;
            this.especialidad = especialidad;
            this.fechaElegida = fechaElegida;

            this.controller.llenarHorariosParaFecha(medico,especialidad,fechaElegida);

            this.Show();
        }

        internal void showErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal void llenarHorarios(List<string> horariosDisponibles)
        {
            HorariosDisponibles.DataSource = horariosDisponibles.Select(
               horario => new
               {
                   Horario = horario
               }
           ).ToList();
        }

        private void HorarioSeleccionadoButton_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection dataSelectedCell = HorariosDisponibles.SelectedCells;
            DataGridViewCell dgvc = dataSelectedCell[0];
            DataGridViewRow row = dgvc.OwningRow;

            string horarioElegido = row.Cells[0].Value.ToString();

            this.controller.pedirTurno(medico, especialidad, fechaElegida, horarioElegido);
        }


        internal void showInformationMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Informacion",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
