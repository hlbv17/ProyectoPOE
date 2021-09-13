using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos {
    public class Datos_HistoriaClinica_ROPB {


        // Variable
        Conexion con = new Conexion ();
        SqlCommand cmd = new SqlCommand ();

        // Method: ConsultarIdHistoriaClinica
        public int ConsultarIdHistoriaClinica (string nombre) {
            int idCH = 0;
            string sql = "SELECT HC.id_historiaClinica \n" +
                "FROM HistoriaClinica HC \n" +
                "inner join Persona P ON P.id_persona = HC.id_paciente \n" +
                "WHERE P.nombres = '" + nombre + "';";
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
                        idCH = Convert.ToInt32 (dr ["id_historiaClinica"].ToString ());
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("¡---ERROR---ConsultarIdHistoriaClinica---! " + ex.Message);
                }
            }
            return idCH;
        }


    }
}
