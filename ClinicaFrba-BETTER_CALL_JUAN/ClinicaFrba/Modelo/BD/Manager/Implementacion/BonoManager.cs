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
    }
}
