using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos {
    public class Datos_Odontologo_ROPB {


        // Variables
        Conexion con = new Conexion ();
        SqlCommand cmd = new SqlCommand ();

        // Method: ConsultarNombre
        public string ConsultarNombre (DateTime fecha, DateTime hora, string paciente) {
            string nombreO = "";
            string x = "";
            string sql = "SELECT PO.nombres \n" +
                "FROM Cita C \n" +
                "inner join Persona PO ON PO.id_persona = C.id_odontologo \n" +
                "inner join Persona PP ON PP.id_persona = C.id_paciente \n" +
                "WHERE C.fecha = '" + fecha.ToString ("yyyy-MM-dd") + "' \n" +
                "AND c.hora = '" + hora.ToString ("HH:mm") + "' \n" +
                "AND PP.nombres = '" + paciente + "';";
            SqlDataReader dr = null;
            Console.WriteLine (sql);
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    dr = cmd.ExecuteReader ();
                    if (dr.Read ()) {
                        x = dr ["nombres"].ToString ();
                        nombreO = x;
                        Console.WriteLine (x);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("¡---ERROR---ConsultarNombreOdontologo---! " + ex.Message);
                }
            }
            return nombreO;
        }


    }
}
