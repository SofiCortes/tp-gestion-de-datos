using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class ProfesionalManager : AbstractManager
    {
        public ProfesionalManager()
            : base(new ConexionBD())
        {
        }

        internal List<Medico> findAll()
        {
            List<Medico> medicos = new List<Medico>();

            try
            {
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Medicos", null);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {

                    }
                }

            }
            catch (Exception e)
            {
                medicos = null;
            }
            finally
            {
                this.closeDB();
            }
            return medicos;
        }

        internal List<Medico> buscarMedicosPorFiltro(string queryNombre, string queryApellido, string queryDocumento, string queryMatricula, decimal p)
        {
            List<Medico> medicos = new List<Medico>();

            try
            {
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Medicos_Con_Filtros", null);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {

                    }
                }

            }
            catch (Exception e)
            {
                medicos = null;
            }
            finally
            {
                this.closeDB();
            }
            return medicos;
        }
    }
}
