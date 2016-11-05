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
    public partial class RegistrarResultadoConsulta : Form
    {
        private RegistrarResultadoConsultaController controller;

        public RegistrarResultadoConsulta()
        {
            this.controller = new RegistrarResultadoConsultaController(this);

            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.controller.llenarComboEspecialidades();
            };
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxNombre.Text = "";
            this.textBoxApellido.Text = "";
            this.comboEspecialidad.SelectedIndex = 0;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            string nombre = this.textBoxNombre.Text.Trim();
            string apellido = this.textBoxApellido.Text.Trim();
            if ((nombre.Length == 0 && apellido.Length == 0) ||
                this.comboEspecialidad.SelectedIndex == 0)
            {
                this.buttonLimpiar.Enabled = false;
                this.buttonBuscar.Enabled = false;
                this.showErrorMessage("Debe seleccionar obligatoriamente una especialidad y el nombre o apellido del Paciente en cuestion");
            }
            else
            {
                Especialidad especialidadMedica = (Especialidad)this.comboEspecialidad.SelectedItem;
                this.controller.buscarConsultas(nombre, apellido, especialidadMedica);
            }
        }

        internal void showErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal void llenarComboEspecialidades(List<Especialidad> especialidadesDelMedico)
        {
            Especialidad especialidadDummy = new Especialidad();
            especialidadDummy.codigo = -1;
            especialidadDummy.descripcion = "Seleccione Especialidad";
            especialidadesDelMedico.Insert(0, especialidadDummy);

            this.comboEspecialidad.DataSource = especialidadesDelMedico;
            this.comboEspecialidad.DisplayMember = "descripcion";
        }

        internal void llenarTablaConConsultas(List<Consulta> consultas)
        {
            this.buttonLimpiar.Enabled = true;
            this.buttonBuscar.Enabled = true;

            gridConsultas.DataSource = consultas.Select(
                consulta => new
                {
                    Consulta = consulta.id,
                    NombreYApellido = consulta.paciente.apellido + ", " + consulta.paciente.nombre,
                    FechaLlegada = Convert.ToString(consulta.fechaHoraLlegada),
                    Especialidad = consulta.especialidad.descripcion
                }
            ).ToList();
        }

        private void gridConsultas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IngresarSintomasYEnfermedadDialog form = new IngresarSintomasYEnfermedadDialog();
            form.setIngresarSintomasYEnfermedadesListener(this.controller);
            form.ShowDialog();
        }

        internal DataGridViewRow getConsultaSeleccionada()
        {
            DataGridViewSelectedCellCollection dataSelectedCell = gridConsultas.SelectedCells;
            DataGridViewCell dgvc = dataSelectedCell[0];
            return dgvc.OwningRow;
        }

        internal void showInformationMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Informacion",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
