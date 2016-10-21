using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class BonoManager : AbstractManager
    {
        public BonoManager()
            : base(new ConexionBD())
        {
        }

    }
}
