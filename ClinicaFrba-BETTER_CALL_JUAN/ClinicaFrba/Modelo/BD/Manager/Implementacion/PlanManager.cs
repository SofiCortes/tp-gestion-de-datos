using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        internal List<PlanMedico> getPlanesMedicos()
        {
            List<PlanMedico> planes = new List<PlanMedico>();

            try
            {
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Planes", null);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        PlanMedico plan = new PlanMedico();
                        plan.codigo = sqlReader.GetDecimal(0);
                        plan.descripcion = sqlReader.GetString(1);
                        plan.precioBonoConsulta = sqlReader.GetDecimal(2);
                        plan.precioBonoFarmacia = sqlReader.GetDecimal(3);

                        planes.Add(plan);
                    }
                }

            }
            catch (Exception e)
            {
                planes = null;
            }
            finally
            {
                this.closeDB();
            }
            return planes;
        }
    }
}
