using Model;
using Proyecto_Dentalig;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace Datos {
    public class DatosHorarioEGGM {
        List<Horario> horario = new List<Horario> ();
        Conexion con = new Conexion ();
        SqlCommand cmd = new SqlCommand ();
        public List<Horario> Horario { get => horario; set => horario = value; }

        //CONSULTA LOS HORARIO DE TODO TIPO, SIN IMPORTAR DIA.
        public List<Horario> consultarTodoHorario () {
            Dias x = null;
            Horario h = null;
            List<Dias> dia = new List<Dias> ();
            List<string> dias = new List<string> ();
            List<Horario> horarioE2GM = new List<Horario> ();
            string sql = " SELECT Dias.dia, Horario.tipo, Dias.horaEntrada, Dias.horaSalida" +
                       " FROM Dias INNER JOIN" +
                       " HorarioDias ON Dias.id_dias = HorarioDias.id_dias INNER JOIN" +
                       " Horario ON HorarioDias.id_horario = Horario.id_Horario";
            SqlDataReader dr = null; //tabla virtual
            Console.WriteLine (sql);
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    dr = cmd.ExecuteReader ();
                    while (dr.Read ()) {
                        x = new Dias ("", DateTime.Now, DateTime.Now);
                        h = new Horario (dia, "");
                        x.Dia = dr ["dia"].ToString ();
                        h.Tipo = dr ["tipo"].ToString ();
                        x.HoraEntrada = Convert.ToDateTime (dr ["horaEntrada"].ToString ());
                        x.HoraSalida = Convert.ToDateTime (dr ["horaSalida"].ToString ());
                        h.Dias.Add (x);
                        horarioE2GM.Add (h);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("Erro al consultar las Tabla Horario, Dias, HorarioDias" + ex.Message);
                }
            }
            con.Cerrar ();
            return horarioE2GM;

        }

        //CONSULTA LOS HORARIO DE TODO TIPO, SIN IMPORTAR DIA.
        public List<Horario> consultarHorario (string diasH, string tipo) {
            Dias x = null;
            string sql = "";
            Horario h = null;
            List<Dias> dia = new List<Dias> ();
            List<string> dias = new List<string> ();
            List<Horario> horarioE2GM = new List<Horario> ();
            if ((diasH == "") & (String.IsNullOrEmpty (tipo) == false & tipo != "Fines de semana")) {
                sql = " SELECT Dias.dia, Horario.tipo, Dias.horaEntrada, Dias.horaSalida" +
                            " FROM Dias INNER JOIN" +
                            " HorarioDias ON Dias.id_dias = HorarioDias.id_dias INNER JOIN" +
                            " Horario ON HorarioDias.id_horario = Horario.id_Horario" +
                            " WHERE (Horario.tipo = '" + tipo + "I') OR (Horario.tipo = '" + tipo + "II')";
            } else if ((tipo == "") & (String.IsNullOrEmpty (diasH) == false)) {
                sql = " SELECT Dias.dia, Horario.tipo, Dias.horaEntrada, Dias.horaSalida" +
                            " FROM Dias INNER JOIN" +
                            " HorarioDias ON Dias.id_dias = HorarioDias.id_dias INNER JOIN" +
                            " Horario ON HorarioDias.id_horario = Horario.id_Horario" +
                            " WHERE (Dias.dia = '" + diasH + "')";
            } else if (tipo != "Fines de semana" & (String.IsNullOrEmpty (diasH) == false)) {
                sql = " SELECT Dias.dia, Horario.tipo, Dias.horaEntrada, Dias.horaSalida" +
                           " FROM Dias INNER JOIN" +
                           " HorarioDias ON Dias.id_dias = HorarioDias.id_dias INNER JOIN" +
                           " Horario ON HorarioDias.id_horario = Horario.id_Horario" +
                           " WHERE (Horario.tipo = '" + tipo + "I' AND Dias.dia = '" + diasH + "')" +
                           " OR (Horario.tipo = '" + tipo + "II' AND Dias.dia = '" + diasH + "')";
            } else if (tipo == "Fines de semana" & (diasH == "")) {
                sql = " SELECT Dias.dia, Horario.tipo, Dias.horaEntrada, Dias.horaSalida" +
                           " FROM Dias INNER JOIN" +
                           " HorarioDias ON Dias.id_dias = HorarioDias.id_dias INNER JOIN" +
                           " Horario ON HorarioDias.id_horario = Horario.id_Horario" +
                           " WHERE (Horario.tipo = '" + tipo + "')";
            } else {
                sql = " SELECT Dias.dia, Horario.tipo, Dias.horaEntrada, Dias.horaSalida" +
                           " FROM Dias INNER JOIN" +
                           " HorarioDias ON Dias.id_dias = HorarioDias.id_dias INNER JOIN" +
                           " Horario ON HorarioDias.id_horario = Horario.id_Horario" +
                           " WHERE (Horario.tipo = '" + tipo + "' AND Dias.dia = '" + diasH + "')" +
                           " OR (Horario.tipo = '" + tipo + "' AND Dias.dia = '" + diasH + "')";
            }
            SqlDataReader dr = null; //tabla virtual
            Console.WriteLine (sql);
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    dr = cmd.ExecuteReader ();
                    while (dr.Read ()) {
                        x = new Dias ("", DateTime.Now, DateTime.Now);
                        h = new Horario (dia, "");
                        x.Dia = dr ["dia"].ToString ();
                        h.Tipo = dr ["tipo"].ToString ();
                        x.HoraEntrada = Convert.ToDateTime (dr ["horaEntrada"].ToString ());
                        x.HoraSalida = Convert.ToDateTime (dr ["horaSalida"].ToString ());
                        h.Dias.Add (x);
                        horarioE2GM.Add (h);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("Erro al consultar las Tabla Horario, Dias, HorarioDias" + ex.Message);
                }
            }
            con.Cerrar ();
            return horarioE2GM;
        }

        //
        public List<Horario> consultarHorarioACt (string tipo) {
            Dias x = null;
            Horario h = null;
            List<Dias> dia = new List<Dias> ();
            List<string> dias = new List<string> ();
            List<Horario> horarioE2GM = new List<Horario> ();
            string sql = " SELECT Dias.dia, Horario.tipo, Dias.horaEntrada, Dias.horaSalida" +
                          " FROM Dias INNER JOIN" +
                          " HorarioDias ON Dias.id_dias = HorarioDias.id_dias INNER JOIN" +
                          " Horario ON HorarioDias.id_horario = Horario.id_Horario" +
                          " WHERE (Horario.tipo = '" + tipo + "')";
            SqlDataReader dr = null; //tabla virtual
            Console.WriteLine (sql);
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    dr = cmd.ExecuteReader ();
                    while (dr.Read ()) {
                        x = new Dias ("", DateTime.Now, DateTime.Now);
                        h = new Horario (dia, "");
                        x.Dia = dr ["dia"].ToString ();
                        h.Tipo = dr ["tipo"].ToString ();
                        x.HoraEntrada = Convert.ToDateTime (dr ["horaEntrada"].ToString ());
                        x.HoraSalida = Convert.ToDateTime (dr ["horaSalida"].ToString ());
                        h.Dias.Add (x);
                        horarioE2GM.Add (h);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("Erro al consultar las Tabla Horario, Dias, HorarioDias" + ex.Message);
                }
            }
            con.Cerrar ();
            return horarioE2GM;
        }

        //
        public Horario consultarTipodeHoraario (int horario) {
            string sql = "Select * from Horario where id_Horario = " + horario;
            SqlDataReader dr = null; //tabla virtual
            Horario d = new Horario ();
            Dias dia = new Dias ();
            Console.WriteLine (sql);
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    dr = cmd.ExecuteReader ();
                    if (dr.Read ()) {
                        d.Tipo = Convert.ToString (dr ["tipo"].ToString ());
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("Erro al consultar las Tabla Horario, Dias, HorarioDias" + ex.Message);
                }
            }
            con.Cerrar ();
            return d;
        }

    }
}