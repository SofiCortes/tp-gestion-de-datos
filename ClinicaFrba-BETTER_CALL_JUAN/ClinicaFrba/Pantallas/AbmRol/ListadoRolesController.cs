using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    class ListadoRolesController
    {
        private ListadoRoles form;

        public ListadoRolesController(ListadoRoles form)
        {
            this.form = form;
        }

        public void llenarListadoRoles()
        {
            RolManager rolManager = new RolManager();
            List<Rol> roles = rolManager.buscarTodos();

            if (roles != null)
            {
                this.form.showRolesInTable(roles);
            }
            else
            {
                this.form.ShowErrorDialog("Ocurrio un error al obtener los Roles.");
            }
        }

        internal Rol obtenerRol(System.Windows.Forms.DataGridView resultadosRolesGrid)
        {
            DataGridViewSelectedCellCollection dataSelectedCell = resultadosRolesGrid.SelectedCells;
            DataGridViewCell dgvc = dataSelectedCell[0];
            Rol rol = new Rol();
            rol.nombre = dgvc.Value.ToString();
            return rol;
        }

        internal void eliminarRol(Rol rol)
        {
            RolManager rm = new RolManager();
            rol.id = rm.obtenerRolID(rol.nombre);
            rm.eliminarRol(rol);
        }

        internal void llenarListadoRolesHabilitados()
        {
            RolManager rolManager = new RolManager();
            List<Rol> roles = rolManager.buscarTodosHabilitados();

            if (roles != null)
            {
                this.form.showRolesInTable(roles);
            }
            else
            {
                this.form.ShowErrorDialog("Ocurrio un error al obtener los Roles.");
            }
        }
    }
}
