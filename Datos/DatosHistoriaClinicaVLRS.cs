using Model;
using Proyecto_Dentalig;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos {
    public class DatosHistoriaClinicaVLRS {

        // Variables
        Conexion con = new Conexion ();
        SqlCommand cmd = new SqlCommand ();

        /*----------------------------------------VLRS------------------------------------------------------*/

        // Method: DatosHistoriaClinicaVLRS
        public string insertar (HistoriaClinica hisclinica) {
            string sql = "INSERT INTO Historia_Clinica (id_paciente,id_antecedentes) VALUES(" + hisclinica.Paciente.Id_paciente + "," +
                        hisclinica.Antecedente.Id_antecedente + ")";
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

        // Method: consutarHistClinic
        public HistoriaClinica consutarHistClinic (long id_paciente) { //consulta en la tabla historia clinica
            HistoriaClinica hclinic = null;
            Paciente paciente = null;
            Antecedente antecedente = null;
            string sql = "Select * from Historia_Clinica where id_paciente=" + id_paciente;
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
                        paciente = new Paciente ();
                        antecedente = new Antecedente ();
                        hclinic = new HistoriaClinica ();
                        hclinic.Antecedente = antecedente;
                        hclinic.Paciente = paciente;
                        hclinic.Id_hclinica = Convert.ToInt32 (dr ["id_historiaClinica"]);
                        hclinic.Paciente.Id_paciente = Convert.ToInt32 (dr ["id_paciente"]);
                        hclinic.Antecedente.Id_antecedente = Convert.ToInt32 (dr ["id_antecedentes"]);
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en la tabla Historia Clinica " + ex.Message);
                }
            }
            con.Cerrar ();
            return hclinic;
        }

        // Method: Eliminar
        public String Eliminar (long id_paciente) {
            string sql = "Delete from Historia_Clinica where id_paciente=" + id_paciente;
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
                    Console.WriteLine ("Error al eliminar en la tabla Historia Clinica " + e.Message);
                    return "0" + e.Message;
                }
            }
            con.Cerrar ();
            return mensaje;
        }


        // Method: ConsultarTodos
        public List<HistoriaClinica> ConsultarTodos () {
            HistoriaClinica hclinic = null;
            Paciente paciente = null;
            Antecedente antecedente = null;
            List<HistoriaClinica> listaHclinicas = new List<HistoriaClinica> ();
            string sql = "SELECT Historia_Clinica.id_historiaClinica, Persona.cedula, Persona.nombres, Persona.id_sexo, Persona.fechaNacimiento, Paciente.discapacidad, EtapaEdad.etapa, Antecedentes.antecedentePersonal, Antecedentes.antecedenteFamiliar \n" +
                "FROM Antecedentes \n" +
                "INNER JOIN HistoriaClinica Historia_Clinica ON Antecedentes.id_antecedentes = Historia_Clinica.id_antecedentes \n" +
                "INNER JOIN Paciente ON Historia_Clinica.id_paciente = Paciente.id_paciente \n" +
                "INNER JOIN Persona ON Paciente.id_paciente = Persona.id_persona \n" +
                "INNER JOIN EtapaEdad ON Paciente.id_etapaEdad = EtapaEdad.id_etapaEdad \n";
            SqlDataReader dr = null; //tabla virtual
            Console.WriteLine (sql);
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    dr = cmd.ExecuteReader ();
                    while (dr.Read ()) { //porq son varios regsitros se cambia a while
                        paciente = new Paciente ();
                        antecedente = new Antecedente ();
                        hclinic = new HistoriaClinica ();
                        hclinic.Antecedente = antecedente;
                        hclinic.Paciente = paciente;
                        hclinic.Id_hclinica = Convert.ToInt32 (dr ["id_historiaClinica"]);
                        hclinic.Paciente.Cedula = dr ["cedula"].ToString ();
                        hclinic.Paciente.Nombre = dr ["nombres"].ToString ();
                        hclinic.Paciente.Sexo = Convert.ToChar (dr ["id_sexo"]);
                        hclinic.Paciente.FechaNacimiento = Convert.ToDateTime (dr ["fechaNacimiento"]);
                        hclinic.Paciente.Discapacidad = dr ["discapacidad"].ToString ();
                        hclinic.Paciente.Etapa = dr ["etapa"].ToString ();
                        hclinic.Antecedente.Antecedenteper = dr ["antecedentePersonal"].ToString ();
                        hclinic.Antecedente.AntecedenteFam = dr ["antecedenteFamiliar"].ToString ();
                        listaHclinicas.Add (hclinic);//añadir a la list
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en las tablas " + ex.Message);
                }
            }
            con.Cerrar ();
            return listaHclinicas;
        }

        // Method: ConsultarXsexoXCedulaXFechas
        public List<HistoriaClinica> ConsultarXsexoXCedulaXFechas (char sexo, string cedula, DateTime fechaDesde, DateTime fechaHasta, int index, int rbindex) {
            HistoriaClinica hclinic = null;
            Paciente paciente = null;
            Antecedente antecedente = null;
            List<HistoriaClinica> listaHclinicas = new List<HistoriaClinica> ();
            string sql = "SELECT Historia_Clinica.id_historiaClinica, Persona.cedula, Persona.nombre, Persona.id_sexo, Persona.fechaNacimiento, " +
                                "Paciente.discapacidad, EtapaEdad.etapa, Antecedentes.antecedentePersonal, Antecedentes.antecedenteFamiliar \n" +
                        " FROM Antecedentes INNER JOIN \n" +
                            " Historia_Clinica ON Antecedentes.id_antecedentes = Historia_Clinica.id_antecedentes INNER JOIN \n" +
                            " Paciente ON Historia_Clinica.id_paciente = Paciente.id_paciente INNER JOIN \n" +
                            " Persona ON Paciente.id_persona = Persona.id_persona INNER JOIN \n" +
                            " EtapaEdad ON Paciente.id_etapaEdad = EtapaEdad.id_etapaEdad \n";
            string sqlsexo = " (Persona.id_sexo = '" + sexo + "') \n";
            string sqlcedula = " (Persona.cedula = '" + cedula + "') \n";
            string sqlfechas = " Persona.fechaNacimiento BETWEEN' " + fechaDesde.ToString ("yyyy-MM-dd") + "' AND '" + fechaHasta.ToString ("yyyy-MM-dd") + "'";
            SqlDataReader dr = null; //tabla virtual
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                try {
                    cmd.Connection = con.Cn;
                    if (index == 0) {
                        if (cedula != "") {
                            cmd.CommandText = sql + " Where " + sqlcedula;
                            Console.WriteLine ("1" + cmd.CommandText);
                        }
                    } else if (rbindex == 2) {
                        if (sexo != ' ') {
                            cmd.CommandText = sql + " Where " + sqlsexo;
                            Console.WriteLine ("2" + cmd.CommandText);
                        }
                    } else if (rbindex == 3) {
                        if (fechaDesde != null && fechaHasta != null) {
                            cmd.CommandText = sql + " Where " + sqlfechas;
                            Console.WriteLine ("3" + cmd.CommandText);
                        }
                    } else if (rbindex == 4) {
                        if (sexo != ' ' && fechaDesde != null && fechaHasta != null) {
                            cmd.CommandText = sql + " Where " + sqlsexo + " And " + sqlfechas;
                            Console.WriteLine ("4" + cmd.CommandText);
                        }
                    }
                    dr = cmd.ExecuteReader ();
                    while (dr.Read ()) {
                        paciente = new Paciente ();
                        antecedente = new Antecedente ();
                        hclinic = new HistoriaClinica ();
                        hclinic.Antecedente = antecedente;
                        hclinic.Paciente = paciente;
                        hclinic.Id_hclinica = Convert.ToInt32 (dr ["id_historiaClinica"]);
                        hclinic.Paciente.Cedula = dr ["cedula"].ToString ();
                        hclinic.Paciente.Nombre = dr ["nombre"].ToString ();
                        hclinic.Paciente.Sexo = Convert.ToChar (dr ["id_sexo"]);
                        hclinic.Paciente.FechaNacimiento = Convert.ToDateTime (dr ["fechaNacimiento"]);
                        hclinic.Paciente.Discapacidad = dr ["discapacidad"].ToString ();
                        hclinic.Paciente.Etapa = dr ["etapa"].ToString ();
                        hclinic.Antecedente.Antecedenteper = dr ["antecedentePersonal"].ToString ();
                        hclinic.Antecedente.AntecedenteFam = dr ["antecedenteFamiliar"].ToString ();
                        listaHclinicas.Add (hclinic);//añadir a la list
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en las tablas " + ex.Message);
                }
            }
            con.Cerrar ();
            return listaHclinicas;
        }

        // Method: ConsultarXCedula
        public HistoriaClinica ConsultarXCedula (string cedula) { //Consulta en las tablas antecedentes, persona, paciente, historia clinica
            HistoriaClinica hclinic = null;
            Paciente paciente = null;
            Antecedente antecedente = null;
            string sql = "SELECT Persona.cedula, Persona.nombre, Persona.fechaNacimiento, Persona.telefono, Persona.correo, Paciente.discapacidad, Antecedentes.antecedenteFamiliar, Antecedentes.antecedentePersonal," +
                  " Persona.id_sexo" +
                    " FROM Antecedentes INNER JOIN" +
                    " Historia_Clinica ON Antecedentes.id_antecedentes = Historia_Clinica.id_antecedentes INNER JOIN" +
                    " Paciente ON Historia_Clinica.id_paciente = Paciente.id_paciente INNER JOIN" +
                    " Persona ON Paciente.id_persona = Persona.id_persona INNER JOIN" +
                    " Sexo ON Persona.id_sexo = Sexo.id_sexo" +
                    " WHERE (Persona.cedula = '" + cedula + "')";
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
                        paciente = new Paciente ();
                        antecedente = new Antecedente ();
                        hclinic = new HistoriaClinica ();
                        hclinic.Antecedente = antecedente;
                        hclinic.Paciente = paciente;
                        hclinic.Paciente.Cedula = dr ["cedula"].ToString ();
                        hclinic.Paciente.Nombre = dr ["nombre"].ToString ();
                        hclinic.Paciente.Sexo = Convert.ToChar (dr ["id_sexo"]);
                        hclinic.Paciente.Discapacidad = dr ["discapacidad"].ToString ();
                        hclinic.Paciente.FechaNacimiento = DateTime.Parse (dr ["fechaNacimiento"].ToString ());
                        hclinic.Paciente.Correo = dr ["correo"].ToString ();
                        hclinic.Paciente.Telefono = dr ["telefono"].ToString ();
                        hclinic.Antecedente.Antecedenteper = dr ["antecedentePersonal"].ToString ();
                        hclinic.Antecedente.AntecedenteFam = dr ["antecedenteFamiliar"].ToString ();
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("Error al consultar en las tablas " + ex.Message);
                }
            }
            con.Cerrar ();
            return hclinic;
        }

        /*----------------------------------------ROPB------------------------------------------------------*/

        // Method: ConsultarIdHistoriaClinica
        public int ConsultarIdHistoriaClinica (string nombre) {
            int idCH = 0;
            string sql = "SELECT HC.id_historiaClinica \n" +
                "FROM HistoriaClinica HC \n" +
                "inner join Persona P ON P.id_persona = HC.id_paciente \n" +
                "WHERE P.nombres = '" + nombre + "';";
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
                        idCH = Convert.ToInt32 (dr ["id_historiaClinica"].ToString ());
                    }
                } catch (Exception ex) {
                    Console.WriteLine ("¡---ERROR---ConsultarIdHistoriaClinica---! " + ex.Message);
                }
            }
            return idCH;
        }

    }
}
