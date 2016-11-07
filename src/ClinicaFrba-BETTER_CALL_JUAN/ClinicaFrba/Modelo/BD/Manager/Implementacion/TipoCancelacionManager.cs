using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class TipoCancelacionManager : AbstractManager
    {
        public TipoCancelacionManager()
            : base(new ConexionBD())
        {
        }

        internal List<TipoCancelacion> findAll()
        {
            List<TipoCancelacion> tipoCancelaciones = new List<TipoCancelacion>();

            try
            {
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Get_Tipo_Cancelaciones", null);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        TipoCancelacion tipoCancelacion = new TipoCancelacion();
                        tipoCancelacion.id = sqlReader.GetDecimal(0);
                        tipoCancelacion.nombre = sqlReader.GetString(1);
                        
                        tipoCancelaciones.Add(tipoCancelacion);
                    }
                }

            }
            catch (Exception e)
            {
                tipoCancelaciones = null;
            }
            finally
            {
                this.closeDB();
            }

            return tipoCancelaciones;
        }

    }
}
