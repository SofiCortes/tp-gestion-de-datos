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
    public partial class CancelarAtencionMedico : Form
    {
        private CancelarAtencionMedicoController controller;

        public CancelarAtencionMedico()
        {
            this.controller = new CancelarAtencionMedicoController(this);

            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.radioButtonCancelarDia.Select();
            };
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if (this.radioButtonCancelarDia.Checked)
            {
                this.validarCancelarDia();
            }
            else
            {
                this.validarCancelarRango();
            }
        }

        private void validarCancelarRango()
        {
            DateTime hoy = ArchivoConfig.getFechaDeHoy();

            DateTime fechaDesde = this.fechaDesde.Value;
            DateTime fechaHasta = this.fechaHasta.Value;

            if (fechaDesde.CompareTo(fechaHasta) >= 0)
            {
                this.showErrorMessage("La fecha hasta debe ser menor a la fecha desde");
            }
            else
            {
                if ((fechaDesde - hoy).TotalDays < 1)
                {
                    this.showErrorMessage("La fecha de cancelacion debe ser posterior a 1 dia a partir de hoy para poder cancelarlo.");
                }
                else
                {
                    this.controller.mostrarIngresarMotivoYTipoCancelacionRango();
                }
            }
        }

        private void validarCancelarDia()
        {
            DateTime hoy = ArchivoConfig.getFechaDeHoy();
            DateTime fecha = this.fecha.Value;
            if ((fecha - hoy).TotalDays < 1)
            {
                this.showErrorMessage("La fecha de cancelacion debe ser posterior a 1 dia a partir de hoy para poder cancelarlo.");
            }
            else
            {
                this.controller.mostrarIngresarMotivoYTipoCancelacionDia();
            }
        }

        internal void showErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal void showInformationMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Informacion",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal DateTime getFechaDesde()
        {
            return this.fechaDesde.Value.Date;
        }

        internal DateTime getFechaHasta()
        {
            return this.fechaHasta.Value.Date;
        }

        internal DateTime getFecha()
        {
            return this.fecha.Value.Date;
        }

        private void radioButtonCancelarDia_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCancelarDia.Checked)
            {
                this.groupboxDia.Visible = true;
                this.groupBoxRango.Visible = false;
            }
            else
            {
                this.groupboxDia.Visible = false;
                this.groupBoxRango.Visible = true;
            }
        }

        private void radioButtonCancelarPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCancelarPeriodo.Checked)
            {
                this.groupboxDia.Visible = false;
                this.groupBoxRango.Visible = true;
            }
            else
            {
                this.groupboxDia.Visible = true;
                this.groupBoxRango.Visible = false;
            }
        }
    }
}
