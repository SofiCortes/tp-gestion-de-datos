using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    public interface AgregarFamiliarListener
    {
        void onFamiliarCreado(Paciente paciente);
        bool documentosNoSeRepitenParaFamiliar(Paciente paciente);
    }
}
