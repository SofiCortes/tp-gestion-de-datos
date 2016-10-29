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


        internal List<Especialidad> buscarEspecialidades()
        {
            List<Especialidad> especialidades = new List<Especialidad>();

            try
            {
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Nombres_Especialidades", null);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Especialidad especialidad = new Especialidad();
                        especialidad.descripcion = sqlReader.GetString(0);
                        especialidades.Add(especialidad);
                    }
                }

            }
            catch (Exception e)
            {
                especialidades = null;
            }
            finally
            {
                this.closeDB();
            }
            return especialidades;
        }
    }
}
