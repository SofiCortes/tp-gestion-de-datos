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
           //Aca se muestran los roles
        }
    }
}
