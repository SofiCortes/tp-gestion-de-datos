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
    public partial class ListadoBonos : Form
    {
        private ListadoBonosController controller;
        private Turno turno;

        public ListadoBonos()
        {
            this.controller = new ListadoBonosController(this);
            InitializeComponent();
        }

        internal void llenarBonos(List<BonoConsulta> bonosDisponibles)
        {
            gridBonos.DataSource = bonosDisponibles.Select(
                bono => new
                {
                    Bono = bono.id,
                    FechaCompra = Convert.ToString(bono.fechaCompra)
                }
            ).ToList();
        }

        private void BonoSeleccionadoButton_Click(object sender, EventArgs e)
        {
            if (gridBonos.SelectedCells.Count == 0)
            {
                this.showErrorMessage("Debe seleccionar un bono.");
            }
            else
            {
                DataGridViewSelectedCellCollection dataSelectedCell = gridBonos.SelectedCells;
                DataGridViewCell dgvc = dataSelectedCell[0];
                DataGridViewRow row = dgvc.OwningRow;
                decimal idBono = Decimal.Parse(row.Cells[0].Value.ToString());

                this.controller.registrarLlegadaConsulta(turno, idBono);
            }

        }

        internal void showErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal void showInformationMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Informacion",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal void showBonos(Turno turno)
        {
            this.turno = turno;
            this.controller.listarBonosDelPaciente(turno.pacienteId);
            this.Show();
        }
    }
}
