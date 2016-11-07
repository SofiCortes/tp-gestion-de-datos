using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class TipoEspecialidadManager : AbstractManager
    {
        public TipoEspecialidadManager()
            : base(new ConexionBD())
        {}


        internal List<TipoEspecialidad> findAll()
        {
            List<TipoEspecialidad> tipoEspecialidades = new List<TipoEspecialidad>();
            try
            {
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Tipos_Especialidades", null);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        TipoEspecialidad tipoEspecialidad = new TipoEspecialidad();

                        tipoEspecialidad.codigo = sqlReader.GetDecimal(0);
                        tipoEspecialidad.descripcion = sqlReader.GetString(1);

                        tipoEspecialidades.Add(tipoEspecialidad);
                    }
                }
            }
            catch (Exception e)
            {
                tipoEspecialidades = null;
            }
            finally
            {
                this.closeDB();
            }
            return tipoEspecialidades;
        }
    }
}
