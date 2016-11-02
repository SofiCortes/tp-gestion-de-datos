﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    public interface ModificarFamiliarListener
    {
        void onFamiliarModificado(Paciente paciente);
        bool documentosNoSeRepitenParaFamiliar(Paciente paciente);
    }
}
