using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class EstadisticasManager : AbstractManager
    {
        public EstadisticasManager()
            : base(new ConexionBD())
        {
        }


        internal List<MedicoDAO> getProfesionalesConMenosHoras(string anioSeleccionado, string mesSeleccionado, decimal especialidadCod)
        {
            List<MedicoDAO> medicos = new List<MedicoDAO>();

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("especialidad_cod", SqlDbType.Decimal, especialidadCod);
                ParametroParaSP parametro2 = new ParametroParaSP("anio", SqlDbType.Int, int.Parse(anioSeleccionado));
                ParametroParaSP parametro3 = new ParametroParaSP("mes", SqlDbType.Int, int.Parse(mesSeleccionado));
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Top_5_Profesionales_Con_Menos_Horas_Trabajadas_Segun_Especialidad", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        MedicoDAO medicoDAO = new MedicoDAO();

                        Medico medico = new Medico();
                        medico.matricula = sqlReader.GetDecimal(0);
                        medico.nombre = sqlReader.GetString(1);
                        medico.apellido = sqlReader.GetString(2);

                        medicoDAO.medico = medico;
                        medicoDAO.cantHorasTrabajadas = sqlReader.GetInt32(3);

                        medicos.Add(medicoDAO);
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
