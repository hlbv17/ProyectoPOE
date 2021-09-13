using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos {
    public class Datos_Paciente_ROPB {


        // Variables
        Conexion con = new Conexion ();
        SqlCommand cmd = new SqlCommand ();

        // Method: ConsultarNombres
        public List<string> ConsultarNombres (DateTime fecha, DateTime hora, int x) {
            List<string> listaNombres = new List<string> ();
            string nombre = "";
            string sql = "SELECT P.nombres \n" +
                "FROM Cita C \n" +
                "Inner Join Persona P ON P.id_persona = C.id_paciente \n" +
                "WHERE C.fecha = '" + fecha.ToString ("yyyy-MM-dd") + "' AND c.hora = '" + hora.ToString ("HH:mm:ss") + "' \n" +
                "ORDER BY P.nombres ASC;";
            string sql2 = "SELECT P.nombres FROM Paciente PP \n" +
                "Inner Join Persona P ON P.id_persona = PP.id_paciente \n" +
                "ORDER BY P.nombres ASC;";
            SqlDataReader dr = null;
            if (x == 2) {
                Console.WriteLine (sql2);
            } else {
                Console.WriteLine (sql);
            }
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    if (x == 2) {
                        cmd.CommandText = sql2;
                    } else {
                        cmd.CommandText = sql;
                    }
                    dr = cmd.ExecuteReader ();
                    while (dr.Read ()) {
                        nombre = dr ["nombres"].ToString ();
                        listaNombres.Add (nombre);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("¡---ERROR---ConsultarNombres---! " + ex.Message);
                }
            }
            return listaNombres;
        }


    }
}
