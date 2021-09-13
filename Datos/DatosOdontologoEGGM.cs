using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos
{
    public class DatosOdontologoEGGM
    {
        ConexionHLBV con = new ConexionHLBV();
        SqlCommand cmd = new SqlCommand();

        public List<Odontologo> ConsultarOdontologos(string dia, DateTime hora)
        {
            List<Odontologo> odontologos = new List<Odontologo>();
            Odontologo o = null;
            string sql = "SELECT PE.id_persona, PE.cedula, PE.id_sexo, PE.nombre, PE.fecha_nacimiento," +
            "O.id_horario, O.consultorio \n" +
            "FROM Persona PE \n" +
            "INNER JOIN Odontologo O ON PE.id_persona = O.id_persona \n" +
            "INNER JOIN Horario H ON O.id_horario = H.id_horario \n" +
            "INNER JOIN HorarioDias HD ON H.id_horario = HD.id_horario \n" +
            "INNER JOIN Dias D ON HD.id_dias = D.id_dias \n" +
            "WHERE D.dia = '" + dia + "' \n" +
            "AND '" + hora + "'  BETWEEN D.hora_entrada AND D.hora_salida; ";
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
                        o = new Odontologo();
                        o.Id_persona = Convert.ToInt32(dr["id_persona"]);
                        o.Cedula = dr["cedula"].ToString();
                        o.Sexo = Convert.ToChar(dr["id_sexo"]);
                        o.Nombre = dr["nombre"].ToString();
                        o.FechaNacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]);
                        o.Consultorio = Convert.ToInt32(dr["consultorio"]);
                        odontologos.Add(o);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al consultar en la tabla paciente " + ex.Message);
                }
            }
            con.Cerrar();
            return odontologos;
        }

        public Odontologo ConsultarOdontologo(string nombre)
        {
            Odontologo o = null;
            string sql = "SELECT PE.id_persona, PE.cedula, PE.id_sexo, PE.nombre, PE.fecha_nacimiento," +
            "O.consultorio \n" +
            "FROM Persona PE \n" +
            "INNER JOIN Odontologo O ON PE.id_persona = O.id_persona \n" +
            "WHERE PE.nombre = '" + nombre + "' ;";
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
                    if (dr.Read())
                    {
                        o = new Odontologo();
                        o.Id_persona = Convert.ToInt32(dr["id_persona"]);
                        o.Cedula = dr["cedula"].ToString();
                        o.Sexo = Convert.ToChar(dr["id_sexo"]);
                        o.Nombre = dr["nombre"].ToString();
                        o.FechaNacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]);
                        o.Consultorio = Convert.ToInt32(dr["consultorio"]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al consultar en la tabla paciente " + ex.Message);
                }
            }
            con.Cerrar();
            return o;
        }

    }
}
