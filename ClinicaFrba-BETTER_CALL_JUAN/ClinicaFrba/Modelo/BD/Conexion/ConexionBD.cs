using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ClinicaFrba
{

    class ConexionBD
    {
        private SqlConnection connection;

        public void openDB()
        {
            try
            {
                if (connection == null || connection.ConnectionString == "")
                {
                    configureConnection();
                }
                connection.Open();
            }
            catch(SqlException e) 
            {
                Console.Write(e.Message);
            }
        }

        public void closeDB()
        {
            connection.Close();
            connection.Dispose();
        }

        public SqlTransaction beginTransaction()
        {
            return connection.BeginTransaction();
        }

        public void commitTransaction(SqlTransaction transaction)
        {
            transaction.Commit();
        }

        public void rollbackTransaction(SqlTransaction transaction)
        {
            transaction.Rollback();
        }

        public void configureConnection()
        {
            string bdServer = ConfiguracionApp.getInstance().bdServer;
            string bdName = ConfiguracionApp.getInstance().bdName;
            string bdUser = ConfiguracionApp.getInstance().bdUser;
            string bdUserPassword = ConfiguracionApp.getInstance().bdUserPassword;

            connection = new SqlConnection();
            connection.ConnectionString = "Server=" + bdServer + ";" +
            "Database=" + bdName + ";" +
            "User Id=" + bdUser + ";" +
            "Password=" + bdUserPassword + ";";
        }

        internal SqlCommand getStoreProcedureCall(string storeProcedureName)
        {
            SqlCommand sp = new SqlCommand(storeProcedureName, this.connection);
            sp.CommandType = CommandType.StoredProcedure;
            return sp;
        }
    }
}
