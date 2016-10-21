using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class AtencionMedicaManager : AbstractManager
    {
        public AtencionMedicaManager()
            : base(new ConexionBD())
        {
        }

    }
}
