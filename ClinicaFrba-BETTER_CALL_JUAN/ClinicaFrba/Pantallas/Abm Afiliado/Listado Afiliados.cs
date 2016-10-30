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
    public partial class ListadoAfiliados : Form
    {
        private ListadoAfiliadosController controller;

        public ListadoAfiliados()
        {
            this.controller = new ListadoAfiliadosController(this);
            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.controller.llenarComboPlanes();
                this.controller.llenarListadoAfiliados();
            };
        }

        internal void showErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal void llenarListaConPacientes(List<Paciente> pacientes)
        {
            this.afiliadosGrid.DataSource = pacientes.Select(
                paciente => new
                {
                    NumeroAfiliado = paciente.nroRaiz + "-" + paciente.nroPersonal,
                    NombreyApellido = paciente.apellido + ", " + paciente.nombre,
                    Plan = paciente.planMedicoDescripcion
                }
            ).ToList();
        }

        internal void llenarComboPlanes(List<PlanMedico> planes)
        {
            PlanMedico planDummy = new PlanMedico();
            planDummy.codigo = -1;
            planDummy.descripcion = "Seleccione plan medico";
            planes.Insert(0, planDummy);

            PlanMedico planTodos = new PlanMedico();
            planTodos.codigo = 0;
            planTodos.descripcion = "Todos";
            planes.Insert(1, planTodos);

            this.comboPlanes.DataSource = planes;
            this.comboPlanes.DisplayMember = "descripcion";
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            this.textBoxNombre.Text = "";
            this.textBoxApellido.Text = "";
            this.afiliadosGrid.DataSource = null;
            this.comboPlanes.SelectedIndex = 0;
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            string queryNombre = this.textBoxNombre.Text;
            string queryApellido = this.textBoxApellido.Text;
            if (queryNombre.Trim().Length > 0 || queryApellido.Trim().Length > 0 || this.comboPlanes.SelectedIndex != 0)
            {
                PlanMedico planMedicoSeleccionado = (PlanMedico)this.comboPlanes.SelectedItem;
                this.controller.buscarAfiliados(queryNombre, queryApellido, planMedicoSeleccionado);
            }
            else
            {
                this.showErrorMessage("Complete algun filtro para poder realizar la busqueda");
            }
        }
    }
}
