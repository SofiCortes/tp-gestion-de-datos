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
    public partial class ListadoProfesionales : Form
    {
        private List<string> tiposDocumentos = new List<string> { "Seleccionar Tipo de Documento", "Todos", "CI", "DNI", "LC", "LD"};

        private ListadoProfesionalesController controller;

        public ListadoProfesionales()
        {
            this.controller = new ListadoProfesionalesController(this);

            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.llenarComboTipoDoc();
                this.controller.llenarComboEspecialidades();
                this.controller.llenarListadoProfesionales();
            };
        }

        private void llenarComboTipoDoc()
        {
            this.comboTipoDoc.DataSource = tiposDocumentos;
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            this.comboEspecialidad.SelectedIndex = 0;
            this.comboTipoDoc.SelectedIndex = 0;
            this.textBoxApellido.Text = "";
            this.textBoxNombre.Text = "";
            this.textBoxDocumento.Text = "";
            this.textBoxMatricula.Text = "";
            this.resultadosGrid.DataSource = null;
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            string queryNombre = this.textBoxNombre.Text.Trim();
            string queryApellido = this.textBoxApellido.Text.Trim();
            string queryDocumento = this.textBoxDocumento.Text.Trim();
            string queryMatricula = this.textBoxMatricula.Text.Trim();
            int selectedIndexOfEspecialidades = this.comboEspecialidad.SelectedIndex;
            int selectedIndexOfTipoDoc = this.comboTipoDoc.SelectedIndex;

            if (queryNombre.Length > 0 || queryApellido.Length > 0 || queryDocumento.Length > 0
                || queryMatricula.Length > 0 || selectedIndexOfEspecialidades > 0 || selectedIndexOfTipoDoc > 0)
            {
                this.buscarButton.Enabled = false;
                this.limpiarButton.Enabled = false;

                Especialidad especialidadSeleccionada = (Especialidad)this.comboEspecialidad.SelectedItem;
                string tipoDocSeleccionado = (string)this.comboTipoDoc.SelectedItem;
                this.controller.buscarProfesionalesConFiltros(queryNombre, queryApellido, tipoDocSeleccionado, queryDocumento, queryMatricula, especialidadSeleccionada);
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

        internal void llenarListadoProfesionales(List<Medico> medicos)
        {
            this.buscarButton.Enabled = true;
            this.limpiarButton.Enabled = true;

            resultadosGrid.DataSource = medicos.Select(
                medico => new
                {
                    Matricula = medico.matricula,
                    Apellido = medico.apellido,
                    Nombre = medico.nombre,
                    Documento = medico.tipoDoc + " " + medico.nroDoc,
                    Sexo = medico.sexo.Equals('-') ? "-" : medico.sexo.Equals('M') ? "Masculino" : "Femenino"
                }
            ).ToList();
        }

        internal void keyPressNumericTextBox(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

    }
}
