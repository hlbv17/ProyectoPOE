using Model;
using Proyecto_Dentalig;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos {
    public class Datos_Odontologo {
        
        List<Odontologo> odontologo = new List<Odontologo> ();
        Conexion con = new Conexion ();
        SqlCommand cmd = new SqlCommand ();

        /*----------------------------------------EGGM------------------------------------------------------*/

        // Method: A
        public int A () {
            string stmt = "SELECT COUNT(*) FROM Persona";
            int count = 0;

  
            Console.WriteLine (stmt);
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = stmt;
                    count = Convert.ToInt32 (cmd.ExecuteScalar ());
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en la tabla odontologo" + ex.Message);
                }
            }
            con.Cerrar ();
            return count;
        }

        //---------------------------------HELEN-------------------------------------------------------
        // Method: ConsultarOdontologos
        public List<Odontologo> ConsultarOdontologos (string dia, DateTime hora) {
            List<Odontologo> odontologos = new List<Odontologo> ();
            Odontologo o = null;
            string sql = "SELECT PE.id_persona, PE.cedula, PE.id_sexo, PE.nombres, PE.fechaNacimiento," +
            "O.id_horario, O.consultorio \n" +
            "FROM Persona PE \n" +
            "INNER JOIN Odontologo O ON PE.id_persona = O.id_odontologo \n" +
            "INNER JOIN Horario H ON O.id_horario = H.id_horario \n" +
            "INNER JOIN HorarioDias HD ON H.id_horario = HD.id_horario \n" +
            "INNER JOIN Dias D ON HD.id_dias = D.id_dias \n" +
            "WHERE D.dia = '" + dia + "' \n" +
            "AND '" + hora + "'  BETWEEN D.horaEntrada AND D.horaSalida; ";
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
                        o = new Odontologo ();
                        o.Id_persona = Convert.ToInt32 (dr ["id_persona"]);
                        o.Cedula = dr ["cedula"].ToString ();
                        o.Sexo = Convert.ToChar (dr ["id_sexo"]);
                        o.Nombre = dr ["nombres"].ToString ();
                        o.FechaNacimiento = Convert.ToDateTime (dr ["fechaNacimiento"]);
                        o.Consultorio = Convert.ToInt32 (dr ["consultorio"]);
                        odontologos.Add (o);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en la tabla odontologo " + ex.Message);
                }
            }
            con.Cerrar ();
            return odontologos;
        }

        // Method: ConsultarOdontologo
        public Odontologo ConsultarOdontologo (string nombre) {
            Odontologo o = null;
            string sql = "SELECT PE.id_persona, PE.cedula, PE.id_sexo, PE.nombres, PE.fecha_nacimiento," +
            "O.consultorio \n" +
            "FROM Persona PE \n" +
            "INNER JOIN Odontologo O ON PE.id_persona = O.id_odontologo \n" +
            "WHERE PE.nombres = '" + nombre + "' ;";
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
                        o = new Odontologo ();
                        o.Id_persona = Convert.ToInt32 (dr ["id_persona"]);
                        o.Cedula = dr ["cedula"].ToString ();
                        o.Sexo = Convert.ToChar (dr ["id_sexo"]);
                        o.Nombre = dr ["nombres"].ToString ();
                        o.FechaNacimiento = Convert.ToDateTime (dr ["fecha_nacimiento"]);
                        o.Consultorio = Convert.ToInt32 (dr ["consultorio"]);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en la tabla paciente " + ex.Message);
                }
            }
            con.Cerrar ();
            return o;
        }
        //----------------------------------------------------------------------------------------------
        // Method: ConsultarPersonaOdont
        public Odontologo ConsultarPersonaOdont (string cedula) {
            List<Persona> p = new List<Persona> ();
            List<Dias> dia = new List<Dias> ();
            Odontologo o = null, o2;
            //string sql = "Select * from Odontologo where cedula = '" + cedula + "'";
            string cossultaprueba = "Select * from Persona where cedula = " + cedula;
            SqlDataReader dr = null;
            Console.WriteLine (cossultaprueba);
            //o = new Odontologo (0, "", 0, null, "", 'F', "", DateTime.Now, "", "");
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = cossultaprueba;
                    dr = cmd.ExecuteReader ();
                    if (dr.Read ()) {
                        o = new Odontologo();
                        o.Id_Odontologo = Convert.ToInt32((dr["id_persona"].ToString()));
                        o2 = consultarodontologo2(o.Id_Odontologo);

                        o.Nombre = dr ["nombres"].ToString ();
                        string sexo = dr ["id_sexo"].ToString ();
                        o.Sexo = sexo [0];
                        o.FechaNacimiento = Convert.ToDateTime (dr ["fechaNacimiento"].ToString ());
                        o.Correo = dr ["correo"].ToString ();
                        o.Telefono = dr ["telefono"].ToString ();
                        o.Cedula = dr["cedula"].ToString();
                        o.Consultorio = o2.Consultorio;
                        o.Especialidad = o2.Especialidad;
                        o.Horario = o2.Horario;
                        o.Id_Odontologo = o2.Id_Odontologo;

                        p.Add (o);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en la tabla persona " + ex.Message);
                }
            }
            
            con.Cerrar ();
            return o;
        }

        // Method: eliminar
        public string eliminar (int id) {
            string sql1 = "DELETE FROM Odontologo WHERE id_odontologo = " + id;
            //string sql = "INSERT INTO Odontologo(id_odontologo,consultorio,cedula) VALUES(" + odo.Id_Odontologo + ",'" + odo.Consultorio + "," + odo.Cedula + ")";
            Console.WriteLine (sql1);
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql1;
                    cmd.ExecuteNonQuery ();
                    return "1";
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en la tabla odontologo" + ex.Message);
                    return "0" + ex.Message;
                }
            }
            con.Cerrar ();
            return mensaje;
        }

        // Method: insertarPersonas
        public String insertarPersonas (Odontologo odo) {
            string sql1 = "INSERT INTO Persona( cedula, nombres, id_sexo, fechaNacimiento, correo, telefono) VALUES( " + odo.Cedula + ",'" + odo.Nombre + "','" + odo.Sexo + "','" + odo.FechaNacimiento.ToString ("yyyy-MM-dd") +
            "','" + odo.Correo + "','" + odo.Telefono + "')";
            //string sql = "INSERT INTO Odontologo(id_odontologo,consultorio,cedula) VALUES(" + odo.Id_Odontologo + ",'" + odo.Consultorio + "," + odo.Cedula + ")";
            Console.WriteLine (sql1);
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql1;
                    cmd.ExecuteNonQuery ();
                    return "1";
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en la tabla odontologo" + ex.Message);
                    return "0" + ex.Message;
                }
            }
            con.Cerrar ();
            return mensaje;
        }

        // Method: insertarOdontologo
        public String insertarOdontologo (Odontologo odo, int especialidad, int horario) {
            Odontologo o = null;
           o= consultaropersona(odo.Cedula);
            string sql = "INSERT INTO Odontologo(id_odontologo, id_horario, id_especialidad, consultorio) VALUES(" + o.Id_Odontologo +
                 ", '" + horario + "', '" + especialidad + "','" + odo.Consultorio + "')";
            Console.WriteLine (sql);
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery ();
                    return "1";
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en la tabla odontologo" + ex.Message);
                    return "0" + ex.Message;
                }
            }
            con.Cerrar ();
            return mensaje;
        }

        // Method: ConsultarPersonaOdontTodos
        public List<Odontologo> ConsultarPersonaOdontTodos () {
            List<Odontologo> p = new List<Odontologo> ();
            List<Dias> dia = new List<Dias> ();
            Odontologo o = null, o2 = null;
            string cossultaprueba = "Select * from Odontologo";
            SqlDataReader dr = null;
            Console.WriteLine (cossultaprueba);
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = cossultaprueba;
                    dr = cmd.ExecuteReader ();
                    while (dr.Read ()) {
                        o = new Odontologo ();
                        //o = new Odontologo (0, "", 0, null, "", 'F', "", DateTime.Now, "", "");
                        Datos_Especialidad espec = new Datos_Especialidad ();
                        Datos_Horario datosHorario = new Datos_Horario ();
                        o.Id_Odontologo = Convert.ToInt32(dr["id_odontologo"]);
                        o2 = consultarodontologp(o.Id_Odontologo);
                        int especilidad, horario;
                        especilidad = Convert.ToInt32 (dr ["id_especialidad"].ToString ());
                        string es = espec.consultarEspecialidad (especilidad);
                        horario = Convert.ToInt32 (dr ["id_horario"].ToString ());
                        
                        o.Especialidad = es;
                        o.Horario = datosHorario.consultarTipodeHoraario (horario);
                        o.Cedula = o2.Cedula;
                        o.Consultorio = Convert.ToInt32 (dr ["consultorio"].ToString ());
                        o.Sexo = o2.Sexo;
                        o.Correo = o2.Correo;
                        o.FechaNacimiento = o2.FechaNacimiento;
                        o.Telefono = o2.Telefono;
                        o.Nombre = o2.Nombre;
                        p.Add(o);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en la tabla persona " + ex.Message);
                }
            }
            con.Cerrar ();
            return p;
        }

        // Method: ConsultaparaEditar
        public Odontologo ConsultaparaEditar (string cedula, string nombre) {
            List<Persona> p = new List<Persona> ();
            Odontologo o = null;
            string sql = "Select * from Odontologo where cedula ='" + cedula + "'";
            string consulta = "SELECT Odontologo.id_odontologo, Persona.cedula, Persona.nombres, Horario.tipo, Especialidad.especialidad, Persona.sexo, Persona.fechaNacimiento, Persona.correo, Persona.telefono, Odontologo.consultorio, Odontologo.cedula" +
           " FROM Odontologo INNER JOIN" +
           " Persona ON Odontologo.cedula = Persona.cedula INNER JOIN" +
           " Horario ON Odontologo.id_odontologo = Horario.id_horario INNER JOIN" +
           " Especialidad ON Odontologo.id_especialidad = Especialidad.id_especialidad" +
           " WHERE (Persona.cedula ='" + cedula + "')  AND (Persona.nombres ='" + nombre + "')";
            SqlDataReader dr = null;
            Console.WriteLine (consulta);
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = consulta;
                    dr = cmd.ExecuteReader ();
                    if (dr.Read ()) {
                        o = new Odontologo (0, "", 0, null, "", 'F', "", DateTime.Now, "", "");
                        o.Id_Odontologo = Convert.ToInt32 (dr ["id_odontologo"]);
                        o.Cedula = dr ["cedula"].ToString ();
                        o.Nombre = dr ["nombres"].ToString ();
                        o.Horario.Tipo = dr ["tipo"].ToString ();
                        o.Especialidad = dr ["especialidad"].ToString ();
                        o.Sexo = Convert.ToChar (dr ["id_sexo"].ToString ());
                        o.FechaNacimiento = Convert.ToDateTime (dr ["fechaNacimiento"].ToString ());
                        o.Correo = dr ["correo"].ToString ();
                        o.Telefono = dr ["telefono"].ToString ();
                        o.Consultorio = Convert.ToInt32 (dr ["consultorio"].ToString ());
                        p.Add (o);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en la tabla odontologp" + ex.Message);
                }
            }
            con.Cerrar ();
            return o;
        }

        // Method: consultarodontologp
        public Odontologo consultarodontologp (int cedula) {
            List<Persona> p = new List<Persona> ();
            List<Dias> dia = new List<Dias> ();
            Odontologo o = null;
            string sql = "Select * from Persona where id_persona = '" + cedula + "'";
            SqlDataReader dr = null;
            Console.WriteLine (odontologo);
            o = new Odontologo (0, "", 0, null, "", 'F', "", DateTime.Now, "", "");
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    dr = cmd.ExecuteReader ();
                    if (dr.Read ()) {
                        o.Nombre = dr ["nombres"].ToString ();
                        string sexo = dr ["id_sexo"].ToString ();
                        o.Sexo = sexo [0];
                        o.FechaNacimiento = Convert.ToDateTime (dr ["fechaNacimiento"].ToString ());
                        o.Correo = dr ["correo"].ToString ();
                        o.Telefono = dr ["telefono"].ToString();
                        o.Cedula = dr["cedula"].ToString();
                        o.Id_persona = Convert.ToInt32(dr["id_persona"].ToString());
                        p.Add (o);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en la tabla odontologp " + ex.Message);
                }
            }
            con.Cerrar ();
            return o;
        }

        public Odontologo consultarodontologo2(int cedula)
        {
            List<Persona> p = new List<Persona>();
            List<Dias> dia = new List<Dias>();
            Odontologo o = null;
            string sql = "Select * from Odontologo where id_odontologo = " + cedula;
            SqlDataReader dr = null;
            Console.WriteLine(odontologo);
            
            string mensaje = "";
            mensaje = con.Conectar();
            if (mensaje[0] == '1')
            {
                try
                {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        o = new Odontologo();
                        Datos_Especialidad espec = new Datos_Especialidad();
                        Datos_Horario datosHorario = new Datos_Horario();
                        o.Id_Odontologo = Convert.ToInt32(dr["id_odontologo"]);
                        int especilidad, horario;
                        especilidad = Convert.ToInt32(dr["id_especialidad"].ToString());
                        string es = espec.consultarEspecialidad(especilidad);
                        horario = Convert.ToInt32(dr["id_horario"].ToString());

                        o.Especialidad = es;
                        o.Horario = datosHorario.consultarTipodeHoraario(horario);
                        
                        o.Consultorio = Convert.ToInt32(dr["consultorio"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al consultar en la tabla odontologp " + ex.Message);
                }
            }
            con.Cerrar();
            Console.WriteLine(o.ToString());
            return o;
        }

        // method 
        public Odontologo consultaropersona(string cedula)
        {
            List<Persona> p = new List<Persona>();
            List<Dias> dia = new List<Dias>();

            Odontologo o = null;
            string sql = "Select * from Persona where cedula = '" + cedula + "'";
            SqlDataReader dr = null;
            Console.WriteLine(odontologo);
            o = new Odontologo(0, "", 0, null, "", 'F', "", DateTime.Now, "", "");
            string mensaje = "";
            mensaje = con.Conectar();
            if (mensaje[0] == '1')
            {
                try
                {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        o.Id_Odontologo =Convert.ToInt32(dr["id_persona"].ToString());
                        o.Nombre = dr["nombres"].ToString();
                        string sexo = dr["id_sexo"].ToString();
                        o.Sexo = sexo[0];
                        o.FechaNacimiento = Convert.ToDateTime(dr["fechaNacimiento"].ToString());
                        o.Correo = dr["correo"].ToString();
                        o.Telefono = dr["telefono"].ToString();
                        o.Cedula = dr["cedula"].ToString();
                        p.Add(o);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al consultar en la tabla odontologp " + ex.Message);
                }
            }
            con.Cerrar();
            return o;
        }

        // Method: eliminarOdontologoPersona
        public string eliminarOdontologoPersona (string cedula) {
            string sql1 = "DELETE FROM Persona WHERE cedula = " + cedula;
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql1;
                    cmd.ExecuteNonQuery ();
                    return "1";
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en la tabla persona" + ex.Message);
                    return "0" + ex.Message;
                }
            }
            con.Cerrar ();
            return mensaje;
        }

        // Method: ACtualizar
        public string ACtualizar (Odontologo odo) {
            string sql1 = "UPDATE Persona set  cedula = '" + odo.Cedula + "', nombres = '" + odo.Nombre + "', id_sexo = '" + odo.Sexo + "', fechaNacimiento = '" + odo.FechaNacimiento + "', correo = '" +odo.Correo  + "', telefono = '" + odo.Telefono +
            "' WHERE cedula = " + odo.Cedula;
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql1;
                    cmd.ExecuteNonQuery ();
                    return "1";
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en la tabla persona" + ex.Message);
                    return "0" + ex.Message;
                }
            }
            con.Cerrar ();
            return mensaje;
        }

        // Method: ACtualizar2
        public string ACtualizar2 (Odontologo odo, int tipo, int espe) {
            Datos_Horario datosHorario = new Datos_Horario ();
            Datos_Especialidad espec = new Datos_Especialidad ();
            string sql1 = "UPDATE Odontologo set  id_odontologo = '" + odo.Id_Odontologo + "', id_especialidad = '" + espe + "', id_horario = '" + tipo + "', consultorio = '" + odo.Consultorio + "'"+
                " WHERE id_odontologo = " + odo.Id_Odontologo;
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql1;
                    cmd.ExecuteNonQuery ();
                    return "1";
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en la tabla persona" + ex.Message);
                    return "0" + ex.Message;
                }
            }
            con.Cerrar ();
            return mensaje;
        }

        // Method: ConsultarPersonaOdontTodosF
        public List<Odontologo> ConsultarPersonaOdontTodosF (string jornada, string especialidad, int consultorio) {
            List<Odontologo> p = new List<Odontologo> ();
            List<Dias> dia = new List<Dias> ();
            Odontologo o = null, o2 = null;
            string sql = filtro (jornada, especialidad, consultorio);
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
                        o = new Odontologo (0, "", 0, null, "", 'F', "", DateTime.Now, "", "");
                        Datos_Especialidad espec = new Datos_Especialidad ();
                        Datos_Horario datosHorario = new Datos_Horario ();
                        o.Id_Odontologo = Convert.ToInt32(dr["id_odontologo"]);
                        o2 = consultarodontologp (o.Id_Odontologo);
                        int especilidad, horario;
                        especilidad = Convert.ToInt32 (dr ["id_especialidad"].ToString ());
                        string es = espec.consultarEspecialidad (especilidad);
                        horario = Convert.ToInt32 (dr ["id_horario"].ToString ());
                        
                        o.Especialidad = es;
                        o.Horario = datosHorario.consultarTipodeHoraario (horario);
                        
                        o.Consultorio = Convert.ToInt32 (dr ["consultorio"].ToString ());
                        o.Sexo = o2.Sexo;
                        o.Correo = o2.Correo;
                        o.Cedula = o2.Cedula;
                        o.FechaNacimiento = o2.FechaNacimiento;
                        o.Telefono = o2.Telefono;
                        o.Nombre = o2.Nombre;
                        p.Add (o);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en la tabla persona " + ex.Message);
                }
            }
            con.Cerrar ();
            return p;
        }

        // Method: filtro
        private string filtro (string jornada, string especialidad, int consultorio) {
            Console.WriteLine (jornada);
            Console.WriteLine (especialidad);
            Console.WriteLine (consultorio);
            string sql = "";
            if ((especialidad == "") & (String.IsNullOrEmpty (jornada) == false & jornada != "Fines de semana") & (consultorio == 0)) {
                Console.WriteLine ("-----Jornada");
                sql = "SELECT Horario.tipo, Odontologo.consultorio, Especialidad.especialidad, Persona.cedula, Odontologo.id_horario, Odontologo.id_especialidad, Persona.nombres, Persona.id_sexo, Persona.fechaNacimiento, " +
                  " Persona.correo, Persona.telefono, Odontologo.id_odontologo" +
                 " FROM  Horario INNER JOIN" +
                  " Odontologo ON Horario.id_horario = Odontologo.id_horario INNER JOIN" +
                  " Persona ON Odontologo.id_odontologo = Persona.id_persona INNER JOIN" +
                 " Especialidad ON Odontologo.id_especialidad = Especialidad.id_especialidad" +
                " WHERE (Horario.tipo = '" + jornada + " I') OR" +
                " (Horario.tipo = '" + jornada + " II')";
            } else if ((especialidad == "") & (String.IsNullOrEmpty (jornada) == false & jornada == "Fines de semana") & (consultorio == 0)) {
                Console.WriteLine ("-----Jornada(Fin de semana)");
                sql = "SELECT Horario.tipo, Odontologo.consultorio, Especialidad.especialidad, Persona.cedula, Odontologo.id_horario, Odontologo.id_especialidad, Persona.nombres, Persona.id_sexo, Persona.fechaNacimiento, " +
                  " Persona.correo, Persona.telefono, Odontologo.id_odontologo" +
                 " FROM  Horario INNER JOIN" +
                  " Odontologo ON Horario.id_horario = Odontologo.id_horario INNER JOIN" +
                  " Persona ON Odontologo.id_odontologo = Persona.id_persona INNER JOIN" +
                 " Especialidad ON Odontologo.id_especialidad = Especialidad.id_especialidad" +
                " WHERE (Horario.tipo = '" + jornada + "')";
            } else if ((jornada == "") & (String.IsNullOrEmpty (especialidad) == false) & (consultorio == 0)) {
                Console.WriteLine ("-----Especialidad");
                sql = "SELECT Horario.tipo, Odontologo.consultorio, Especialidad.especialidad, Persona.cedula, Odontologo.id_horario, Odontologo.id_especialidad, Persona.nombres, Persona.id_sexo, Persona.fechaNacimiento, " +
                  " Persona.correo, Persona.telefono, Odontologo.id_odontologo" +
                 " FROM  Horario INNER JOIN" +
                  " Odontologo ON Horario.id_horario = Odontologo.id_horario INNER JOIN" +
                  " Persona ON Odontologo.id_odontologo = Persona.id_persona INNER JOIN" +
                 " Especialidad ON Odontologo.id_especialidad = Especialidad.id_especialidad" +
                " WHERE (Especialidad.especialidad = '" + especialidad + "')";
            } else if ((String.IsNullOrEmpty (especialidad) == false) & (String.IsNullOrEmpty (jornada) == false & jornada != "Fines de semana") & (consultorio == 0)) {
                Console.WriteLine ("-----Jornada & Especialidad");
                sql = "SELECT Horario.tipo, Odontologo.consultorio, Especialidad.especialidad, Persona.cedula, Odontologo.id_horario, Odontologo.id_especialidad, Persona.nombres, Persona.id_sexo, Persona.fechaNacimiento, " +
                 " Persona.correo, Persona.telefono, Odontologo.id_odontologo" +
                " FROM  Horario INNER JOIN" +
                 " Odontologo ON Horario.id_horario = Odontologo.id_horario INNER JOIN" +
                 " Persona ON Odontologo.id_odontologo = Persona.id_persona INNER JOIN" +
                " Especialidad ON Odontologo.id_especialidad = Especialidad.id_especialidad" +
               " WHERE (Especialidad.especialidad = '" + especialidad + "') AND (Horario.tipo = '" + jornada + " I' OR" +
                " Horario.tipo = '" + jornada + " II')";
            } else if ((consultorio > 0) & (String.IsNullOrEmpty (jornada) == false & jornada != "Fines de semana") & (String.IsNullOrEmpty (especialidad) == false)) {
                Console.WriteLine ("-----Jornada & Especialidad & consultorio");
                sql = "SELECT Horario.tipo, Odontologo.consultorio, Especialidad.especialidad, Persona.cedula, Odontologo.id_horario, Odontologo.id_especialidad, Persona.nombres, Persona.id_sexo, Persona.fechaNacimiento, " +
                 " Persona.correo, Persona.telefono, Odontologo.id_odontologo" +
                " FROM  Horario INNER JOIN" +
                 " Odontologo ON Horario.id_horario = Odontologo.id_horario INNER JOIN" +
                 " Persona ON Odontologo.id_odontologo = Persona.id_persona INNER JOIN" +
                " Especialidad ON Odontologo.id_especialidad = Especialidad.id_especialidad" +
               " WHERE (Especialidad.especialidad = '" + especialidad + "') AND (Odontologo.consultorio = " + consultorio + ") AND (Horario.tipo = '" + jornada + " I' OR" +
                " Horario.tipo = '" + jornada + " II')";
            } else if ((consultorio > 0) & (jornada == "") & (especialidad == "")) {
                Console.WriteLine ("-----Consultorio");
                sql = "SELECT Horario.tipo, Odontologo.consultorio, Especialidad.especialidad, Persona.cedula, Odontologo.id_horario, Odontologo.id_especialidad, Persona.nombres, Persona.id_sexo, Persona.fechaNacimiento, " +
                 " Persona.correo, Persona.telefono, Odontologo.id_odontologo" +
                " FROM  Horario INNER JOIN" +
                 " Odontologo ON Horario.id_horario = Odontologo.id_horario INNER JOIN" +
                 " Persona ON Odontologo.id_odontologo = Persona.id_persona INNER JOIN" +
                " Especialidad ON Odontologo.id_especialidad = Especialidad.id_especialidad" +
               " WHERE (Odontologo.consultorio = " + consultorio + ")";
            } else if ((consultorio > 0) & (jornada == "Fines de semana") & (String.IsNullOrEmpty (especialidad) == false)) {
                Console.WriteLine ("-----Jornada(Fin de semana) & Especialidad & consultorio");
                sql = "SELECT Horario.tipo, Odontologo.consultorio, Especialidad.especialidad, Persona.cedula, Odontologo.id_horario, Odontologo.id_especialidad, Persona.nombres, Persona.id_sexo, Persona.fechaNacimiento, " +
                 " Persona.correo, Persona.telefono, Odontologo.id_odontologo" +
                " FROM  Horario INNER JOIN" +
                 " Odontologo ON Horario.id_horario = Odontologo.id_horario INNER JOIN" +
                 " Persona ON Odontologo.id_odontologo = Persona.id_persona INNER JOIN" +
                " Especialidad ON Odontologo.id_especialidad = Especialidad.id_especialidad" +
               " WHERE (Especialidad.especialidad = '" + especialidad + "') AND (Odontologo.consultorio = " + consultorio + ") AND (Horario.tipo = '" + jornada + "')";
            } else if ((consultorio > 0) & (jornada == "") & (String.IsNullOrEmpty (especialidad) == false)) {
                Console.WriteLine ("----- Especialidad & consultorio");
                sql = "SELECT Horario.tipo, Odontologo.consultorio, Especialidad.especialidad, Persona.cedula, Odontologo.id_horario, Odontologo.id_especialidad, Persona.nombres, Persona.id_sexo, Persona.fechaNacimiento, " +
                 " Persona.correo, Persona.telefono, Odontologo.id_odontologo" +
                " FROM  Horario INNER JOIN" +
                 " Odontologo ON Horario.id_horario = Odontologo.id_horario INNER JOIN" +
                 " Persona ON Odontologo.id_odontologo = Persona.id_persona INNER JOIN" +
                " Especialidad ON Odontologo.id_especialidad = Especialidad.id_especialidad" +
               " WHERE (Especialidad.especialidad = '" + especialidad + "') AND (Odontologo.consultorio = " + consultorio + ")";
            } else if ((consultorio > 0) & (String.IsNullOrEmpty (jornada) == false & jornada != "Fines de semana") & (especialidad == "")) {
                Console.WriteLine ("-----Jornada & consultorio");
                sql = "SELECT Horario.tipo, Odontologo.consultorio, Especialidad.especialidad, Persona.cedula, Odontologo.id_horario, Odontologo.id_especialidad, Persona.nombres, Persona.id_sexo, Persona.fechaNacimiento, " +
                 " Persona.correo, Persona.telefono, Odontologo.id_odontologo" +
                " FROM  Horario INNER JOIN" +
                 " Odontologo ON Horario.id_horario = Odontologo.id_horario INNER JOIN" +
                 " Persona ON Odontologo.id_odontologo = Persona.id_persona INNER JOIN" +
                " Especialidad ON Odontologo.id_especialidad = Especialidad.id_especialidad" +
               " WHERE (Odontologo.consultorio = " + consultorio + ") AND (Horario.tipo = '" + jornada + " I' OR" +
                " Horario.tipo = '" + jornada + " II')";
            } else {
                sql = "Select* from Odontologo";
            }
            return sql;
        }

        // Method: consultarodontologpFiltro2
        public List<Odontologo> consultarodontologpFiltro2 (string cedula) {
            List<Odontologo> p = new List<Odontologo> ();
            List<Dias> dia = new List<Dias> ();
             Odontologo o = null, o2;
            o2= consultaropersona(cedula);
           
            string sql = "Select * from Odontologo where id_odontologo = '" + o2.Id_Odontologo + "'";
            SqlDataReader dr = null;
            Console.WriteLine (odontologo);
            o = new Odontologo (0, "", 0, null, "", 'F', "", DateTime.Now, "", "");
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    dr = cmd.ExecuteReader ();
                    if (dr.Read ()) {
                        Datos_Especialidad espec = new Datos_Especialidad ();
                        Datos_Horario datosHorario = new Datos_Horario ();
                        int especilidad, horario;
                        especilidad = Convert.ToInt32 (dr ["id_especialidad"].ToString ());
                        string es = espec.consultarEspecialidad (especilidad);
                        horario = Convert.ToInt32 (dr ["id_horario"].ToString ());
                        o.Id_Odontologo = Convert.ToInt32 (dr ["id_odontologo"]);
                        o.Especialidad = es;
                        o.Horario = datosHorario.consultarTipodeHoraario (horario);
                        o.Cedula = o2.Cedula;
                        o.Correo = o2.Correo;
                        o.Telefono = o2.Telefono;
                        o.Nombre = o2.Nombre;
                        o.Sexo = o2.Sexo;
                        o.Consultorio = Convert.ToInt32 (dr ["consultorio"].ToString ());
                        p.Add (o);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en la tabla odontologp " + ex.Message);
                }
            }
            con.Cerrar ();
            return p;
        }

        /*----------------------------------------ROPB------------------------------------------------------*/

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
