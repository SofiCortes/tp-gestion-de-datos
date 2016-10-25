using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClinicaFrba
{
    class UsuarioManager : AbstractManager
    {
        public UsuarioManager()
            : base(new ConexionBD())
        {}

        public int loginUser(string username, string password)
        {
            int returnValue = -4;
            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("user", SqlDbType.VarChar, username);
                ParametroParaSP parametro2 = new ParametroParaSP("passwordIngresada", SqlDbType.VarChar, password);
                ParametroParaSP parametro3 = new ParametroParaSP("retorno", SqlDbType.SmallInt);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Login", parametros);
                procedure.ExecuteNonQuery();

                returnValue = Convert.ToInt32(procedure.Parameters["@retorno"].Value);
            }
            catch (Exception e)
            {
                //Hacer algo con la excepcion, tal vez devolverla?
            }
            finally
            {
                this.closeDB();
            }
            return returnValue;
        }


        internal List<Rol> getRolesDeUsuario(string username)
        {
            List<Rol> roles = new List<Rol>();
            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("user", SqlDbType.VarChar, username);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Roles", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Rol rol = new Rol();
                        rol.nombre = sqlReader.GetString(0);

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
