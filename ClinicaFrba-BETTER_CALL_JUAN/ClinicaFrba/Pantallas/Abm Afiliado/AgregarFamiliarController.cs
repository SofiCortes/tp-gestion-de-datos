using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class AgregarFamiliarController
    {
        private AgregarFamiliar form;
        private AgregarFamiliarListener listener;

        public AgregarFamiliarController(AgregarFamiliar form)
        {
            this.form = form;
        }

        internal void setAgregarFamiliarListener(AgregarFamiliarListener listener)
        {
            this.listener = listener;
        }
    }
}
