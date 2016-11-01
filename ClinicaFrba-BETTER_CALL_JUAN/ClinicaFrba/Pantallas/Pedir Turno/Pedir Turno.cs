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
    public partial class PedirTurnoForm : Form
    {
        private PedirTurnoController controller;

        public PedirTurnoForm()
        {
            this.controller = new PedirTurnoController(this);

            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.controller.llenarComboEspecialidades();
            };
        }

        internal void llenarComboEspecialidades(List<Especialidad> especialidades)
        {
            Especialidad especialidadDummy = new Especialidad();
            especialidadDummy.codigo = -1;
            especialidadDummy.descripcion = "Seleccione Especialidad";
            especialidades.Insert(0, especialidadDummy);

            Especialidad especialidadTodas = new Especialidad();
            especialidadTodas.codigo = 0;
            especialidadTodas.descripcion = "Todas";
            especialidades.Insert(1, especialidadTodas);

            this.comboEspecialidad.DataSource = especialidades;
            this.comboEspecialidad.DisplayMember = "descripcion";
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            string queryNombre = this.textBoxNombre.Text.Trim();
            string queryApellido = this.textBoxApellido.Text.Trim();
            int selectedIndexOfEspecialidades = this.comboEspecialidad.SelectedIndex;

            if (queryNombre.Length > 0 || queryApellido.Length > 0 || selectedIndexOfEspecialidades > 0)
            {
                this.buscarButton.Enabled = false;
                this.limpiarButton.Enabled = false;

                Especialidad especialidadSeleccionada = (Especialidad) this.comboEspecialidad.SelectedItem;
                this.controller.buscarProfesionalesConFiltros(queryNombre, queryApellido, especialidadSeleccionada);
            }
            else
            {
                this.showErrorMessage("Seleccione algun filtro para realizar su busqueda");
            }
        }

        internal void showErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal void llenarListadoProfesionalesConEspecialidad(Dictionary<Medico, Especialidad> medicosFiltradosConEspecialidad)
        {
            this.buscarButton.Enabled = true;
            this.limpiarButton.Enabled = true;

            medicosEspecialidadParaTurnoGrid.DataSource = medicosFiltradosConEspecialidad.Select(
                medicoConEspecialidad => new
                {
                    Matricula = medicoConEspecialidad.Key.matricula,
                    Apellido = medicoConEspecialidad.Key.apellido,
                    Nombre = medicoConEspecialidad.Key.nombre,
                    Especialidad = medicoConEspecialidad.Value.descripcion,
                    Codigo = medicoConEspecialidad.Value.codigo

                }
            ).ToList();

        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            this.comboEspecialidad.SelectedIndex = 0;
            this.textBoxApellido.Text = "";
            this.textBoxNombre.Text = "";
            this.medicosEspecialidadParaTurnoGrid.DataSource = null;
        }

        private void resultadosGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Medico medico = controller.obtenerMedico(medicosEspecialidadParaTurnoGrid);
            Especialidad especialidad = new Especialidad();
            especialidad.codigo = controller.obtenerCodigoEspecialidad(medicosEspecialidadParaTurnoGrid);
            especialidad.descripcion = controller.obtenerDescripcionEspecialidad(medicosEspecialidadParaTurnoGrid);
            DiasTurnoMedico dtm = new DiasTurnoMedico();
            dtm.showCalendario(medico,especialidad);
            this.Close();
        }
    }
}
