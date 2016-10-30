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
        private const string BD_SERVER = "localhost\\SQLSERVER2012";
        private const string BD_NAME = "GD2C2016";
        private const string BD_USER = "gd";
        private const string BD_USER_PASSWORD = "gd2016";

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
            connection = new SqlConnection();
            connection.ConnectionString = "Server=" + BD_SERVER + ";" +
            "Database=" + BD_NAME + ";" +
            "User Id=" + BD_USER + ";" +
            "Password=" + BD_USER_PASSWORD + ";";
        }

        internal SqlCommand getStoreProcedureCall(string storeProcedureName)
        {
            SqlCommand sp = new SqlCommand(storeProcedureName, this.connection);
            sp.CommandType = CommandType.StoredProcedure;
            return sp;
        }
    }
}
