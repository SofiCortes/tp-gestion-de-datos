using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

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

        public ConexionBD getConnection(){
            return conexion;
        }

        public SqlCommand createCallableProcedure(string storeProcedureName, List<ParametroParaSP> parameters)
        {
            SqlCommand storeProcedure = this.conexion.getStoreProcedureCall(storeProcedureName);
            if (parameters != null)
            {
                parameters.ForEach(delegate(ParametroParaSP parameter)
                {
                    if (parameter.value != null)
                    {
                        SqlParameter sqlParameter = new SqlParameter("@" + parameter.parametroEnSP, parameter.value);
                        storeProcedure.Parameters.Add(sqlParameter);
                    }
                    else
                    {
                        SqlParameter sqlParameter = new SqlParameter("@" + parameter.parametroEnSP, parameter.type);
                        sqlParameter.Direction = ParameterDirection.Output;
                        storeProcedure.Parameters.Add(sqlParameter);
                    }
                }
                );
            }
            return storeProcedure;
        }

    }
}
