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
    public partial class SeleccionarRol : Form
    {
        private SeleccionarRolController controller;
        private List<RadioButton> radioButtonRoles;

        public SeleccionarRol()
        {
            this.controller = new SeleccionarRolController(this);

            InitializeComponent();
        }

        public void setSeleccionarRolListener(SeleccionarRolListener listener)
        {
            this.controller.setListener(listener);
        }

        public void setRoles(List<Rol> roles)
        {
            this.radioButtonRoles = new List<RadioButton>();
            int ycoords = 0;
            roles.ForEach(rol =>
                {
                    RadioButton radio = new RadioButton();
                    radio.Width = panelRadioButtons.Width;
                    radio.Location = new Point(10, ycoords);
                    radio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    radio.Text = rol.nombre;
                    panelRadioButtons.Controls.Add(radio);
                    ycoords += 30;
                    this.radioButtonRoles.Add(radio);
                });
        }

        private void buttonSeleccionarRol_Click(object sender, EventArgs e)
        {
            if (this.radioButtonRoles.Any(rb => rb.Checked))
            {
                Rol rol = new Rol();
                rol.nombre = this.radioButtonRoles.Find(rb => rb.Checked).Text;
                this.controller.onRolSeleccionado(rol);
                this.Close();
            }
            else
            {
                this.ShowErrorDialog("Debe seleccionar un rol");
            }
        }


        internal void ShowErrorDialog(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
