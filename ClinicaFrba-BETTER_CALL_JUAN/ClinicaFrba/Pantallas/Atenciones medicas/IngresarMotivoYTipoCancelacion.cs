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
    public partial class IngresarMotivoYTipoCancelacion : Form
    {
        private IngresarTipoYMotivoCancelacionController controller;

        public IngresarMotivoYTipoCancelacion()
        {
            this.controller = new IngresarTipoYMotivoCancelacionController(this);

            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.controller.llenarComboTipoCancelaciones();
            };
        }

        public void setIngresarMotivoYTipoCancelacionListener(IngresarMotivoYTipoCancelacionListener listener)
        {
            this.controller.setIngresarMotivoYTipoCancelacionListener(listener);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.comboBoxTipoCancelacion.SelectedIndex = 0;
            this.textBoxMotivo.Text = "";
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            TipoCancelacion tipoCancelacion = (TipoCancelacion)this.comboBoxTipoCancelacion.SelectedItem;
            string motivoCancelacion = this.textBoxMotivo.Text.Trim();
            if (motivoCancelacion.Length == 0 || tipoCancelacion.id <= 0)
            {
                this.controller.registrarCancelacion(motivoCancelacion, tipoCancelacion);
            }
            else
            {
                this.showErrorMessage("Complete todos los campos correctamente");
            }
        }

        internal void showErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal void llenarComboTipoCancelaciones(List<TipoCancelacion> tipoCancelaciones)
        {
            TipoCancelacion especialidadDummy = new TipoCancelacion();
            especialidadDummy.id = -1;
            especialidadDummy.nombre = "Seleccione Tipo de Cancelacion";
            tipoCancelaciones.Insert(0, especialidadDummy);

            this.comboBoxTipoCancelacion.DataSource = tipoCancelaciones;
            this.comboBoxTipoCancelacion.DisplayMember = "nombre";
        }
    }
}
