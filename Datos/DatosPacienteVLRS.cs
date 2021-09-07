﻿using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos
{
    public class DatosPacienteVLRS
    {
        ConexionVLRS con = new ConexionVLRS();
        SqlCommand cmd = new SqlCommand();
        public String insertar(Paciente paciente)  //Persona
        {
            string sql = "INSERT INTO Paciente (id_persona,discapacidad,id_etapaEdad) VALUES(" + paciente.Id_persona + ",'" +
                paciente.Discapacidad + "'," + paciente.Id_EtapaEdad() + ")";
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
                    Console.WriteLine("Error al insertar en la tabla auto " + e.Message);
                    return "0" + e.Message;
                }
            }
            con.Cerrar();
            return mensaje;

        }

        public Paciente consultarPersonaPac(string cedula)
        {
            Paciente pa = null;
            string sql = "SELECT Persona.id_persona, Persona.cedula, Persona.nombre, Persona.fechaNacimiento, Persona.telefono," +
                              " Persona.correo, Persona.id_sexo, Paciente.id_paciente, Paciente.discapacidad,"
                            + " Paciente.id_etapaEdad" +
                        " FROM Persona INNER JOIN" +
                             " Paciente ON Persona.id_persona = Paciente.id_persona" +
                        " WHERE(Persona.cedula ='" + cedula + "')";

            SqlDataReader dr = null; //tabla virtual
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
                        pa = new Paciente();
                        pa.Id_persona = Convert.ToInt32(dr["id_persona"]);
                        pa.Cedula = dr["cedula"].ToString();
                        pa.Nombre = dr["nombre"].ToString();
                        pa.FechaNacimiento = Convert.ToDateTime(dr["fechaNacimiento"]);
                        pa.Telefono = dr["telefono"].ToString();
                        pa.Correo = dr["correo"].ToString();
                        pa.Sexo = Convert.ToChar(dr["id_sexo"]);
                        pa.Id_paciente = Convert.ToInt32(dr["id_paciente"]);
                        pa.Discapacidad = dr["discapacidad"].ToString();
                        pa.Id_etapaEdad = Convert.ToInt32(dr["id_etapaEdad"]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al consultar en la tabla persona " + ex.Message);
                }

            }
            con.Cerrar();
            return pa;
        }
        public String Eliminar(long id_paciente)
        {
            string sql = "Delete from Paciente where id_paciente=" + id_paciente;
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
                    Console.WriteLine("Error al eliminar en la tabla Paciente " + e.Message);
                    return "0" + e.Message;
                }

            }
            con.Cerrar();
            return mensaje;
        }

        public String Actualizar(Paciente paciente, long id_persona)
        {
            string sql = "UPDATE  Paciente " +
                " SET discapacidad= '" + paciente.Discapacidad + "',id_etapaEdad= " + paciente.Id_EtapaEdad() +
                " WHERE id_persona =" + id_persona;
            ;
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
                    Console.WriteLine("Error al actualizar en la tabla paciente " + e.Message);
                    return "0" + e.Message;
                }
            }
            con.Cerrar();
            return mensaje;
        }
    }
}
