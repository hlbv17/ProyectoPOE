using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos {
    public class ConexionVLRS {
        private static string cadena = "Data Source=DESKTOP-K0G9OCM\\SQLEXPRESS;Initial Catalog=PoyectoDentPOE;Integrated Security=True";

        private SqlConnection cn = null;
        public SqlConnection Cn { get => cn; set => cn = value; }

        public string Conectar () {
            try {
                cn = new SqlConnection ();
                cn.ConnectionString = cadena;
                cn.Open ();
                return "1";
            } catch (Exception ex) {
                Console.WriteLine (ex.Message);
                return "0" + ex.Message;
            }
        }

        public string Cerrar () {
            try {
                cn.Close ();
                return "1";
            } catch (Exception ex) {
                Console.WriteLine (ex.Message);
                return "0" + ex.Message;
            }
        }
    }
}
