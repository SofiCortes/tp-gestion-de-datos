using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClinicaFrba
{
    class RolManager : AbstractManager
    {
        public RolManager() : base(new ConexionBD())
        {
        }

        public List<string> getFuncionalidadesDeRol(string rol)
        {
            List<string> funcionalidades = new List<string>();
            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("rol", SqlDbType.VarChar, rol);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Funcionalidades_De_Rol", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        funcionalidades.Add(sqlReader.GetString(0));
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


        internal List<Rol> buscarTodos()
        {
            List<Rol> roles = new List<Rol>();
            try
            {
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Todos_Los_Roles", null);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Rol rol = new Rol();
                        rol.id = sqlReader.GetInt16(0);
                        rol.nombre = sqlReader.GetString(1);
                        rol.habilitado = sqlReader.GetBoolean(2);

                        roles.Add(rol);
                    }
                }
            }
            catch (Exception e)
            {
                roles = null;
            }
            finally
            {
                this.closeDB();
            }
            return roles;
        }
    }
}
