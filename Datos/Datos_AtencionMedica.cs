using Proyecto_Dentalig;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos {
    public class Datos_AtencionMedica {

        // Variable
        Conexion con = new Conexion ();
        SqlCommand cmd = new SqlCommand ();

        /*----------------------------------------ROPB------------------------------------------------------*/

        // Method: InsertarAteniconMedica
        public string InsertarAteniconMedica (AtencionMedica am) {
            Datos_HistoriaClinica dhc = new Datos_HistoriaClinica ();
            Datos_Cita dc = new Datos_Cita ();
            string sql = "INSERT INTO AtencionMedica (id_historiaClinica, id_cita,  id_piezaDental, motivoConsulta, diagnostico) \n" +
                "VALUES ('" + dhc.ConsultarIdHistoriaClinica (am.Cita.Paciente.Nombre) + "','" + dc.CosultarIdCita (am.Cita.Paciente.Nombre, am.Cita.Fecha, am.Cita.Hora.ToString ("HH:mm")) + "','" + am.PiezaDental.NumeroPieza + "','" + am.MotivoConsulta + "','" + am.Diagnostico + "')";
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
                    Console.WriteLine ("Error al insertar en la tabla Cita " + e.Message);
                    return "0" + e.Message;
                }
            }
            con.Cerrar ();
            return mensaje;
        }

        // Method: CsultarCantidadAM
        public int CsultarCantidadAM () {
            int numeroAM = 0;
            string sql = "SELECT COUNT (*) as cntd FROM AtencionMedica";
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
                        numeroAM = Convert.ToInt32 (dr ["cntd"].ToString ());
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("¡---ERROR---CsultarCantidadAM---! " + ex.Message);
                }
            }
            return numeroAM;
        }

        // Method: ConsultarAntecionesMedicas
        public List<AtencionMedica> ConsultarAntecionesMedicas () {
            List<AtencionMedica> listaAM = new List<AtencionMedica> ();
            AtencionMedica atm = null;
            string sql = "SELECT PP.nombres as paciente, PO.nombres as odontologo, ODO.consultorio as consultorio, C.fecha as fecha, C.hora as hora, PD.id_piezaDental as numeroPieza, CD.nombreCuadrante, NP.nombrePieza, ATM.motivoConsulta, ATM.diagnostico \n" +
                "FROM AtencionMedica ATM \n" +
                "inner join Cita C ON C.id_cita = ATM.id_cita \n" +
                "inner join Persona PP ON PP.id_persona = C.id_paciente \n" +
                "inner join Persona PO ON PO.id_persona = C.id_odontologo \n" +
                "inner join Odontologo ODO ON ODO.id_odontologo = C.id_odontologo \n" +
                "inner join PiezaDental PD ON PD.id_piezaDental = ATM.id_piezaDental \n" +
                "inner Join CuadrantePieza CD ON CD.id_cuadrantePieza = PD.id_cuadrantePieza \n" +
                "inner Join NombrePieza NP ON NP.id_nombrePieza = PD.id_nombrePieza \n";
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
                        atm = new AtencionMedica ();
                        atm.Cita.Paciente.Nombre = dr ["paciente"].ToString ();
                        atm.Cita.Odontologo.Nombre = dr ["odontologo"].ToString ();
                        atm.Cita.Odontologo.Consultorio = Convert.ToInt32 (dr ["consultorio"].ToString ());
                        atm.Cita.Fecha = DateTime.Parse (dr ["fecha"].ToString ());
                        atm.Cita.Hora = Convert.ToDateTime (dr ["hora"].ToString ());
                        atm.PiezaDental.NumeroPieza = Convert.ToInt32 (dr ["numeroPieza"].ToString ());
                        atm.PiezaDental.CuadrantePieza = dr ["nombreCuadrante"].ToString ();
                        atm.PiezaDental.NombrePieza = dr ["nombrePieza"].ToString ();
                        atm.MotivoConsulta = dr ["motivoConsulta"].ToString ();
                        atm.Diagnostico = dr ["diagnostico"].ToString ();
                        listaAM.Add (atm);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("¡---ERROR---ConsultarAntecionesMedicas---! " + ex.Message);
                }
            }
            return listaAM;
        }

        // Method: ConsultarAntecionesMedicasBuscar
        public List<AtencionMedica> ConsultarAntecionesMedicasBuscar (string paciente, DateTime fecha, string hora, int n) {
            List<AtencionMedica> listaAM = new List<AtencionMedica> ();
            AtencionMedica atm = null;
            string sql = "SELECT PP.nombres as paciente, PO.nombres as odontologo, ODO.consultorio as consultorio, C.fecha as fecha, C.hora as hora, PD.id_piezaDental as numeroPieza, CD.nombreCuadrante, NP.nombrePieza, ATM.motivoConsulta, ATM.diagnostico \n" +
                "FROM AtencionMedica ATM \n" +
                "inner join Cita C ON C.id_cita = ATM.id_cita \n" +
                "inner join Persona PP ON PP.id_persona = C.id_paciente \n" +
                "inner join Persona PO ON PO.id_persona = C.id_odontologo \n" +
                "inner join Odontologo ODO ON ODO.id_odontologo = C.id_odontologo \n" +
                "inner join PiezaDental PD ON PD.id_piezaDental = ATM.id_piezaDental \n" +
                "inner Join CuadrantePieza CD ON CD.id_cuadrantePieza = PD.id_cuadrantePieza \n" +
                "inner Join NombrePieza NP ON NP.id_nombrePieza = PD.id_nombrePieza \n";
            string sqlPaciente = "PP.nombres = '" + paciente + "' \n";
            string sqlFecha = "C.fecha = '" + fecha.ToString ("yyyy-MM-dd") + "' \n";
            string sqlHora = "C.hora = '" + hora + "' \n";
            SqlDataReader dr = null;
            Console.WriteLine (sql);
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    if (n == 1) { // bt_Buscar Global
                        if (hora == "---Seleccione---" && paciente == "---Seleccione---") {
                            cmd.CommandText = sql +
                                "Where " + sqlFecha;
                        } else if (hora == "---Seleccione---" && paciente != "---Seleccione---") {
                            cmd.CommandText = sql +
                                "Where " + sqlFecha +
                                "AND " + sqlPaciente;
                        } else if (hora != "---Seleccione---" && paciente == "---Seleccione---") {
                            cmd.CommandText = sql +
                                "Where " + sqlFecha +
                                "AND " + sqlHora;
                        } else if (hora != "---Seleccione---" && paciente != "---Seleccione---") {
                            cmd.CommandText = sql +
                                "Where " + sqlFecha +
                                "AND " + sqlPaciente +
                                "AND " + sqlHora;
                        }
                    } else if (n == 2) { // btm_Buscar Paciente Hora
                        if (hora == "---Seleccione---" && paciente != "---Seleccione---") {
                            cmd.CommandText = sql +
                                "Where " + sqlPaciente;
                        } else if (hora != "---Seleccione---" && paciente == "---Seleccione---") {
                            cmd.CommandText = sql +
                                "Where " + sqlHora;
                        } else if (hora != "---Seleccione---" && paciente != "---Seleccione---") {
                            cmd.CommandText = sql +
                                "Where " + sqlPaciente +
                                "AND " + sqlHora;
                        } else {
                            cmd.CommandText = sql +
                                "Where " + sqlPaciente +
                                "AND " + sqlHora;
                        }
                    }
                    dr = cmd.ExecuteReader ();
                    while (dr.Read ()) {
                        atm = new AtencionMedica ();
                        atm.Cita.Paciente.Nombre = dr ["paciente"].ToString ();
                        atm.Cita.Odontologo.Nombre = dr ["odontologo"].ToString ();
                        atm.Cita.Odontologo.Consultorio = Convert.ToInt32 (dr ["consultorio"].ToString ());
                        atm.Cita.Fecha = DateTime.Parse (dr ["fecha"].ToString ());
                        atm.Cita.Hora = Convert.ToDateTime (dr ["hora"].ToString ());
                        atm.PiezaDental.NumeroPieza = Convert.ToInt32 (dr ["numeroPieza"].ToString ());
                        atm.PiezaDental.CuadrantePieza = dr ["nombreCuadrante"].ToString ();
                        atm.PiezaDental.NombrePieza = dr ["nombrePieza"].ToString ();
                        atm.MotivoConsulta = dr ["motivoConsulta"].ToString ();
                        atm.Diagnostico = dr ["diagnostico"].ToString ();
                        listaAM.Add (atm);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("¡---ERROR---ConsultarAntecionesMedicasBuscar---! " + ex.Message);
                }
            }
            return listaAM;
        }

        // Method: ConsultarAtencionMedicaEditar
        public AtencionMedica ConsultarAtencionMedicaEditar (DateTime fecha, string hora, string paciente) {
            AtencionMedica atm = new AtencionMedica ();
            string sql = "SELECT PP.nombres as paciente, PO.nombres as odontologo, ODO.consultorio as consultorio, C.fecha as fecha, C.hora as hora, PD.id_piezaDental as numeroPieza, CD.nombreCuadrante, NP.nombrePieza, ATM.motivoConsulta, ATM.diagnostico \n" +
               "FROM AtencionMedica ATM \n" +
               "inner join Cita C ON C.id_cita = ATM.id_cita \n" +
               "inner join Persona PP ON PP.id_persona = C.id_paciente \n" +
               "inner join Persona PO ON PO.id_persona = C.id_odontologo \n" +
               "inner join Odontologo ODO ON ODO.id_odontologo = C.id_odontologo \n" +
               "inner join PiezaDental PD ON PD.id_piezaDental = ATM.id_piezaDental \n" +
               "inner Join CuadrantePieza CD ON CD.id_cuadrantePieza = PD.id_cuadrantePieza \n" +
               "inner Join NombrePieza NP ON NP.id_nombrePieza = PD.id_nombrePieza \n" +
               "Where C.fecha = '" + fecha.ToString ("yyyy-MM-dd") + "' \n" +
               "And c.hora = '" + hora + "'\n" +
               "And PP.nombres = '" + paciente + "'";
            SqlDataReader dr = null;
            Console.WriteLine (sql);
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    //cmd.CommandText = sql;
                    if (hora != "---Seleccione---" && paciente != "---Seleccione---") {
                        cmd.CommandText = sql;
                    }
                    dr = cmd.ExecuteReader ();
                    if (dr.Read ()) {
                        //atm = new AtencionMedica ();
                        atm.Cita.Paciente.Nombre = dr ["paciente"].ToString ();
                        atm.Cita.Odontologo.Nombre = dr ["odontologo"].ToString ();
                        atm.Cita.Odontologo.Consultorio = Convert.ToInt32 (dr ["consultorio"].ToString ());
                        atm.Cita.Fecha = DateTime.Parse (dr ["fecha"].ToString ());
                        atm.Cita.Hora = Convert.ToDateTime (dr ["hora"].ToString ());
                        atm.PiezaDental.NumeroPieza = Convert.ToInt32 (dr ["numeroPieza"].ToString ());
                        atm.PiezaDental.CuadrantePieza = dr ["nombreCuadrante"].ToString ();
                        atm.PiezaDental.NombrePieza = dr ["nombrePieza"].ToString ();
                        atm.MotivoConsulta = dr ["motivoConsulta"].ToString ();
                        atm.Diagnostico = dr ["diagnostico"].ToString ();
                        //listaAM.Add (atm);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("¡---ERROR---ConsultarAtencionMedicaEditar---! " + ex.Message);
                }
            }
            return atm;
        }

        // Method: EditarAtencionMedica
        public string EditarAtencionMedica (int idCita, string numeroPieza, string motivoConsulta, string diagnostico) {
            string sql = "UPDATE AtencionMedica \n" +
                "SET id_piezaDental = '" + numeroPieza + "', motivoConsulta = '" + motivoConsulta + "', diagnostico = '" + diagnostico + "' \n" +
                "WHERE id_cita = '" + idCita + "'";
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
                    Console.WriteLine ("Error al insertar en la tabla Cita " + e.Message);
                    return "0" + e.Message;
                }
            }
            con.Cerrar ();
            return mensaje;
        }

        // Method: ConsultarIdAtencionMedica
        public int ConsultarIdAtencionMedica (int idCita) {
            int idAM = 0;
            string sql = "SELECT id_AtencionMedica \n" +
                "FROM AtencionMedica \n" +
                "WHERE id_cita = '" + idCita + "'";
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
                        idAM = Convert.ToInt32 (dr ["id_AtencionMedica"].ToString ());
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("¡---ERROR---ConsultarIdAtencionMedica---! " + ex.Message);
                }
            }
            return idAM;
        }

        // Method: EliminarAtencionMedica
        public string EliminarAtencionMedica (int idAM) {
            string sql = "DELETE FROM AtencionMedica WHERE id_atencionMedica = '" + idAM + "'";
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
                    Console.WriteLine ("Error al eliminar dato. " + e.Message);
                    return "0" + e.Message;
                }
            }
            con.Cerrar ();
            return mensaje;
        }

        public int ConsultarCantidadAMxPaciente (string nombre) {
            int output = -1;
            string sql = "SELECT COUNT (P.nombres) as numero \n"+
                "FROM AtencionMedica AM \n" +
                "INNER JOIN Cita C ON C.id_cita = AM.id_cita \n" +
                "INNER JOIN Persona P ON P.id_persona = C.id_paciente \n" +
                "WHERE nombres = '" + nombre + "'";
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
                        output = Convert.ToInt32 (dr ["numero"].ToString ());
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("¡---ERROR---ConsultarCantidadAMxPaciente---! " + ex.Message);
                }
            }
            return output;
        }

        /*---Reporte iText7.1.14---*/

        // Method: BuscarAtencionMedicaReporte
        public List<AtencionMedica> BuscarAtencionMedicaReporte (string paciente, DateTime fecha, string hora, int n) {
            //DataSet ds = new DataSet (); // Tabla virtual
            string sentenciaSQL = "SELECT PP.nombres as paciente, PO.nombres as odontologo, ODO.consultorio as consultorio, C.fecha as fecha, C.hora as hora, PD.id_piezaDental as numeroPieza, CD.nombreCuadrante, NP.nombrePieza, ATM.motivoConsulta, ATM.diagnostico \n" +
                "FROM AtencionMedica ATM \n" +
                "inner join Cita C ON C.id_cita = ATM.id_cita \n" +
                "inner join Persona PP ON PP.id_persona = C.id_paciente \n" +
                "inner join Persona PO ON PO.id_persona = C.id_odontologo \n" +
                "inner join Odontologo ODO ON ODO.id_odontologo = C.id_odontologo \n" +
                "inner join PiezaDental PD ON PD.id_piezaDental = ATM.id_piezaDental \n" +
                "inner Join CuadrantePieza CD ON CD.id_cuadrantePieza = PD.id_cuadrantePieza \n" +
                "inner Join NombrePieza NP ON NP.id_nombrePieza = PD.id_nombrePieza \n";
            string sqlPaciente = "PP.nombres = '" + paciente + "' \n";
            string sqlFecha = "C.fecha = '" + fecha.ToString ("yyyy-MM-dd") + "' \n";
            string sqlHora = "C.hora = '" + hora + "' \n";
            if (n != 0) { // 0: default
                if (paciente != "---Seleccione---") {
                    sentenciaSQL += "WHERE " + sqlPaciente;
                }
                if (hora != "---Seleccione---") {
                    if (paciente != "---Seleccione---") {
                        sentenciaSQL += "AND " + sqlHora;
                    } else {
                        sentenciaSQL += "WHERE " + sqlHora;
                    }
                }
                if (n == 1) { // 1: btn_Global
                    if (paciente != "---Seleccione---" || hora != "---Seleccione---") {
                        sentenciaSQL += "AND " + sqlFecha;
                    } else {
                        sentenciaSQL += "WHERE " + sqlFecha;
                    }
                }
            }
            return ConsultarAtencionMedicaReporte (sentenciaSQL);
        }

        // Method: ConsultarAtencionMedicaReporte
        private List<AtencionMedica> ConsultarAtencionMedicaReporte (string sql) {
            List<AtencionMedica> listaAM = new List<AtencionMedica> ();
            AtencionMedica atm = null;
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
                        atm = new AtencionMedica ();
                        atm.Cita.Paciente.Nombre = dr ["paciente"].ToString ();
                        atm.Cita.Odontologo.Nombre = dr ["odontologo"].ToString ();
                        atm.Cita.Odontologo.Consultorio = Convert.ToInt32 (dr ["consultorio"].ToString ());
                        atm.Cita.Fecha = DateTime.Parse (dr ["fecha"].ToString ());
                        atm.Cita.Hora = Convert.ToDateTime (dr ["hora"].ToString ());
                        atm.PiezaDental.NumeroPieza = Convert.ToInt32 (dr ["numeroPieza"].ToString ());
                        atm.PiezaDental.CuadrantePieza = dr ["nombreCuadrante"].ToString ();
                        atm.PiezaDental.NombrePieza = dr ["nombrePieza"].ToString ();
                        atm.MotivoConsulta = dr ["motivoConsulta"].ToString ();
                        atm.Diagnostico = dr ["diagnostico"].ToString ();
                        listaAM.Add (atm);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("¡---ERROR---ConsultarAtencionMedicaReporte---! " + ex.Message);
                }
            }
            return listaAM;
        }

        /*----------------------------------------VLRS------------------------------------------------------*/

        //----------------------------------Para eliminar desde historia clinica-------------------------------------------------------------------------

        public string EliminarAtencionMedicaHisCl(int id_Hisclin)//eliminar desde HisCLinica
        {
            string sql = "DELETE FROM AtencionMedica WHERE id_historiaClinica = '" + id_Hisclin + "'";
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
                    Console.WriteLine("Error al eliminar dato. " + e.Message);
                    return "0" + e.Message;
                }
            }
            con.Cerrar();
            return mensaje;
        }
    }
}
