using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClinicaFrba
{
    class BonoManager : AbstractManager
    {
        public BonoManager()
            : base(new ConexionBD())
        {
        }


        internal decimal comprarBono(decimal usuarioId, decimal cantBonos, decimal planCodigo)
        {
            decimal montoAPagar = 0;
            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("id_usuario", SqlDbType.Decimal, usuarioId);
                ParametroParaSP parametro2 = new ParametroParaSP("cant_bonos", SqlDbType.Decimal, cantBonos);
                ParametroParaSP parametro3 = new ParametroParaSP("plan_medico_bono_id", SqlDbType.Decimal, planCodigo);
                ParametroParaSP parametro4 = new ParametroParaSP("monto_a_pagar", SqlDbType.Decimal);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Comprar_Bonos", parametros);
                procedure.ExecuteNonQuery();

                montoAPagar = Convert.ToDecimal(procedure.Parameters["@monto_a_pagar"].Value);
            }
            catch (Exception e)
            {
                montoAPagar = 0;
            }
            finally
            {
                this.closeDB();
            }
            return montoAPagar;
        }

        internal List<BonoConsulta> getBonosDisponibles(decimal pacienteId)
        {
            List<BonoConsulta> bonos = new List<BonoConsulta>();

            try
            {
                ParametroParaSP parametro = new ParametroParaSP("id_paciente", SqlDbType.Decimal, pacienteId);

                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro);
         
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Afiliado_Bonos_Disponibles", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        BonoConsulta bono = new BonoConsulta();
                        
                        bono.id = sqlReader.GetDecimal(0);
                        bono.fechaCompra = sqlReader.GetDateTime(1);
                        
                        bonos.Add(bono);
                    }
                }

            }
            catch (Exception e)
            {
                bonos = null;
            }
            finally
            {
                this.closeDB();
            }

            return bonos;
            
        }

        internal int getCantBonosAfiliado(decimal pacienteId)
        {
            int cantidadBonos = 0;

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("id_paciente", SqlDbType.Decimal, pacienteId);
                ParametroParaSP parametro2 = new ParametroParaSP("bonos_disponibles", SqlDbType.Int);

                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Afiliado_Cantidad_Bonos_Disponibles", parametros);
                procedure.ExecuteNonQuery();

                cantidadBonos = Convert.ToInt32(procedure.Parameters["@bonos_disponibles"].Value);
              
            }
            catch (Exception e)
            {
                cantidadBonos = -1;
            }
            finally
            {
                this.closeDB();
            }

            return cantidadBonos;
        }
    }
}
