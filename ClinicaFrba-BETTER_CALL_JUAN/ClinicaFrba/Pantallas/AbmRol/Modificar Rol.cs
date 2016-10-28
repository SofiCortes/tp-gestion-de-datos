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
    public partial class ModificarRol : Form
    {
        private ModificarRolController controller;
        private List<CheckBox> CBLFuncionalidades;
        private Rol rolAModif;

        public ModificarRol()
        {
            this.controller = new ModificarRolController(this);

            InitializeComponent();
        }

        internal void showModificarRol(Rol rol)
        {
            rolSeleccionado.Text = rol.nombre;
            rol.id = controller.obtenerRolID(rol);
            
            List<Funcionalidad> funcsDelRol = controller.obtenerTodasLasFuncionalidadesDelRol(rol.id);

            rolAModif = new Rol();
            rolAModif.id = rol.id;

            this.mostrarTodasLasFuncionalidades();
            this.mostrarFuncionalidadesDelRol(funcsDelRol);
            this.Show();
            
        }

        private void mostrarFuncionalidadesDelRol(List<Funcionalidad> funcsDelRol)
        {
            funcsDelRol.ForEach(func =>
            {
                this.CBLFuncionalidades.ForEach(cblf =>
                    {
                        if (cblf.Text == func.descripcion)
                        {
                          cblf.Checked = true;
                        }
                    });
            });
        }

        private void mostrarTodasLasFuncionalidades()
        {
            List<Funcionalidad> todasLasFuncionalidades = controller.obtenerTodasLasFuncionalidades();
            this.CBLFuncionalidades = new List<CheckBox>();
            int ycoords = 0;

            if (todasLasFuncionalidades != null)
            {
                todasLasFuncionalidades.ForEach(func =>
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

        internal void ShowErrorDialog(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (textBoxNombreNuevoRol.Text != "")
            {
                rolAModif.nombre = textBoxNombreNuevoRol.Text;
            }
            else
            {
                rolAModif.nombre = rolSeleccionado.Text;
            }

            if (this.CBLFuncionalidades.Any(cbf => cbf.Checked))
            {
                this.controller.modificarRol(rolAModif, this.CBLFuncionalidades);
                this.Close();
            }
            else
            {
                this.ShowErrorDialog("Debe seleccionar al menos una funcionalidad");
            }
        }
    }
}
