using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos {
    class DatosEspecialidadEGGM {
        string e;
        Conexion con = new Conexion ();
        SqlCommand cmd = new SqlCommand ();
        public string consultarEspecialidad (int especialidad) {
            string sql = "Select * from Especialidad2 where id_especialidad = " + especialidad;
            SqlDataReader dr = null; //tabla virtual
            Console.WriteLine (sql);
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    dr = cmd.ExecuteReader ();
                    if (dr.Read ()) {
                        e = Convert.ToString (dr ["especialidad"].ToString ());
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("Erro al consultar las Tabla Horario, Dias, HorarioDias" + ex.Message);
                }
            }
            con.Cerrar ();
            return e;
        }

    }
}
