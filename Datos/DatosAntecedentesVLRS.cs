using Proyecto_Dentalig;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos
{
    public class DatosAntecedentesVLRS
    {
        Conexion con = new Conexion();
        SqlCommand cmd = new SqlCommand();

        public String insertar(Antecedente anteced)
        {
            string sql = "INSERT INTO Antecedentes (antecedenteFamiliar,antecedentePersonal) VALUES('" + anteced.AntecedenteFam + "','" +
                anteced.Antecedenteper + "')";
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
                    Console.WriteLine("Error al insertar en la tabla auto antecedentes " + e.Message);
                    return "0" + e.Message;
                }
            }
            con.Cerrar();
            return mensaje;

        }

        public Antecedente consultarAntecedente()
        {
            Antecedente antec = null;
            string sql = "Select top(1) * from Antecedentes order by id_antecedentes desc";
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
                        antec = new Antecedente();
                        antec.Id_antecedente = Convert.ToInt32(dr["id_antecedentes"]);
                        antec.AntecedenteFam = dr["antecedenteFamiliar"].ToString();
                        antec.Antecedenteper = dr["antecedentePersonal"].ToString();

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al consultar en la tabla antecedentes " + ex.Message);
                }

            }
            con.Cerrar();
            return antec;
        }

        public String Eliminar(long id_antecedente)
        {
            string sql = "Delete from Antecedentes where id_antecedentes=" + id_antecedente;
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
                    Console.WriteLine("Error al eliminar en la tabla Antecedente " + e.Message);
                    return "0" + e.Message;
                }

            }
            con.Cerrar();
            return mensaje;
        }

        public String Actualizar(Antecedente antecedente, long id_antecedente)
        {
            string sql = "UPDATE  Antecedentes" +
                " SET antecedenteFamiliar= '" + antecedente.AntecedenteFam + "', antecedentePersonal= '" + antecedente.Antecedenteper +
                "' WHERE id_antecedentes =" + id_antecedente;
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
                    Console.WriteLine("Error al actualizar en la tabla antecedentes " + e.Message);
                    return "0" + e.Message;
                }
            }
            con.Cerrar();
            return mensaje;
        }
    }
}
