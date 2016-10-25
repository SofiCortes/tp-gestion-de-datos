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

        public SeleccionarRol(SeleccionarRolListener listener, List<Rol> roles)
        {
            this.controller = new SeleccionarRolController(this, listener);

            InitializeComponent();

            this.showRolesForSelection(roles);
        }

        private void showRolesForSelection(List<Rol> roles)
        {
            throw new NotImplementedException();
        }
    }
}
