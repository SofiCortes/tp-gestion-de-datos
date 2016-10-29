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
    public partial class ProfesionalesConMenosHoras : Form
    {
        private ProfesionalesConMenosHorasController controller;

        public ProfesionalesConMenosHoras()
        {
            this.controller = new ProfesionalesConMenosHorasController(this);

            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.llenarCombos();
                this.controller.buscarEspecialidades();
            };
        }

        private void llenarCombos()
        {
            this.comboAnio.DataSource = new List<string> { "Seleccione anio", "2015", "2016" };
            this.comboSemestre.DataSource = new List<string> { "Seleccione semestre", "Primer Semestre", "Segundo Semestre" };
            this.comboMes.DataSource = new List<string> { "Seleccione mes", "Todos", "Primer mes", "Segundo mes", "Tercer mes", "Cuarto mes", "Quinto mes", "Sexto mes" };
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            string anioSeleccionado = (string)this.comboAnio.SelectedItem;
            string semestreSeleccionado = (string)this.comboSemestre.SelectedItem;
            string mesSeleccionado = (string)this.comboMes.SelectedItem;
            string especialidadSeleccionada = (string)this.comboEspecialidad.SelectedItem;

            if (anioSeleccionado.Equals("Seleccione anio") || semestreSeleccionado.Equals("Seleccione semestre") ||
                mesSeleccionado.Equals("Seleccione mes") || especialidadSeleccionada.Equals("Seleccione especialidad"))
            {
                this.showErrorMessage("Seleccione los filtros correctamente");
            }
            else
            {
                this.controller.buscarProfesionalesConFiltros(anioSeleccionado, semestreSeleccionado, mesSeleccionado, especialidadSeleccionada);
            }
        }

        internal void showErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            this.comboAnio.SelectedItem = this.comboAnio.Items[0];
            this.comboSemestre.SelectedItem = this.comboSemestre.Items[0];
            this.comboMes.SelectedItem = this.comboMes.Items[0];
            this.comboEspecialidad.SelectedItem = this.comboEspecialidad.Items[0];
        }


        internal void completarComboEspecialidades(List<Especialidad> especialidades)
        {
            Especialidad especialidadDummy = new Especialidad();
            especialidadDummy.descripcion = "Seleccione especialidad";
            especialidades.Insert(0, especialidadDummy);

            Especialidad especialidadTodas = new Especialidad();
            especialidadTodas.descripcion = "Todas";
            especialidades.Insert(1, especialidadTodas);

            this.comboEspecialidad.DataSource = especialidades.Select(
                especialidad => especialidad.descripcion
            ).ToList();
        }
    }
}
