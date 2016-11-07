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
    public partial class ListadoEspecialidadesMedicas : Form
    {
        private ListadoEspecialidadesMedicasController controller;

        public ListadoEspecialidadesMedicas()
        {
            this.controller = new ListadoEspecialidadesMedicasController(this);

            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.controller.buscarTodasLasEspecialidades();
                this.controller.llenarListadoTipoEspecialidades();
            };
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            this.textBoxNombre.Text = "";
            this.comboTipoEspecialidad.SelectedIndex = 0;
            this.resultadosGrid.DataSource = null;
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            string query = this.textBoxNombre.Text;
            if (query.Trim().Length > 0 || this.comboTipoEspecialidad.SelectedIndex != 0)
            {
                this.buscarButton.Enabled = false;
                this.limpiarButton.Enabled = false;

                TipoEspecialidad tipoEspecialidadSeleccionada = (TipoEspecialidad)this.comboTipoEspecialidad.SelectedItem;
                this.controller.buscarEspecialidadesConFiltros(query, tipoEspecialidadSeleccionada);
            }
            else
            {
                this.showErrorMessage("Complete algun filtro para realizar la busqueda.");
            }
        }

        internal void showErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal void completarComboTipoEspecialidades(List<TipoEspecialidad> tipoEspecialidades)
        {
            TipoEspecialidad tipoEspecialidadDummy = new TipoEspecialidad();
            tipoEspecialidadDummy.codigo = -1;
            tipoEspecialidadDummy.descripcion = "Seleccione tipo de especialidad";
            tipoEspecialidades.Insert(0, tipoEspecialidadDummy);

            TipoEspecialidad tipoEspecialidadTodas = new TipoEspecialidad();
            tipoEspecialidadTodas.codigo = 0;
            tipoEspecialidadTodas.descripcion = "Todas";
            tipoEspecialidades.Insert(1, tipoEspecialidadTodas);

            this.comboTipoEspecialidad.DataSource = tipoEspecialidades;
            this.comboTipoEspecialidad.DisplayMember = "descripcion";
        }

        internal void llenarListadoConEspecialidades(List<Especialidad> especialidades)
        {
            this.buscarButton.Enabled = true;
            this.limpiarButton.Enabled = true;

            resultadosGrid.DataSource = especialidades.Select(
                especialidad => new
                {
                    Nombre = especialidad.descripcion,
                    Tipo = especialidad.tipoEspecialidad.descripcion
                }
            ).ToList();
        }
    }
}
