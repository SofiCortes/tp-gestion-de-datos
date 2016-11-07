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
    public partial class CancelarAtencionAdmin : Form
    {
        private CancelarAtencionAdminController controller;

        public CancelarAtencionAdmin()
        {
            this.controller = new CancelarAtencionAdminController(this);

            InitializeComponent();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            DateTime hoy = ConfiguracionApp.getInstance().fechaActual;
            this.dateTimeTurno.Value = hoy;
            this.textBoxApellidoMedico.Text = "";
            this.textBoxApellidoPaciente.Text = "";
            this.textBoxNombreMedico.Text = "";
            this.textBoxNombrePaciente.Text = "";
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            DateTime hoy = ConfiguracionApp.getInstance().fechaActual;
            DateTime fechaBuscar = this.dateTimeTurno.Value;

            if ((fechaBuscar - hoy).TotalDays < 1)
            {
                this.showErrorMessage("La fecha de un turno debe ser posterior a 1 dia a partir de hoy para poder cancelarlo.");
            }
            else
            {
                string nombreMedico = this.textBoxNombreMedico.Text.Trim();
                string apellidoMedico = this.textBoxApellidoMedico.Text.Trim();
                string nombrePaciente = this.textBoxNombrePaciente.Text.Trim();
                string apellidoPaciente = this.textBoxApellidoPaciente.Text.Trim();

                this.controller.buscarTurnos(fechaBuscar, nombreMedico, apellidoMedico, nombrePaciente, apellidoPaciente);
            }
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
                    Especialidad = turno.especialidad.descripcion,
                    Paciente = turno.paciente.apellido + ", " + turno.paciente.nombre,
                    PacienteDocumento = turno.paciente.tipoDoc + " " + Convert.ToString(turno.paciente.nroDoc)
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
