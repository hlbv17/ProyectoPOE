using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos {
    public class ReporteHisClinicaVLRS {

        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        Conexion con = null;

        //
        private DataSet Consultar (string sentenciaSQL) {
            DataSet ds = null; //tabla virtual
            cmd = new SqlCommand ();
            string msj = "";
            try {
                con = new Conexion ();
                msj = con.Conectar ();
                if (msj [0] == '1') {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sentenciaSQL;
                    da = new SqlDataAdapter (cmd.CommandText, cmd.Connection);
                    ds = new DataSet ();
                    da.Fill (ds);
                    con.Cerrar ();
                } else if (msj [0] == '0')
                    con.Cerrar ();
            } catch (SqlException e) {
                Console.WriteLine (e.Message);
            }
            return ds;
        }

        //
        public DataSet Buscar (char sexo, string cedula, DateTime fechaDesde, DateTime fechaHasta, int index, int rbindex) {
            string sentenciaSQL = "";

            string sql = "SELECT Historia_Clinica.id_historiaClinica, Persona.cedula, Persona.nombre, Persona.id_sexo, Persona.fechaNacimiento, " +
                                "Persona.telefono, Persona.correo, Paciente.discapacidad, EtapaEdad.etapa, Antecedentes.antecedentePersonal, Antecedentes.antecedenteFamiliar \n" +
                        " FROM Antecedentes INNER JOIN \n" +
                            " Historia_Clinica ON Antecedentes.id_antecedentes = Historia_Clinica.id_antecedentes INNER JOIN \n" +
                            " Paciente ON Historia_Clinica.id_paciente = Paciente.id_paciente INNER JOIN \n" +
                            " Persona ON Paciente.id_persona = Persona.id_persona INNER JOIN \n" +
                            " EtapaEdad ON Paciente.id_etapaEdad = EtapaEdad.id_etapaEdad \n";
            string sqlsexo = " (Persona.id_sexo = '" + sexo + "') \n";
            string sqlcedula = " (Persona.cedula = '" + cedula + "') \n";
            string sqlfechas = " Persona.fechaNacimiento BETWEEN' " + fechaDesde.ToString ("yyyy-MM-dd") + "' AND '" + fechaHasta.ToString ("yyyy-MM-dd") + "'";


            if (index == 0) {
                if (cedula != "") {
                    sentenciaSQL = sql + " Where " + sqlcedula;
                    Console.WriteLine ("1 reporte " + sentenciaSQL);
                }
            } else if (index == 1 && rbindex == 2) {
                if (sexo != ' ') {
                    sentenciaSQL = sql + " Where " + sqlsexo;
                    Console.WriteLine ("2 reporte " + sentenciaSQL);
                }
            } else if (index == 1 && rbindex == 3) {
                if (fechaDesde != null && fechaHasta != null) {
                    sentenciaSQL = sql + " Where " + sqlfechas;
                    Console.WriteLine ("3 reporte " + sentenciaSQL);
                }
            } else if (index == 1 && rbindex == 4) {
                if (sexo != ' ' && fechaDesde != null && fechaHasta != null) {
                    sentenciaSQL = sql + " Where " + sqlsexo + " And " + sqlfechas;
                    Console.WriteLine ("4 reporte" + sentenciaSQL);
                }
            }
            return Consultar (sentenciaSQL);
        }
    }
}
