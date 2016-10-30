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
            DataGridViewRow row = dgvc.OwningRow;
            Rol rol = new Rol();
            rol.nombre = row.Cells[0].Value.ToString();
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

        internal void buscarRolesPorNombre(string textoABuscar)
        {
            RolManager rolManager = new RolManager();
            List<Rol> roles = rolManager.buscarPorNombre(textoABuscar);

            if (roles != null)
            {
                this.form.showRolesInTable(roles);
            }
            else
            {
                this.form.ShowErrorDialog("Ocurrio un error al buscar los Roles.");
            }
        }

        internal void buscarRolesPorNombreHabilitados(string textoABuscar)
        {
            RolManager rolManager = new RolManager();
            List<Rol> roles = rolManager.buscarPorNombreHabilitados(textoABuscar);

            if (roles != null)
            {
                this.form.showRolesInTable(roles);
            }
            else
            {
                this.form.ShowErrorDialog("Ocurrio un error al buscar los Roles.");
            }
        }
    }
}
