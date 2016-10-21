using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClinicaFrba
{
    abstract class AbstractManager
    {
        private ConexionBD conexion;

        public AbstractManager(ConexionBD conexion)
        {
            this.conexion = conexion;
        }

        public void openDB()
        {
            this.conexion.openDB();
        }

        public void closeDB() {
            this.conexion.closeDB();
        }

        public SqlCommand createCallableProcedure(string storeProcedureName, List<ParametroParaSP> parameters)
        {
            SqlCommand storeProcedure = this.conexion.getStoreProcedureCall(storeProcedureName);
            parameters.ForEach(parameter => 
                storeProcedure.Parameters.Add("@" + parameter.parametroEnSP, parameter.type).Value = parameter.value
            );
            return storeProcedure;
        }

    }
}
