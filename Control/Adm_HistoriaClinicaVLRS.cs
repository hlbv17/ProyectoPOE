using Datos;
using Model;
using Proyecto_Dentalig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Control
{
    public class Adm_HistoriaClinicaVLRS
    {
        private static Adm_HistoriaClinicaVLRS
            admPaciente = null;//1

        List<Paciente> listapacientes = new List<Paciente>();
        List<HistoriaClinica> listahClinica = new List<HistoriaClinica>();

        DatosPersonaVLRS datospers = new DatosPersonaVLRS();
        DatosPacienteVLRS datosPacien = new DatosPacienteVLRS();
        DatosAntecedentesVLRS datosAnt = new DatosAntecedentesVLRS();
        DatosHistoriaClinicaVLRS datosHistClin = new DatosHistoriaClinicaVLRS();
        ValidacionesVLRS v = new ValidacionesVLRS();

        Persona persona = null;
        Paciente paciente = null;
        Antecedente antecedente = null;


        private Adm_HistoriaClinicaVLRS()
        {//2
            //listapacientes = new List<PacienteVLRS>();
            v = new ValidacionesVLRS();
            datospers = new DatosPersonaVLRS();
            datosPacien = new DatosPacienteVLRS();
            datosAnt = new DatosAntecedentesVLRS();
        }

        public static Adm_HistoriaClinicaVLRS GetAdm()
        { //3
            if (admPaciente == null)
            {
                admPaciente = new Adm_HistoriaClinicaVLRS();
            }
            return admPaciente;
        }


        public ConexionVLRS con = new ConexionVLRS();
        public void Conectar()
        {
            string mensaje = "";
            mensaje = con.Conectar();
            if (mensaje[0] == '1')
            {
                MessageBox.Show("Conexion satisfactoria");
            }
            else
            {
                MessageBox.Show("Error: " + mensaje);
            }
            con.Cerrar();
        }


        public void LlenarGrid(DataGridView dgvPacientes, Label lblTotal)
        {
            ConsultarBBDHclinic();
            int i = 1;

            foreach (HistoriaClinica hcl in listahClinica)
            {

                dgvPacientes.Rows.Add(hcl.Id_hclinica, hcl.Paciente.Cedula, hcl.Paciente.Nombre, hcl.Paciente.LeerSexo(), hcl.Paciente.FechaNacimiento.ToShortDateString(),
                    hcl.Paciente.Discapacidad, hcl.Paciente.Etapa, hcl.Antecedente.Antecedenteper, hcl.Antecedente.AntecedenteFam, hcl.AtencionMedica.Count());
                i++;

            }
            lblTotal.Text = i - 1 + " ";
        }

        public void ConsultarBBDxSexo(string sexo, string cedula, DateTime fechaDesde, DateTime fechasta, DataGridView dgvPacientes, Label lblTotal, int index, int rbindex)
        {
            int i = 1;
            char Csexo = ' ';
            if (sexo != "")
            {
                Csexo = sexo[0];
            }
            dgvPacientes.Rows.Clear();
            listahClinica = datosHistClin.ConsultarXsexoXCedulaXFechas(Csexo, cedula, fechaDesde, fechasta, index, rbindex);

            foreach (HistoriaClinica hcl in listahClinica)
            {

                dgvPacientes.Rows.Add(hcl.Id_hclinica, hcl.Paciente.Cedula, hcl.Paciente.Nombre, hcl.Paciente.LeerSexo(), hcl.Paciente.FechaNacimiento.ToShortDateString(),
                    hcl.Paciente.Discapacidad, hcl.Paciente.Etapa, hcl.Antecedente.Antecedenteper, hcl.Antecedente.AntecedenteFam, hcl.AtencionMedica.Count());
                i++;

            }
            lblTotal.Text = i - 1 + " ";
            if (listahClinica.Count == 0)
                MessageBox.Show("Error: No existen datos con esos parámetros de consulta");
        }

        public void ConsultarBBDHclinic()
        {
            listahClinica = datosHistClin.ConsultarTodos();
            if (listahClinica == null)
                MessageBox.Show("Error: No se consultaron los datos");
        }

        public void Guardar(string cedula, string nombre, string sexo, string telefono, string correo, string discapacidad, string aPersonales, string aFamiliares, DateTime fechaNac, int guar_o_edi)
        {

            Paciente paciente = null;
            Antecedente antecedente = null;
            HistoriaClinica hClnica = null;

            char Csexo = sexo[0];
            antecedente = new Antecedente(aFamiliares, aPersonales);
            paciente = new Paciente(discapacidad, cedula, Csexo, nombre, fechaNac, telefono, correo);
            hClnica = new HistoriaClinica();
            hClnica.Antecedente = antecedente;
            hClnica.Paciente = paciente;
            listahClinica.Add(hClnica);
            if (guar_o_edi == 1)//1 para guardar datos, 2 para actualizarlos
                guardarBDD(paciente, hClnica);
            else if (guar_o_edi == 2)
                ActualizarBBD(paciente, antecedente, hClnica);

        }

        private void ActualizarBBD(Paciente paciente, Antecedente antecedente, HistoriaClinica hisclinica)
        {
            string mensaje = "";
            string mensaje2 = "";
            string mensaje3 = "";
            string mensaje4 = "";

            Paciente pac = datospers.consultarPersona(paciente.Cedula);
            mensaje = datospers.Actualizar(paciente, pac.Cedula);//
            mensaje2 = datosPacien.Actualizar(paciente, pac.Id_persona);

            pac = datosPacien.consultarPersonaPac(paciente.Cedula);
            HistoriaClinica hclin = datosHistClin.consutarHistClinic(pac.Id_paciente);
            mensaje3 = datosAnt.Actualizar(hisclinica.Antecedente, hclin.Antecedente.Id_antecedente);

            if (mensaje[0] == '1')
                MessageBox.Show("Actualizacion de datos de historia clinica correctamente! :)");
            else
                MessageBox.Show("Error: " + mensaje + mensaje2 + mensaje3 + mensaje4);
        }

        public void guardarBDD(Paciente paciente, HistoriaClinica hisclinica)//Al crearse un Paciente por primera vez, se crea su historia clinica
        {
            string mensaje = "";
            string mensaje2 = "";
            string mensaje3 = "";
            string mensaje4 = "";

            mensaje = datospers.insertar(paciente);//insert en Tabla Persona

            Paciente pac = datospers.consultarPersona(paciente.Cedula); //obtengo la persona que inserte en la tabla
            paciente.Id_persona = pac.Id_persona; //Para asi tomar el id_persona y referenciarlo en paciente

            mensaje2 = datosPacien.insertar(paciente);//inserto el paciente en su tabla
            mensaje3 = datosAnt.insertar(hisclinica.Antecedente);//inserto el objeto antecedente en su tabla

            Antecedente antec = datosAnt.consultarAntecedente(); //obtengo el antecedente
            hisclinica.Antecedente.Id_antecedente = antec.Id_antecedente;//tomo el id_antecedente para referenciarlo en
                                                                         //
            pac = datosPacien.consultarPersonaPac(paciente.Cedula);//obtengo el paciente 
            hisclinica.Paciente.Id_paciente = pac.Id_paciente;//para asi tomar su id_paciente y referenciarlo en Hclinica

            mensaje4 = datosHistClin.insertar(hisclinica);//Una vez obtenidos los id, de antecedente y paciente, los inserto en la tabla de Hclinica


            if (mensaje[0] == '1')
                MessageBox.Show("Ingreso de datos de historia clinica correctamente! :)");
            else
                MessageBox.Show("Error: " + mensaje + mensaje2 + mensaje3 + mensaje4);
        }

        public void Eliminar(DataGridView dgvPacientes, string cedula, Label lblTotal, DataGridViewRow filaSeleccionada)
        {
            dgvPacientes.Rows.Remove(filaSeleccionada);
            Paciente pac = datosPacien.consultarPersonaPac(cedula);
            long id_paciente = pac.Id_paciente;
            HistoriaClinica hclinica = datosHistClin.consutarHistClinic(id_paciente);
            datosHistClin.Eliminar(id_paciente);
            datosAnt.Eliminar(hclinica.Antecedente.Id_antecedente);
            datosPacien.Eliminar(pac.Id_paciente);
            datospers.Eliminar(cedula);

            ConsultarBBDHclinic();
            lblTotal.Text = listahClinica.Count + "";
        }

        public void Agregar(TextBox txtPresentar)
        {
            txtPresentar.Text += listahClinica[listahClinica.Count - 1].ToString();
        }


        public bool EsCorrecto(string cedula, string nombre, string sexo, string telefono, string correo, string discapacidad, string aPersonales, string aFamiliares, DateTime fechaNac, ErrorProvider errorProvider1, Button btnGuardar)
        {
            bool x = false;
            if (!string.IsNullOrEmpty(cedula) && !string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(sexo) &&
                !string.IsNullOrEmpty(telefono) && !string.IsNullOrEmpty(correo) && !string.IsNullOrEmpty(discapacidad) &&
                !string.IsNullOrEmpty(aPersonales) && !string.IsNullOrEmpty(aFamiliares) && fechaNac != null)
            {
                x = true;
            }
            if (x == false)
            {
                errorProvider1.SetError(btnGuardar, " No estan llenos todos los campos");
            }
            else
            {
                errorProvider1.Clear();
            }

            return x;
        }

        public bool CedulaUnica(string cedula)
        {
            bool x = false;
            Paciente pac = null;
            pac = datospers.consultarPersona(cedula);
            if (pac != null)
            {

                x = true;
                MessageBox.Show("Ingrese una cedula no repetida");
            }

            return x;
        }
    }
}
