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
    public partial class ListadoPlanes : Form
    {
        private ListadoPlanesController controller;

        public ListadoPlanes()
        {
            this.controller = new ListadoPlanesController(this);

            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.controller.llenarPlanesMedicos();
            };
        }

        internal void mostrarPlanesMedicos(List<PlanMedico> planes)
        {
            this.buscarButton.Enabled = true;
            this.limpiarButton.Enabled = true;

            this.planesGrid.DataSource = planes.Select(
                plan => new
                {
                    Nombre = plan.descripcion,
                    PrecioConsulta = "$ " + plan.precioBonoConsulta,
                    PrecioFarmacia = "$ " + plan.precioBonoFarmacia
                }
            ).ToList();
        }

        internal void showErroMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            this.textBoxPlan.Text = "";
            this.planesGrid.DataSource = null;
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            string queryPlan = this.textBoxPlan.Text.Trim();
            if (queryPlan.Length > 0)
            {
                this.buscarButton.Enabled = false;
                this.limpiarButton.Enabled = false;

                this.controller.buscarPlanPorNombre(queryPlan);
            }
            else
            {
                this.showErroMessage("Complete el filtro necesario para realizar la busqueda.");
            }
        }
    }
}
