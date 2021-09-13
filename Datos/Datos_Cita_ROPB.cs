using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos {
    public class Datos_Cita_ROPB {

        // Variable
        Conexion con = new Conexion ();
        SqlCommand cmd = new SqlCommand ();

        // Method: CosultarIdCita
        public int CosultarIdCita (string nombre, DateTime fecha, string hora) {
            int idCita = 0;
            string x = "";
            string sql = "SELECT C.id_cita \n" +
                "FROM Cita C \n" +
                "inner join Persona PO ON PO.id_persona = C.id_odontologo \n" +
                "inner join Persona PP ON PP.id_persona = C.id_paciente \n" +
                "WHERE C.fecha = '" + fecha.ToString ("yyyy-MM-dd") + "' \n" +
                "AND c.hora = '" + hora + "' \n" +
                "AND PP.nombres = '" + nombre + "';";
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
                        idCita = Convert.ToInt32 (dr ["id_cita"].ToString ());
                        Console.WriteLine (x);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("¡---ERROR---CosultarIdCita---! " + ex.Message);
                }
            }
            return idCita;
        }

        // Method: ConsultarHorasCita
        public List<DateTime> ConsultarHorasCita (DateTime fecha, int n) {
            List<DateTime> listaHorasCita = new List<DateTime> ();
            DateTime x = new DateTime ();
            string sql2 = "SELECT DISTINCT C.hora FROM Cita C;";
            string sql1 = "SELECT DISTINCT C.hora FROM Cita C WHERE c.fecha = '" + fecha.ToString ("yyyy-MM-dd") + "' ;";
            SqlDataReader dr = null;
            if (n == 2) { // 2: todos
                Console.WriteLine (sql2);
            } else {
                Console.WriteLine (sql1);
            }
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    if (n == 2) { // 2: todos
                        cmd.CommandText = sql2;
                    } else { // 1: no todos
                        cmd.CommandText = sql1;
                    }
                    dr = cmd.ExecuteReader ();
                    while (dr.Read ()) {
                        x = Convert.ToDateTime (dr ["hora"].ToString ());
                        listaHorasCita.Add (x);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("¡---ERROR---ConsultarHorasCita---! " + ex.Message);
                }
            }
            return listaHorasCita;
        }


    }
}
