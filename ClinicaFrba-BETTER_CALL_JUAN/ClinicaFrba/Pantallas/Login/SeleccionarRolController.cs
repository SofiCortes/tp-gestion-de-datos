using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class SeleccionarRolController
    {
        private SeleccionarRol form;
        private SeleccionarRolListener listener;

        public SeleccionarRolController(SeleccionarRol form)
        {
            this.form = form;
        }

        public void setListener(SeleccionarRolListener listener)
        {
            this.listener = listener;
        }
    }
}
