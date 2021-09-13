using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos {
    public class DatosPersonaVLRS {

        Conexion con = new Conexion ();
        SqlCommand cmd = new SqlCommand ();


        public String insertar (Persona persona) {   //Persona
            string sql = "INSERT INTO Persona (cedula, nombre, fechaNacimiento, telefono, correo, id_sexo) VALUES('" + persona.Cedula + "','" + persona.Nombre + "','" + persona.FechaNacimiento.ToString ("yyyy-MM-dd") + "','" + persona.Telefono + "','" + persona.Correo + "','" + persona.Sexo + "')";
            Console.WriteLine (sql);
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery ();
                    return "1";

                } catch (Exception e) {
                    Console.WriteLine ("Error al insertar en la tabla auto " + e.Message);
                    return "0" + e.Message;
                }
            }
            con.Cerrar ();
            return mensaje;

        }



        public Paciente consultarPersona (string cedula) {
            Paciente pa = null;
            string sql = "Select * from Persona where cedula='" + cedula + "'";
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
                        pa = new Paciente ();
                        pa.Id_persona = Convert.ToInt32 (dr ["id_persona"]);
                        pa.Cedula = dr ["cedula"].ToString ();
                        pa.Nombre = dr ["nombre"].ToString ();
                        pa.FechaNacimiento = DateTime.Parse (dr ["fechaNacimiento"].ToString ());
                        pa.Telefono = dr ["telefono"].ToString ();
                        pa.Correo = dr ["correo"].ToString ();
                        pa.Sexo = Convert.ToChar (dr ["id_sexo"].ToString ());
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en la tabla persona " + ex.Message);
                }

            }
            con.Cerrar ();
            return pa;
        }

        public String Eliminar (string cedula) {

            string sql = "Delete from Persona where cedula='" + cedula + "'";
            Console.WriteLine (sql);
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery ();
                    return "1";

                } catch (Exception e) {
                    Console.WriteLine ("Error al eliminar en la tabla Persona " + e.Message);
                    return "0" + e.Message;
                }

            }
            con.Cerrar ();
            return mensaje;
        }

        public String Actualizar (Paciente paciente, string cedula) {
            string sql = "UPDATE  Persona " +
                " SET nombre= '" + paciente.Nombre + "',fechaNacimiento= '" + paciente.FechaNacimiento.ToString ("yyyy-MM-dd") +
                "', telefono ='" + paciente.Telefono + "',correo='" + paciente.Correo + "',id_sexo='" + paciente.Sexo +
                "' WHERE cedula = '" + cedula + "'";
            Console.WriteLine (sql);
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery ();
                    return "1";

                } catch (Exception e) {
                    Console.WriteLine ("Error al actualizar en la tabla persona " + e.Message);
                    return "0" + e.Message;
                }
            }
            con.Cerrar ();
            return mensaje;
        }
    }
}
