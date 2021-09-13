using Datos;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
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
        DatosCitaHLBV datosCita = new DatosCitaHLBV();
        Datos_AtencionMedica_ROPB datosAtmed = new Datos_AtencionMedica_ROPB();
        ValidacionesVLRS v = new ValidacionesVLRS();

        Persona persona = null;
        Paciente paciente = null;
        Antecedente antecedente = null;
        HistoriaClinica hisclinic = null;


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


        public Conexion con = new Conexion();
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

        public void ConsultarBBDXsexoXCedulaXFechas(string sexo, string cedula, DateTime fechaDesde, DateTime fechasta, DataGridView dgvPacientes, Label lblTotal, int index, int rbindex)
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

            Paciente pac = datosPacien.consultarPersonaPac(paciente.Cedula);
            mensaje = datospers.Actualizar(paciente, pac.Cedula);//
            mensaje2 = datosPacien.Actualizar(paciente, pac.Id_persona);

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

            int Iid_Clinica = (int)hclinica.Id_hclinica;
            int id_AteMedica = datosAtmed.ConsultarAtencionMedicaHiscL(Iid_Clinica);
            datosAtmed.EliminarAtencionMedica(id_AteMedica);

            Cita cita = datosCita.ConsultarCitaxCedula(pac.Cedula);
            datosCita.EliminarCitas(cita.Id_cita);

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

        public void ReporteiText(char csexo, string cedula, DateTime fechaDesde, DateTime fechaHasta, int index, int rbindex)
        {
            listahClinica.Clear();
            PdfWriter pdfWriter = new PdfWriter("Reporte_Historia_Clinica.pdf");
            PdfDocument pdfDocument = new PdfDocument(pdfWriter);
            Document document = new Document(pdfDocument, PageSize.A4.Rotate());
            document.SetMargins((float)2.54, (float)2.54, (float)2.54, (float)2.54);

            var titulo = new Paragraph("Reporte de Historia Clinica");
            titulo.SetTextAlignment(TextAlignment.CENTER);
            titulo.SetFontSize(16);
            titulo.SetFontColor(ColorConstants.BLACK);
            titulo.SetBold();


            var dfecha = DateTime.Now.ToString("dd-MM-yyyy");
            var dhora = DateTime.Now.ToString("hh:mm");
            var fecha = new Paragraph("Fecha: " + dfecha + "\n" + "Hora: " + dhora);
            fecha.SetBold();
            fecha.SetFontSize(12);



            PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            string[] columnas = { "HistClin", "Cedula", "Nombres", "Sexo", "F. Nacimiento", "Discapacidad", "Etapa_Edad", "Ant.Personales", "Ant.Familiares", "N° Atenc.Medi" };
            float[] espacio = { 1, 4, 4, 4, 4, 4, 4, 4, 4, 4 }; //revisar con nuemero de columnas?
            Table tabla = new Table(UnitValue.CreatePercentArray(espacio));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (string element in columnas)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(element).SetFont(fontColumnas)));
            }

            listahClinica = datosHistClin.ConsultarXsexoXCedulaXFechas(csexo, cedula, fechaDesde, fechaHasta, index, rbindex);

            int i = 0;
            foreach (HistoriaClinica element in listahClinica)
            {
                ++i;

                tabla.AddCell(new Cell().Add(new Paragraph(element.Id_hclinica.ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(element.Paciente.Cedula).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(element.Paciente.Nombre).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(element.Paciente.LeerSexo()).SetFont(fontContenido)));//mirar bien
                tabla.AddCell(new Cell().Add(new Paragraph(element.Paciente.FechaNacimiento.ToString("dd/MM/yyyy")).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(element.Paciente.Discapacidad).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(element.Paciente.Etapa).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(element.Antecedente.Antecedenteper).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(element.Antecedente.AntecedenteFam).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(element.AtencionMedica.Count().ToString()).SetFont(fontContenido)));
            }
            document.Add(fecha);
            document.Add(titulo);
            document.Add(tabla);
            document.Close();

            if (document != null)
                MessageBox.Show("Reporte generado con exito :)\n\n El reporte se encuentra en la carpeta del proyecto actual: /ProyectoPOE/VISUAL/bin/Debug");
            else
            {
                MessageBox.Show("Error al generar reporte");
            }
        }


        public void LlenarFormulario(string cedula, TextBox txtNombre, TextBox txtNombreact, ComboBox cmbSexo, ComboBox cmbSexoAct, DateTimePicker dtpFNacimiento, DateTimePicker dtpFnaciAct, TextBox txtTelefono, TextBox txtTelefonoAct, TextBox txtCorreo, TextBox txtCorreoAct, ComboBox cmbDiscapacidad, ComboBox cmbDiscAct, TextBox txtAntecPers, TextBox txtAntPersAct, TextBox txtAntecFam, TextBox txtAntFamAct, TextBox txtCedulaAct, TextBox txtCedula)
        {
            txtCedula.Text = cedula.ToString();
            if (!String.IsNullOrEmpty(cedula))
                hisclinic = datosHistClin.ConsultarXCedula(cedula);
            if (hisclinic != null)
            {
                //formulario para visualizar datos
                txtNombre.Text = hisclinic.Paciente.Nombre;
                cmbSexo.Text = hisclinic.Paciente.LeerSexo();
                dtpFNacimiento.Value = hisclinic.Paciente.FechaNacimiento;
                txtTelefono.Text = hisclinic.Paciente.Telefono;
                txtCorreo.Text = hisclinic.Paciente.Correo;
                cmbDiscapacidad.Text = hisclinic.Paciente.Discapacidad;
                txtAntecPers.Text = hisclinic.Antecedente.Antecedenteper;
                txtAntecFam.Text = hisclinic.Antecedente.AntecedenteFam;

                //formulario para cambiar los datos
                txtCedulaAct.Text = hisclinic.Paciente.Cedula;
                txtNombreact.Text = hisclinic.Paciente.Nombre;
                cmbSexoAct.Text = hisclinic.Paciente.LeerSexo();
                dtpFnaciAct.Value = hisclinic.Paciente.FechaNacimiento;
                txtTelefonoAct.Text = hisclinic.Paciente.Telefono;
                txtCorreoAct.Text = hisclinic.Paciente.Correo;
                cmbDiscAct.Text = hisclinic.Paciente.Discapacidad;
                txtAntPersAct.Text = hisclinic.Antecedente.Antecedenteper;
                txtAntFamAct.Text = hisclinic.Antecedente.AntecedenteFam;

            }
            else
            {
                MessageBox.Show("No existe Historia Clinica con la cedula registrada asociada");
            }
        }
    }
}
