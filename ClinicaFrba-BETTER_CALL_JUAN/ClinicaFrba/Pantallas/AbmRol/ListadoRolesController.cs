using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
