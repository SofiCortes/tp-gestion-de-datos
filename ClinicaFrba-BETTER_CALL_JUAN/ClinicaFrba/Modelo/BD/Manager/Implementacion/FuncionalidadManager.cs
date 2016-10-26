using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Modelo.BD.Manager.Implementacion
{
    class FuncionalidadManager : AbstractManager
    {
        public FuncionalidadManager() : base(new ConexionBD())
        {
        }

        internal List<Funcionalidad> getTodasLasFuncionalidades()
        {
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            try
            {
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Todas_Las_Funcionalidades", null);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Funcionalidad func = new Funcionalidad();
                        func.id = sqlReader.GetDecimal(0);
                        func.descripcion = sqlReader.GetString(1);

                        funcionalidades.Add(func);
                    }
                }
            }
            catch (Exception e)
            {
                funcionalidades = null;
            }
            finally
            {
                this.closeDB();
            }
            return funcionalidades;
        }
    }
}
