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
    public partial class CancelarAtencionAfiliado : Form
    {
        private CancelarAtencionAfiliadoController controller;

        public CancelarAtencionAfiliado()
        {
            this.controller = new CancelarAtencionAfiliadoController(this);

            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.controller.llenarComboMedicos();
            };
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.dateTimePicker.Value = DateTime.Now;
            this.comboBoxMedicos.SelectedIndex = 0;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            DateTime fechaBuscar = this.dateTimePicker.Value;
            Medico medico = (Medico)this.comboBoxMedicos.SelectedValue;

            if ((fechaBuscar - DateTime.Now).TotalDays < 1)
            {
                this.showErrorMessage("La fecha de un turno debe ser posterior a 1 dia a partir de hoy para poder cancelarlo.");
            }
            else
            {
                this.buttonBuscar.Enabled = false;
                this.buttonLimpiar.Enabled = false;

                this.controller.buscarTurnosConFiltros(fechaBuscar, medico.matricula);
            }
        }

        internal void llenarComboMedicos(List<Medico> medicosParaAfiliado)
        {
            Medico medicoDummy = new Medico();
            medicoDummy.matricula = -1;
            medicoDummy.nombre = "Seleccione Medico";
            medicoDummy.apellido = "";
            medicosParaAfiliado.Insert(0, medicoDummy);

            Medico medicoTodos = new Medico();
            medicoTodos.matricula = 0;
            medicoTodos.nombre = "Todos";
            medicoTodos.apellido = "";
            medicosParaAfiliado.Insert(1, medicoTodos);

            this.comboBoxMedicos.DataSource = medicosParaAfiliado;
            this.comboBoxMedicos.DisplayMember = "fullName";
        }

        internal void showErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal void llenarGrillaConTurnos(List<Turno> turnos)
        {
            this.buttonBuscar.Enabled = true;
            this.buttonLimpiar.Enabled = true;

            this.gridTurnos.DataSource = turnos.Select(
                turno => new
                {
                    Numero = turno.numero,
                    Fecha = Convert.ToString(turno.fechaHora),
                    Medico = turno.medico.apellido + ", " + turno.medico.nombre,
                    Especialidad = turno.especialidad.descripcion
                }
            ).ToList();
        }


        private void gridTurnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IngresarMotivoYTipoCancelacion form = new IngresarMotivoYTipoCancelacion();
            form.setIngresarMotivoYTipoCancelacionListener(this.controller);
            form.ShowDialog();
        }

        internal Turno getTurnoSeleccionado()
        {
            DataGridViewSelectedCellCollection dataSelectedCell = gridTurnos.SelectedCells;
            DataGridViewCell dgvc = dataSelectedCell[0];
            DataGridViewRow row = dgvc.OwningRow;

            Turno turno = new Turno();
            turno.numero = Convert.ToDecimal(row.Cells[0].Value.ToString());

            return turno;
        }

        internal void showInformationMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Informacion",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
