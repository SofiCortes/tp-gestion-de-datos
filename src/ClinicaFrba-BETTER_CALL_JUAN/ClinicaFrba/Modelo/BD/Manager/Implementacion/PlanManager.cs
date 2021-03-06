﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
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

        internal List<PlanMedico> buscarPlanesMedicosPorNombre(string queryPlan)
        {
            List<PlanMedico> planes = new List<PlanMedico>();

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("descripcion", SqlDbType.VarChar, queryPlan);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Buscar_Plan_Por_Nombre", parametros);
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

        internal PlanMedico buscarPorUsuarioId(decimal usuarioId)
        {
            PlanMedico plan = new PlanMedico();

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("usuario_id", SqlDbType.Decimal, usuarioId);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Buscar_Plan_Por_Usuario_Id", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        plan.codigo = sqlReader.GetDecimal(0);
                        plan.descripcion = sqlReader.GetString(1);
                        plan.precioBonoConsulta = sqlReader.GetDecimal(2);
                        plan.precioBonoFarmacia = sqlReader.GetDecimal(3);
                    }
                }

            }
            catch (Exception e)
            {
                plan = null;
            }
            finally
            {
                this.closeDB();
            }
            return plan;
        }
    }
}
