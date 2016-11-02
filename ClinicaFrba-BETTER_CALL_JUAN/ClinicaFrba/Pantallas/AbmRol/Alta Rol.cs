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
    public partial class AltaRol : Form
    {
        private AltaRolController controller;
        private List<CheckBox> CBLFuncionalidades;

        public AltaRol()
        {
            this.controller = new AltaRolController(this);

            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.showSeleccionFuncionalidades();
            };
        }

        internal void ShowErrorDialog(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void showSeleccionFuncionalidades()
        {
            List<Funcionalidad> funcionalidades = controller.obtenerTodasLasFuncionalidades();
            this.CBLFuncionalidades = new List<CheckBox>();
            int ycoords = 0;

            if (funcionalidades != null)
            {
                funcionalidades.ForEach(func =>
                {
                    CheckBox cbf = new CheckBox();
                    cbf.Width = funcPanel.Width;
                    cbf.Location = new Point(10, ycoords);
                    cbf.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    cbf.Text = func.descripcion;
                    cbf.Name = func.id.ToString();
                    funcPanel.Controls.Add(cbf);
                    ycoords += 30;
                    this.CBLFuncionalidades.Add(cbf);
                });

            }
            else
            {
                this.ShowErrorDialog("Error al cargar las funcionalidades");
            }
        }

        private void agregarRolButton_Click(object sender, EventArgs e)
        {
            if (this.CBLFuncionalidades.Any(cbf => cbf.Checked))
            {
                Rol rol = new Rol();

                if (RolNameTextBox.Text != "")
                {
                    rol.nombre = RolNameTextBox.Text;
                    this.controller.crearRolConFuncionesSeleccionadas(rol, this.CBLFuncionalidades);
                    this.Close();
                }
                else
                {
                    this.ShowErrorDialog("Ingrese un nombre para el rol");
                }
            }
            else
            {
                this.ShowErrorDialog("Debe seleccionar al menos una funcionalidad");
            }
        }

    }
}
