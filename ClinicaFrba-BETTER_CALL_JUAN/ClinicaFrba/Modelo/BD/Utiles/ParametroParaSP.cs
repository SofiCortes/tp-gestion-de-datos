using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ClinicaFrba
{
    class ParametroParaSP
    {
        private string p;
        private SqlDbType sqlDbType;
        private string password;

        public String parametroEnSP {get;set;}
        public SqlDbType type { get; set; }
        public Object value { get; set; }

        public ParametroParaSP(String parametroEnSP, SqlDbType type, Object value)
        {
            this.parametroEnSP = parametroEnSP;
            this.type = type;
            this.value = value;
        }
    }
}
