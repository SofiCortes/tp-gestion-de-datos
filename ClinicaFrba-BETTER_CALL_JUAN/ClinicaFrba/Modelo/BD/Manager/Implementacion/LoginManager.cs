using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClinicaFrba
{
    class LoginManager : AbstractManager
    {
        public LoginManager() : base(new ConexionBD())
        {}

        public void loginUser(string username, string password)
        {
            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("User", SqlDbType.VarChar, username);
                ParametroParaSP parametro2 = new ParametroParaSP("Password", SqlDbType.VarChar, password);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("Procedure_Login", parametros);
                procedure.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //Hacer algo con la excepcion, tal vez devolverla?
            }
            finally
            {
                this.closeDB();
            }
        }

    }
}
