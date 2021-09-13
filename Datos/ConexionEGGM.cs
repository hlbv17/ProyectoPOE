using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos {
    public class ConexionEGGM {
        private static string cadena = "Data Source=desktop-ek3b3mp\\sqlexpress;Initial Catalog = DentalingE2GM; Integrated Security = True";
        private SqlConnection cn = null;

        public SqlConnection Cn { get => cn; set => cn = value; }

        public string conectar () {
            try {
                cn = new SqlConnection ();
                cn.ConnectionString = cadena;
                cn.Open ();
                return "1";
            } catch (Exception ex) {
                Console.WriteLine ("Este error sale" + ex.Message);
                return "0 " + ex.Message;
            }
        }

        public string cerrar () {
            try {
                cn.Close ();
                return "1";
            } catch (Exception ex) {
                Console.WriteLine ("Este error sale " + ex.Message);
                return "0:" + ex.Message;
            }
        }
    }
}
