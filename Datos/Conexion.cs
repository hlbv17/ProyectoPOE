using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos {
    public class Conexion {

        // Variables

        /*----------------------------------------EGGM------------------------------------------------------*/
        //private static string cadena = "Data Source=desktop-ek3b3mp\\sqlexpress;Initial Catalog = DentalingE2GM; Integrated Security = True";

        /*----------------------------------------HLBV------------------------------------------------------*/
        private static string cadena = "Data Source=HEBE\\SQLEXPRESS;Initial Catalog=dentalig_grupo;Integrated Security=True";

        /*----------------------------------------ROPB------------------------------------------------------*/
        //private static string cadena = "Data Source=DESKTOP-F0FU8NS\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Dentalig";

        /*----------------------------------------VLRS------------------------------------------------------*/
        //private static string cadena = "Data Source=DESKTOP-K0G9OCM\\SQLEXPRESS;Initial Catalog=PoyectoDentPOE;Integrated Security=True";

        private SqlConnection cn = null;

        public SqlConnection Cn { get => cn; set => cn = value; }

        // Method: Conectar
        public string Conectar () {
            try {
                cn = new SqlConnection ();
                cn.ConnectionString = cadena;
                cn.Open ();
                return "1";
            } catch (Exception ex) {
                Console.WriteLine ("Este error sale: " + ex.Message);
                return "0 " + ex.Message;
            }
        }

        // Method: Cerrar
        public string Cerrar () {
            try {
                cn.Close ();
                return "1";
            } catch (Exception ex) {
                Console.WriteLine ("Este error sale: " + ex.Message);
                return "0 " + ex.Message;
            }
        }

    }
}
