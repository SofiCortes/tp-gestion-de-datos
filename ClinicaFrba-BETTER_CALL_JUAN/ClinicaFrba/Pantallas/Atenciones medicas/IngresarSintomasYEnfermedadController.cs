using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class IngresarSintomasYEnfermedadController
    {
        private IngresarSintomasYEnfermedadDialog form;
        private IngresarSintomasYEnfermedadListener listener;

        public IngresarSintomasYEnfermedadController(IngresarSintomasYEnfermedadDialog form)
        {
            this.form = form;
        }

        internal void setIngresarSintomasyEnfermedadesListener(IngresarSintomasYEnfermedadListener listener)
        {
            this.listener = listener;
        }

        internal void sintomasYDiagnosticoCompletado(string sintomas, string diagnostico)
        {
            this.listener.onSintomasYEnfermadadesCompletadas(sintomas, diagnostico);
        }
    }
}
