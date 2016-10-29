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

        private void resultadosRolesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (this.actionCode == ACTION_CODE_FOR_LIST_MODIFY_ROL)
            {
                Rol rol = controller.obtenerRol(resultadosRolesGrid);
                ModificarRol mr = new ModificarRol();
                mr.showModificarRol(rol);
                this.Close();
            }
            else
            {
                if (this.actionCode == ACTION_CODE_FOR_LIST_DELETE_ROL)
                {
                    Rol rol = controller.obtenerRol(resultadosRolesGrid);
                    controller.eliminarRol(rol);
                    this.Close();
                }
            }
        }

    }
}
