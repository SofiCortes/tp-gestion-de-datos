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
    public partial class EspecialidadesConMasBonos : Form
    {
        private List<string> mesesPrimerSemestre = new List<string> { "Seleccione mes", "Todos", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio" };
        private List<string> mesesSegundoSemestre = new List<string> { "Seleccione mes", "Todos", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        private List<string> semestres = new List<string> { "Seleccione semestre", "Primer semestre", "Segundo semestre" };

        private EspecialidadConMasConsultasController controller;

        public EspecialidadesConMasBonos()
        {
            this.controller = new EspecialidadConMasConsultasController(this);

            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.controller.buscarAnios();
                this.llenarCombos();
            };
        }

        private void llenarCombos()
        {
            this.comboSemestre.Enabled = false;
            this.comboMes.Enabled = false;
        }

        private void comboAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAnio.SelectedIndex > 0)
            {
                comboSemestre.Enabled = true;
                comboSemestre.DataSource = semestres;
            }
            else
            {
                comboSemestre.DataSource = null;
                comboMes.DataSource = null;
                comboSemestre.Enabled = false;
                comboMes.Enabled = false;
            }
        }

        private void comboSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSemestre.SelectedIndex > 0)
            {
                comboMes.Enabled = true;
                if (comboSemestre.SelectedIndex == 1)
                {
                    comboMes.DataSource = mesesPrimerSemestre;
                }
                else if (comboSemestre.SelectedIndex == 2)
                {
                    comboMes.DataSource = mesesSegundoSemestre;
                }
            }
            else
            {
                comboMes.DataSource = null;
                comboMes.Enabled = false;
            }
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            this.comboAnio.SelectedItem = this.comboAnio.Items[0];
            this.comboSemestre.Enabled = false;
            this.comboMes.Enabled = false;
            this.resultadosTop5Grid.DataSource = null;
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            string anioSeleccionado = (string)this.comboAnio.SelectedItem;
            string mesSeleccionado = (string)this.comboMes.SelectedItem;
            string semestreSeleccionado = (string)this.comboSemestre.SelectedItem;

            if (anioSeleccionado.Equals("Seleccione año") || semestreSeleccionado.Equals("Seleccione semestre") ||
                mesSeleccionado.Equals("Seleccione mes"))
            {
                this.showErrorMessage("Seleccione los filtros correctamente");
            }
            else
            {
                this.buscarButton.Enabled = false;
                this.limpiarButton.Enabled = false;
                this.resultadosTop5Grid.DataSource = null;
                this.comboAnio.Enabled = false;
                this.comboSemestre.Enabled = false;
                this.comboMes.Enabled = false;

                this.controller.buscarEspecialidadesConFiltros(anioSeleccionado, mesSeleccionado, semestreSeleccionado);
            }
        }


        internal void showErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal void showEspecialidades(List<EspecialidadDAO> especialidades)
        {
            this.buscarButton.Enabled = true;
            this.limpiarButton.Enabled = true;
            this.comboAnio.Enabled = true;
            this.comboSemestre.Enabled = true;
            this.comboMes.Enabled = true;

            this.resultadosTop5Grid.DataSource = especialidades.Select(
                especialidad => new
                {
                    Nombre = especialidad.especialidad.descripcion,
                    BonosComprados = especialidad.cantBonosUtilizados
                }
            ).ToList();
        }

        internal void showInformationMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Informacion",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal void llenarComboAnios(List<string> anios)
        {
            anios.Insert(0, "Seleccione anio");
            this.comboAnio.DataSource = anios;
        }
    }
}
