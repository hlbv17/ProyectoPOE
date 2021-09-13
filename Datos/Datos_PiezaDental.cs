using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos {
    public class Datos_PiezaDental {



        // Variable
        Conexion con = new Conexion ();
        SqlCommand cmd = new SqlCommand ();

        // Method: BuscarCuadrantePieza
        public List<string> ConsultarCuadrantePieza () {
            List<string> listaCuadrantePieza = new List<string> ();
            string x = "";
            string sql = "SELECT * FROM CuadrantePieza;";
            SqlDataReader dr = null;
            Console.WriteLine (sql);
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    dr = cmd.ExecuteReader ();
                    while (dr.Read ()) {
                        x = dr ["nombreCuadrante"].ToString ();
                        listaCuadrantePieza.Add (x);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("¡---ERROR---BuscarCuadrantePieza---! " + ex.Message);
                }
            }
            return listaCuadrantePieza;
        }

        // Method: BuscarNombrePieza
        public List<string> ConsultarNombrePieza () {
            List<string> listaNombrePieza = new List<string> ();
            string x = "";
            string sql = "SELECT * FROM NombrePieza;";
            SqlDataReader dr = null;
            Console.WriteLine (sql);
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    dr = cmd.ExecuteReader ();
                    while (dr.Read ()) {
                        x = dr ["nombrePieza"].ToString ();
                        listaNombrePieza.Add (x);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("¡---ERROR---BuscarNombrePieza---! " + ex.Message);
                }
            }
            return listaNombrePieza;
        }

        // Method: ConsultarNumeroPieza
        public int ConsultarNumeroPieza (string cuadrantePieza, string nombrePieza) {
            int numeroP = 0;
            string sql = "SELECT  P.id_piezaDental \n" +
                "FROM PiezaDental P \n" +
                "inner join CuadrantePieza CP ON CP.id_cuadrantePieza = P.id_cuadrantePieza \n" +
                "inner join NombrePieza NP ON NP.id_nombrePieza = P.id_nombrePieza \n" +
                "WHERE CP.nombreCuadrante = '" + cuadrantePieza + "' \n" +
                "AND NP.nombrePieza = '" + nombrePieza + "';";
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
                        numeroP = Convert.ToInt32 (dr ["id_piezaDental"].ToString ());
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("¡---ERROR---ConsultarNumeroPieza---! " + ex.Message);
                }
            }
            return numeroP;
        }


    }
}
