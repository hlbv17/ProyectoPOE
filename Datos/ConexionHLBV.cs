using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos {
    public class ConexionHLBV {

        private static string cadena = "Data Source=HEBE\\SQLEXPRESS;Initial Catalog=dentalig;Integrated Security=True";
        private SqlConnection cn = null;

        public SqlConnection Cn { get => cn; set => cn = value; }

        public string Conectar () {
            try {
                cn = new SqlConnection ();
                cn.ConnectionString = cadena;
                cn.Open ();
                return "1";
            } catch (Exception ex) {
                Console.WriteLine ("Este error sale " + ex.Message);
                return "0 " + ex.Message;
            }
        }

        public string Cerrar () {
            try {
                cn.Close ();
                return "1";
            } catch (Exception ex) {
                Console.WriteLine ("Este error sale " + ex.Message);
                return "0 " + ex.Message;
            }
        }
    }
}
