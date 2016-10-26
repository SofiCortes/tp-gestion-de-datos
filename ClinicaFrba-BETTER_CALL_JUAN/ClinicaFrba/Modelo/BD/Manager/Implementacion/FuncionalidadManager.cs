﻿using System;
using System.Collections.Generic;
using System.Data;
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

        internal void agregarFuncionalidadesAlRol(Rol rol, List<Funcionalidad> funcionalidadesAsignadas)
        {
            ParametroParaSP parametro1 = new ParametroParaSP("nombre", SqlDbType.VarChar, rol.nombre);
            ParametroParaSP parametro2 = new ParametroParaSP("id", SqlDbType.SmallInt);

            List<ParametroParaSP> parametros = new List<ParametroParaSP>();
            parametros.Add(parametro1);
            parametros.Add(parametro2);

            this.openDB();

            SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Obtener_Rol_Id", parametros);
            procedure.ExecuteNonQuery();

            rol.id = Convert.ToInt32(procedure.Parameters["@id"].Value);

            funcionalidadesAsignadas.ForEach(func =>
            {
                parametros.Clear();

                ParametroParaSP parametro3 = new ParametroParaSP("rol_id", SqlDbType.SmallInt, rol.id);
                ParametroParaSP parametro4 = new ParametroParaSP("funcionalidad_id", SqlDbType.Decimal, func.id);

                parametros.Add(parametro3);
                parametros.Add(parametro4);

                procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Asignar_Funcionalidad_Rol", parametros);
                procedure.ExecuteNonQuery();

            });

            this.closeDB();
        }
    }
}
