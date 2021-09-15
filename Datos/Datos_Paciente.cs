using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos {
    public class Datos_Paciente {
        
        // Variables
        Conexion con = new Conexion ();
        SqlCommand cmd = new SqlCommand ();

        /*----------------------------------------VLRS------------------------------------------------------*/

        // Method: 
        public String insertar (Paciente paciente) { //Persona
            string sql = "INSERT INTO Paciente (id_paciente,discapacidad,id_etapaEdad) VALUES(" + paciente.Id_persona + ",'" +
                paciente.Discapacidad + "'," + paciente.Id_EtapaEdad () + ")";
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

        // Method: 
        public Paciente consultarPersonaPac (string cedula) {
            Paciente pa = null;
            string sql = "SELECT Persona.id_persona, Persona.cedula, Persona.nombres, Persona.fechaNacimiento, Persona.telefono," +
                              " Persona.correo, Persona.id_sexo, Paciente.id_paciente, Paciente.discapacidad,"
                            + " Paciente.id_etapaEdad" +
                        " FROM Persona INNER JOIN" +
                             " Paciente ON Persona.id_persona = Paciente.id_paciente" +
                        " WHERE(Persona.cedula ='" + cedula + "')";

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
                        pa.Nombre = dr ["nombres"].ToString ();
                        pa.FechaNacimiento = Convert.ToDateTime (dr ["fechaNacimiento"]);
                        pa.Telefono = dr ["telefono"].ToString ();
                        pa.Correo = dr ["correo"].ToString ();
                        pa.Sexo = Convert.ToChar (dr ["id_sexo"]);
                        pa.Id_paciente = Convert.ToInt32 (dr ["id_paciente"]);
                        pa.Discapacidad = dr ["discapacidad"].ToString ();
                        pa.Id_etapaEdad = Convert.ToInt32 (dr ["id_etapaEdad"]);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en la tabla persona " + ex.Message);
                }

            }
            con.Cerrar ();
            return pa;
        }

        // Method: 
        public String Eliminar (long id_paciente) {
            string sql = "Delete from Paciente where id_paciente=" + id_paciente;
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
                    Console.WriteLine ("Error al eliminar en la tabla Paciente " + e.Message);
                    return "0" + e.Message;
                }

            }
            con.Cerrar ();
            return mensaje;
        }

        // Method: 
        public String Actualizar (Paciente paciente, long id_persona) {
            string sql = "UPDATE  Paciente " +
                " SET discapacidad= '" + paciente.Discapacidad + "',id_etapaEdad= " + paciente.Id_EtapaEdad () +
                " WHERE id_paciente =" + id_persona;
            ;
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
                    Console.WriteLine ("Error al actualizar en la tabla paciente " + e.Message);
                    return "0" + e.Message;
                }
            }
            con.Cerrar ();
            return mensaje;
        }

        /*----------------------------------------HLBV------------------------------------------------------*/

        // Method: 
        public Paciente ConsultarPacienteNombre (string cedula) {

            Paciente p = null;
            string sql = "Select PE.id_persona, PE.cedula, PE.id_sexo, PE.nombres, PE.fechaNacimiento, " +
                "PA.discapacidad \n" +
                "FROM Persona PE \n" +
                "INNER JOIN Paciente PA ON PE.id_persona = PA.id_paciente \n" +
                "WHERE PE.cedula = '" + cedula + "'";
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
                        p = new Paciente ();
                        p.Id_persona = Convert.ToInt32 (dr ["id_persona"]);
                        p.Cedula = dr ["cedula"].ToString ();
                        p.Sexo = Convert.ToChar (dr ["id_sexo"]);
                        p.Nombre = dr ["nombres"].ToString ();
                        p.FechaNacimiento = Convert.ToDateTime (dr ["fechaNacimiento"]);
                        p.Discapacidad = dr ["discapacidad"].ToString ();
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("------------Error al consultar en la tabla paciente---------------" + ex.Message);
                }
            }
            con.Cerrar ();
            return p;
        }

        // Method: 
        public bool ConsultarPacienteCedula (string cedula) {
            bool flag = true;
            string sql = "Select PE.id_persona, PE.cedula, PE.id_sexo, PE.nombres, PE.fechaNacimiento, PA. discapacidad " +
                "FROM Persona PE " +
                "INNER JOIN Paciente PA ON PE.id_persona = PA.id_paciente" +
                "WHERE PE.cedula = '" + cedula + "'";
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
                        flag = true;
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en la tabla paciente " + ex.Message);
                    flag = false;
                }
            }
            con.Cerrar ();
            return flag;
        }

        /*----------------------------------------ROPB------------------------------------------------------*/

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
