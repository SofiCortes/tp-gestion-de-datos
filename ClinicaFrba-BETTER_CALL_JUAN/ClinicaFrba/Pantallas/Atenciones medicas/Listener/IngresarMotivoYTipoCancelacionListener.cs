using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    public interface IngresarMotivoYTipoCancelacionListener
    {
        void onMotivoYTipoCancelacionIngresados(string motivo, TipoCancelacion tipoCancelacion);
    }
}
