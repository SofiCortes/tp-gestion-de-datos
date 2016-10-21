using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Modelo.BD.Manager.Implementacion
{
    class AfiliadoManager : AbstractManager
    {
        public AfiliadoManager()
            : base(new ConexionBD())
        {
        }

    }
}
