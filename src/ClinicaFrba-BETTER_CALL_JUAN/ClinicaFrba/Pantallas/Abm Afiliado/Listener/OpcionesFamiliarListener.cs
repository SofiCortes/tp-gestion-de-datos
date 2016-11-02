﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    public interface OpcionesFamiliarListener
    {
        void onEliminarFamiliarSelected(Paciente paciente);

        void onModificarFamiliarSelected(Paciente paciente);
    }
}
