using Model;
using Proyecto_Dentalig;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Datos
{
    public class DatosCitaHLBV
    {
        ConexionHLBV con = new ConexionHLBV();
        SqlCommand cmd = new SqlCommand();


        public String insertarCita(Cita c)
        {
            string sql = "INSERT INTO Cita (id_odontologo, id_paciente, fecha, hora)" +
                "VALUES ('" + c.Odontologo.Id_persona + "','" + c.Paciente.Id_persona + "','" + c.Fecha.ToString("yyyy-MM-dd") + "','" + c.Hora.ToString("HH:mm") + "')";
            Console.WriteLine(sql);
            string mensaje = "";
            mensaje = con.Conectar();
            if (mensaje[0] == '1')
            {
                try
                {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    return "1";
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al insertar en la tabla Cita " + e.Message);
                    return "0" + e.Message;
                }
            }
            con.Cerrar();
            return mensaje;
        }

        public List<Cita> ListarCitas()
        {
            List<Cita> citas = new List<Cita>();
            Cita c = null;
            Odontologo o = null;
            Paciente pa = null;
            string sql = "SELECT C.id_cita, P1.cedula, P1.nombre as paciente, P2.nombre as odontologo, C.fecha, C.hora, O.consultorio\n" +
                         "FROM Cita C, Odontologo O, Persona P1, Persona P2 \n" +
                         "WHERE P1.id_persona = C.id_paciente \n" +
                         "AND P2.id_persona = C.id_odontologo \n" +
                         "AND C.id_odontologo = O.consultorio";
            SqlDataReader dr = null;
            Console.WriteLine(sql);
            string mensaje = "";
            mensaje = con.Conectar();
            if (mensaje[0] == '1')
            {
                try
                {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        c = new Cita();
                        pa = new Paciente();
                        o = new Odontologo();

                        c.Id_cita = Convert.ToInt32(dr["id_cita"]);
                        pa.Cedula = dr["cedula"].ToString();
                        c.Paciente.Cedula = pa.Cedula;
                        pa.Nombre = dr["paciente"].ToString();
                        c.Paciente.Nombre = pa.Nombre;
                        o.Nombre = dr["odontologo"].ToString();
                        c.Odontologo.Nombre = o.Nombre;
                        c.Fecha = DateTime.Parse(dr["fecha"].ToString());
                        string hora = dr["hora"].ToString();
                        c.Hora = DateTime.ParseExact(hora, "HH:mm:ss", CultureInfo.InvariantCulture);
                        o.Consultorio = Convert.ToInt32(dr["consultorio"]);
                        c.Odontologo.Consultorio = o.Consultorio;
                        citas.Add(c);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al consultar en la tabla Cita " + ex.Message);
                }
            }
            con.Cerrar();
            return citas;
        }

        public List<Cita> ConsultarCitasxCedula(string cedula)
        {
            List<Cita> citas = new List<Cita>();
            Cita c = null;
            Odontologo o = null;
            Paciente pa = null;
            string sql = "SELECT C.id_cita, P1.cedula as cedula, P1.nombre as paciente, P2.nombre as odontologo, " +
                         "C.fecha, C.hora, O.consultorio \n" +
                         "FROM Cita C, Odontologo O, Persona P1, Persona P2 \n" +
                         "WHERE P1.id_persona = C.id_paciente \n" +
                         "AND P2.id_persona = C.id_odontologo \n" +
                         "AND C.id_odontologo = O.consultorio \n" +
                         "AND P1.cedula = '" + cedula + "'";
            SqlDataReader dr = null;
            Console.WriteLine(sql);
            string mensaje = "";
            mensaje = con.Conectar();
            if (mensaje[0] == '1')
            {
                try
                {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        c = new Cita();
                        pa = new Paciente();
                        o = new Odontologo();

                        c.Id_cita = Convert.ToInt32(dr["id_cita"]);
                        pa.Cedula = dr["cedula"].ToString();
                        c.Paciente.Cedula = pa.Cedula;
                        pa.Nombre = dr["paciente"].ToString();
                        c.Paciente.Nombre = pa.Nombre;
                        o.Nombre = dr["odontologo"].ToString();
                        c.Odontologo.Nombre = o.Nombre;
                        c.Fecha = DateTime.Parse(dr["fecha"].ToString());
                        string hour = dr["hora"].ToString();
                        c.Hora = DateTime.ParseExact(hour, "HH:mm:ss", CultureInfo.InvariantCulture);
                        o.Consultorio = Convert.ToInt32(dr["consultorio"]);
                        c.Odontologo.Consultorio = o.Consultorio;
                        citas.Add(c);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al consultar en la tabla Cita " + ex.Message);
                }
            }
            con.Cerrar();
            return citas;
        }

        public List<Cita> ConsultarCitas(string cedula, DateTime fecha, string hora, int n)
        {
            List<Cita> citas = new List<Cita>();
            Cita c = null;
            Odontologo o = null;
            Paciente pa = null;
            string sql = "SELECT C.id_cita, P1.cedula, P1.nombre as paciente, P2.nombre as odontologo, C.fecha, C.hora, " +
                         "O.consultorio \n" +
                         "FROM Cita C, Odontologo O, Persona P1, Persona P2 \n" +
                         "WHERE P1.id_persona = C.id_paciente \n" +
                         "AND P2.id_persona = C.id_odontologo \n" +
                         "AND C.id_odontologo = O.consultorio \n";
            string sqlCedula = "P1.cedula = '" + cedula + "' \n";
            string sqlFecha = "C.fecha = '" + fecha.ToString("yyyy-MM-dd") + "' \n";
            string sqlHora = "C.hora = '" + hora + "' ";
            SqlDataReader dr = null;
            Console.WriteLine(sql);
            string mensaje = "";
            mensaje = con.Conectar();
            if (mensaje[0] == '1')
            {
                try
                {
                    cmd.Connection = con.Cn;
                    if (n == 1)
                    {
                        cmd.CommandText = sql +
                        "AND " + sqlCedula;
                    }
                    else if (n == 2)
                    {
                        cmd.CommandText = sql +
                        "AND " + sqlFecha;
                    }
                    else if (n == 3)
                    {
                        cmd.CommandText = sql +
                        "AND " + sqlHora;
                    }
                    else if (n == 4)
                    {
                        cmd.CommandText = sql +
                            "AND " + sqlCedula +
                            "AND " + sqlHora;
                    }
                    else if (n == 5)
                    {
                        cmd.CommandText = sql +
                            "AND " + sqlCedula +
                            "AND " + sqlFecha;
                    }
                    else if (n == 6)
                    {
                        cmd.CommandText = sql +
                            "AND " + sqlFecha +
                            "AND " + sqlHora;
                    }
                    else if (n == 7)
                    {
                        cmd.CommandText = sql +
                            "AND " + sqlCedula +
                            "AND " + sqlFecha +
                            "AND " + sqlHora;
                    }
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        c = new Cita();
                        pa = new Paciente();
                        o = new Odontologo();

                        c.Id_cita = Convert.ToInt32(dr["id_cita"]);
                        pa.Cedula = dr["cedula"].ToString();
                        c.Paciente.Cedula = pa.Cedula;
                        pa.Nombre = dr["paciente"].ToString();
                        c.Paciente.Nombre = pa.Nombre;
                        o.Nombre = dr["odontologo"].ToString();
                        c.Odontologo.Nombre = o.Nombre;
                        c.Fecha = DateTime.Parse(dr["fecha"].ToString());
                        string hour = dr["hora"].ToString();
                        c.Hora = DateTime.ParseExact(hour, "HH:mm:ss", CultureInfo.InvariantCulture);
                        o.Consultorio = Convert.ToInt32(dr["consultorio"]);
                        c.Odontologo.Consultorio = o.Consultorio;
                        citas.Add(c);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al consultar en la tabla Cita " + ex.Message);
                }
            }
            con.Cerrar();
            return citas;
        }

        public List<Cita> ConsultarCitasF(DateTime fecha)
        {
            List<Cita> citas = new List<Cita>();
            Cita c = null;
            Odontologo o = null;
            Paciente pa = null;
            string sql = "SELECT C.id_cita, P1.nombre as paciente, P2.nombre as odontologo, C.fecha, " +
                         "C.hora, O.consultorio \n" +
                         "FROM Cita C, Odontologo O, Persona P1, Persona P2 \n" +
                         "WHERE P1.id_persona = C.id_paciente \n" +
                         "AND P2.id_persona = C.id_odontologo \n" +
                         "AND C.id_odontologo = O.consultorio \n" +
                         "AND C.fecha = '" + fecha.ToString("yyyy-MM-dd") + "'";
            SqlDataReader dr = null;
            Console.WriteLine(sql);
            string mensaje = "";
            mensaje = con.Conectar();
            if (mensaje[0] == '1')
            {
                try
                {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        c = new Cita();
                        pa = new Paciente();
                        o = new Odontologo();

                        c.Id_cita = Convert.ToInt32(dr["id_cita"]);
                        pa.Nombre = dr["paciente"].ToString();
                        c.Paciente.Nombre = pa.Nombre;
                        o.Nombre = dr["odontologo"].ToString();
                        c.Odontologo.Nombre = o.Nombre;
                        c.Fecha = DateTime.Parse(dr["fecha"].ToString());
                        string hour = dr["hora"].ToString();
                        c.Hora = DateTime.ParseExact(hour, "HH:mm:ss", CultureInfo.InvariantCulture);
                        o.Consultorio = Convert.ToInt32(dr["consultorio"]);
                        c.Odontologo.Consultorio = o.Consultorio;
                        citas.Add(c);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al consultar en la tabla Cita " + ex.Message);
                }
            }
            con.Cerrar();
            return citas;
        }

        public string EliminarCitas(int id)
        {
            string sql = "DELETE FROM Cita WHERE id_cita = '" + id + "'";
            Console.WriteLine(sql);
            string mensaje = "";
            mensaje = con.Conectar();
            if (mensaje[0] == '1')
            {
                try
                {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    mensaje = "1";
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al eliminar en la tabla Cita " + e.Message);
                    mensaje = "0" + e.Message;
                }
            }
            con.Cerrar();
            return mensaje;
        }

        public string EditarCitas(Cita c)
        {
            string mensaje = "";
            string sql = "UPDATE Cita \n" +
                         "SET id_paciente = '" + c.Paciente.Id_persona + "' , id_odontologo = '"
                         + c.Odontologo.Id_persona + "'," +
                         "fecha = '" + c.Fecha + "'," +
                         "hora = '" + c.Hora + "'\n" +
                         "WHERE id_cita = '" + c.Id_cita + "'";
            Console.WriteLine(sql);
            mensaje = con.Conectar();
            if (mensaje[0] == '1')
            {
                try
                {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    mensaje = "1";
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al actualizar en la tabla Cita " + e.Message);
                    mensaje = "0" + e.Message;
                }
            }
            con.Cerrar();
            return mensaje;
        }

        public bool ConsultarCitasExistentes(string cedula, DateTime fecha, DateTime hora)
        {
            bool flag = true;
            string sql = "SELECT C.id_cita, P1.cedula, P1.nombre as paciente, P2.nombre as odontologo, C.fecha, C.hora, " +
                         "O.consultorio \n" +
                         "FROM Cita C, Odontologo O, Persona P1, Persona P2 \n" +
                         "WHERE P1.id_persona = C.id_paciente \n" +
                         "AND P2.id_persona = C.id_odontologo \n" +
                         "AND C.id_odontologo = O.consultorio \n" +
                         "AND P1.cedula = '" + cedula + "'\n" +
                         "AND C.fecha = '" + fecha.ToString("yyyy-MM-dd") + "'\n" +
                         "AND C.hora = '" + hora.ToString("HH:mm:ss") + "'";
            SqlDataReader dr = null;
            Console.WriteLine(sql);
            string mensaje = "";
            mensaje = con.Conectar();
            if (mensaje[0] == '1')
            {
                cmd.Connection = con.Cn;
                cmd.CommandText = sql;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    flag = true;
                }
                flag = false;
            }
            con.Cerrar();
            return flag;
        }

        public int ConsultarId(string cedula, DateTime fecha, DateTime hora, string odontologo)
        {
            int idCita = 0;
            string sql = "SELECT C.id_cita \n" +
                         "FROM Cita C, Odontologo O, Persona P1, Persona P2 \n" +
                         "WHERE P1.id_persona = C.id_paciente \n" +
                         "AND P2.id_persona = C.id_odontologo \n" +
                         "AND C.id_odontologo = O.consultorio \n" +
                         "AND P1.cedula = '" + cedula + "'\n" +
                         "AND C.fecha = '" + fecha.ToString("yyyy-MM-dd") + "'\n" +
                         "AND C.hora = '" + hora.ToString("HH:mm:ss") + "'\n" +
                         "AND P2.nombre = '" + odontologo + "'";
            SqlDataReader dr = null;
            Console.WriteLine(sql);
            string mensaje = "";
            mensaje = con.Conectar();
            if (mensaje[0] == '1')
            {
                cmd.Connection = con.Cn;
                cmd.CommandText = sql;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    idCita = Convert.ToInt32(dr["id_cita"]);
                }

            }
            return idCita;
        }

        //----------------------------------------------------------------------------------
        public Cita ConsultarCitaxCedula(string cedula)
        {
            //List<Cita> citas = new List<Cita>();
            Cita c = null;
            Odontologo o = null;
            Paciente pa = null;
            string sql = "SELECT Persona.cedula, Cita.id_cita, Cita.id_paciente" +
                         " FROM Persona INNER JOIN \n" +
                         "Paciente ON Persona.id_persona = Paciente.id_persona INNER JOIN" +
                         " Cita ON Paciente.id_paciente = Cita.id_paciente" +
                         " WHERE Persona.cedula = '" + cedula + "'";
            SqlDataReader dr = null;
            Console.WriteLine(sql);
            string mensaje = "";
            mensaje = con.Conectar();
            if (mensaje[0] == '1')
            {
                try
                {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        c = new Cita();
                        pa = new Paciente();
                        o = new Odontologo();

                        c.Id_cita = Convert.ToInt32(dr["id_cita"]);
                        pa.Cedula = dr["cedula"].ToString();
                        c.Paciente.Cedula = pa.Cedula;
                        pa.Nombre = dr["paciente"].ToString();
                        c.Paciente.Nombre = pa.Nombre;
                        o.Nombre = dr["odontologo"].ToString();
                        c.Odontologo.Nombre = o.Nombre;
                        c.Fecha = DateTime.Parse(dr["fecha"].ToString());
                        string hour = dr["hora"].ToString();
                        c.Hora = DateTime.ParseExact(hour, "HH:mm:ss", CultureInfo.InvariantCulture);
                        o.Consultorio = Convert.ToInt32(dr["consultorio"]);
                        c.Odontologo.Consultorio = o.Consultorio;
                        //citas.Add(c);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al consultar en la tabla Cita " + ex.Message);
                }
            }
            con.Cerrar();
            return c;
        }
    }
}
