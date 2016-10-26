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
    public partial class ListadoRoles : Form
    {
        private ListadoRolesController controller;

        public ListadoRoles()
        {
            this.controller = new ListadoRolesController(this);

            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.controller.llenarListadoRoles(); 
            };
        }

        internal void ShowErrorDialog(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal void showRolesInTable(List<Rol> roles)
        {
            resultadosRolesGrid.DataSource = roles.Select(
                rol => new
                {
                    Nombre = rol.nombre,
                    Habilitado = rol.habilitado
                }
            ).ToList();
        }
    }
}
