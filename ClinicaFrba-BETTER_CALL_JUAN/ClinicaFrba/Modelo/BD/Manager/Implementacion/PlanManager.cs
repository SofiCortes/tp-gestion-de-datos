using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Modelo.BD.Manager.Implementacion
{
    class PlanManager : AbstractManager
    {
        public PlanManager()
            : base(new ConexionBD())
        {
        }

    }
}
