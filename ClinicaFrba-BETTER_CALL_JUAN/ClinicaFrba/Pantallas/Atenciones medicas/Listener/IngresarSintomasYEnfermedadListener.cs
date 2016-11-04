using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    public interface IngresarSintomasYEnfermedadListener
    {
        void onSintomasYEnfermadadesCompletadas(string sintomas, string enfermedades);
    }
}
