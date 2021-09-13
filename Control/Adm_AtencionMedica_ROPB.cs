using Datos;
using iText.IO.Font.Constants;
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

namespace Control {
    public class Adm_AtencionMedica_ROPB {

        // Variables
        private static Adm_AtencionMedica_ROPB adm = null;
        List<AtencionMedica> listaAM = null;
        Validacion v = null;
        AtencionMedica am = null;
        PiezaDental pd = null;

        Cita c = null;
        List<string> listaNP = null;

        //private Conexion_ROPB con = new Conexion_ROPB ();
        Datos_AtencionMedica dam = new Datos_AtencionMedica ();
        DatosCitaHLBV dc = new DatosCitaHLBV ();
        Datos_PiezaDental dpd = new Datos_PiezaDental ();
        DatosPacienteVLRS dp = new DatosPacienteVLRS ();
        DatosOdontologoEGGM don = new DatosOdontologoEGGM ();
        DatosHistoriaClinicaVLRS dhc = new DatosHistoriaClinicaVLRS ();

        // Constructor: Adm_AtencionMedica_ROPB
        private Adm_AtencionMedica_ROPB () {
            listaAM = new List<AtencionMedica> ();
            v = new Validacion ();
        }

        public List<AtencionMedica> Lista { get => listaAM; set => listaAM = value; }   // Getter & Setter: listaAM
        public AtencionMedica Am { get => am; set => am = value; }                      // Getter & Setter: am

        // Getter :GetAdm
        public static Adm_AtencionMedica_ROPB GetAdm () {
            if (adm == null) {
                adm = new Adm_AtencionMedica_ROPB ();
            }
            return adm;
        }

        /*
         ---Frm_Menu-------------------------------------------------------------------------------------------------*/

        // Method: ListaContar
        public int ContarLista () {
            int x = -1;
            //x = Lista.Count;
            x = dam.CsultarCantidadAM ();
            return x;
        }

        public int ContarListaBuscar () {
            int x = -1;
            x = listaAM.Count ();
            return x;
        }

        // Method: Conectar
        public void Conectar () {
            Conexion con = new Conexion ();
            string mensaje = "";
            mensaje = con.Conectar ();
            if (mensaje [0] == '1') {
                MessageBox.Show ("Conexión sarisfactoria!");
            } else {
                MessageBox.Show ("Error " + mensaje);
            }
            con.Cerrar ();
        }

        /*
         ---Frm_AtencionMedica_Registrar-----------------------------------------------------------------------------*/

        // Method: LlenarComboHora
        public void LlenarComboHoraAutomatico (DateTimePicker dtp_Fecha, ComboBox cmb_Hora, int x) {
            List<DateTime> horas = new List<DateTime> ();
            cmb_Hora.Items.Clear ();
            cmb_Hora.Items.Add ("---Seleccione---");
            cmb_Hora.SelectedIndex = 0;
            DateTime fecha = DateTime.Now;
            if (x == 1) {   // 1: no todos
                fecha = dtp_Fecha.Value.Date;
            }
            horas = dc.ConsultarHorasCita (fecha, x);
            LlenarComboHora (horas, cmb_Hora);
        }

        // Method: LlenarComboHora
        public void LlenarComboHora (List<DateTime> horas, ComboBox cmb_Hora) {
            foreach (DateTime elemente in horas) {
                cmb_Hora.Items.Add (elemente.ToString ("HH:mm"));
            }
        }

        // Method: LlenarComboPacienteAutomatico
        public void LlenarComboPacienteAutomatico (DateTimePicker dtp_Fecha, ComboBox cmb_Hora, ComboBox cmb_Paciente, int x) {
            cmb_Paciente.Items.Clear ();
            cmb_Paciente.Items.Add ("---Seleccione---");
            cmb_Paciente.SelectedIndex = 0;
            DateTime fecha = DateTime.Now;
            DateTime hora = DateTime.Now;
            if (x == 1 && cmb_Hora.SelectedIndex != 0) { // 1: no todos
                fecha = dtp_Fecha.Value.Date;
                hora = DateTime.Parse (cmb_Hora.Text, System.Globalization.CultureInfo.CurrentCulture);
            }
            listaNP = dp.ConsultarNombres (fecha, hora, x);
            LlenarComboPaciente (listaNP, cmb_Paciente);
        }

        // Method: LlenarComboPaciente
        public void LlenarComboPaciente (List<string> listaNP, ComboBox cmb_Paciente) {
            foreach (string elemente in listaNP) {
                cmb_Paciente.Items.Add (elemente);
            }
        }

        // Method: LlenarOdontologo
        public void LlenarLabelOdontologo (DateTimePicker dtp_Fecha, ComboBox cmb_Hora, ComboBox cmb_Paciente, Label lbl_Odontologo) {
            string nombreOdontolog = "";
            if (dtp_Fecha != null && cmb_Hora.SelectedIndex != 0 && cmb_Paciente.SelectedIndex != 0) {
                DateTime fecha = dtp_Fecha.Value.Date;
                DateTime hora = DateTime.Parse (cmb_Hora.Text, System.Globalization.CultureInfo.CurrentCulture);
                string paciente = cmb_Paciente.Text;
                nombreOdontolog = don.ConsultarNombre (fecha, hora, paciente);
                lbl_Odontologo.Text = nombreOdontolog;
            } else if (cmb_Paciente.SelectedIndex != -1) {
                lbl_Odontologo.Text = "";
            }
        }

        // Method: LlenarComboCuadrante
        public void LlenarComboCuadrantePieza (ComboBox cmb_CuadrantePieza) {
            List<string> listaCPD = new List<string> ();
            listaCPD = dpd.ConsultarCuadrantePieza ();
            cmb_CuadrantePieza.Items.Add ("---Seleccione---");
            cmb_CuadrantePieza.SelectedIndex = 0;
            foreach (string element in listaCPD) {
                cmb_CuadrantePieza.Items.Add (element);
            }
        }

        // Method: LlenarComboNombreDiente
        public void LlenarComboNombrePieza (ComboBox cmb_NombrePieza) {
            List<string> listaNPD = new List<string> ();
            listaNPD = dpd.ConsultarNombrePieza ();
            cmb_NombrePieza.Items.Add ("---Seleccione---");
            cmb_NombrePieza.SelectedIndex = 0;
            foreach (string element in listaNPD) {
                cmb_NombrePieza.Items.Add (element);
            }
        }

        // Method: LlenarLabelNumeroPieza
        public void LlenarLabelNumeroPieza (ComboBox cmb_CuadrantePieza, ComboBox cmb_NombrePieza, Label lbl_NumeroPieza) {
            int numeroPieza = 0;
            if (cmb_CuadrantePieza.SelectedIndex != -1 && cmb_NombrePieza.SelectedIndex != -1) {
                string cuadrantePieza = cmb_CuadrantePieza.Text;
                string nombrePieza = cmb_NombrePieza.Text;
                numeroPieza = dpd.ConsultarNumeroPieza (cuadrantePieza, nombrePieza);
                lbl_NumeroPieza.Text = numeroPieza + "";
            }
        }

        // Method: Guardar
        public void Guardar (DateTimePicker dtp_Fecha, ComboBox cmb_Hora, ComboBox cmb_Paciente, ComboBox cmb_CuadrantePieza, ComboBox cmb_NombrePieza, TextBox txt_MotivoConsulta, TextBox txt_Diagnostico, ErrorProvider errorProvider1, TextBox txt_Registro, Label lbl_Odontologo, Label lbl_NumeroPieza, int n) {
            errorProvider1.Clear ();
            if (v.EsCorrectoGuardar (dtp_Fecha, cmb_Hora, cmb_Paciente, cmb_CuadrantePieza, cmb_NombrePieza, txt_MotivoConsulta, txt_Diagnostico, errorProvider1)) {
                DateTime fecha = dtp_Fecha.Value.Date;
                DateTime hora = DateTime.Parse (cmb_Hora.Text, System.Globalization.CultureInfo.CurrentCulture);
                string odontologo = lbl_Odontologo.Text, paciente = cmb_Paciente.Text, cuadrantePieza = cmb_CuadrantePieza.Text, nombrePieza = cmb_NombrePieza.Text, motivoConsulta = txt_MotivoConsulta.Text, diagnostico = txt_Diagnostico.Text;
                int numeroPieza = Convert.ToInt32 (lbl_NumeroPieza.Text);
                GuardarDatos (paciente, odontologo, fecha, hora, numeroPieza, cuadrantePieza, nombrePieza, motivoConsulta, diagnostico, txt_Registro);
                LimpiarGuardar (dtp_Fecha, cmb_Hora, cmb_Paciente, cmb_CuadrantePieza, cmb_NombrePieza, txt_MotivoConsulta, txt_Diagnostico, n);
            }
        }

        // Method: GuardarDatos
        private void GuardarDatos (string paciente, string odontologo, DateTime fecha, DateTime hora, int numeroPieza, string cuadrantePieza, string nombrePieza, string motivoConsulta, string diagnostico, TextBox txt_Registro) {
            am = dam.ConsultarAtencionMedicaEditar (fecha, hora.ToString ("HH:mm"), paciente);
            if (am.Cita.Paciente.Nombre != "") {
                MessageBox.Show ("Paciente ya fue atendido.", "ERROR!");
            } else {
                c = new Cita ();
                c.Paciente.Nombre = paciente;
                c.Odontologo.Nombre = odontologo;
                c.Fecha = fecha;
                c.Hora = hora;
                pd = new PiezaDental (numeroPieza, cuadrantePieza, nombrePieza);
                //pd.NumeroPieza = numeroPieza;
                //pd.CuadrantePieza = cuadrantePieza;
                //pd.NombrePieza = nombrePieza;
                am = new AtencionMedica (c, pd, motivoConsulta, diagnostico);
                listaAM.Add (am);
                string mensaje = dam.InsertarAteniconMedica (am);
                if (mensaje [0] == '1') {
                    AgregarMostrar (txt_Registro);
                    MessageBox.Show ("Datos guardados", "Nice.");
                } else {
                    MessageBox.Show ("Datos NO guardados", "Error!");
                }
            }
        }

        // Method: LimpiarGuardar
        private void LimpiarGuardar (DateTimePicker dtp_Fecha, ComboBox cmb_Hora, ComboBox cmb_Paciente, ComboBox cmb_CuadrantePieza, ComboBox cmb_NombrePieza, TextBox txt_MotivoConsulta, TextBox txt_Diagnostico, int n) {
            dtp_Fecha.Value = DateTime.Now;
            cmb_Hora.SelectedIndex = 0;
            LlenarComboPacienteAutomatico (dtp_Fecha, cmb_Hora, cmb_Paciente, n); // 2: ALL
            cmb_CuadrantePieza.SelectedIndex = 0;
            cmb_NombrePieza.SelectedIndex = 0;
            txt_MotivoConsulta.Text = "";
            txt_Diagnostico.Text = "";
        }

        // Mehod: AgregarMostrar
        public void AgregarMostrar (TextBox txt_Registro) {
            txt_Registro.Text = Lista [Lista.Count - 1].ToString () + "\r\n";
        }

        /*
         ---Frm_AtencionMedica_Buscar_ROPB-------------------------------------------------------------------------------------------------*/

        // Method: ListarAntencionMedica
        public void LlenarTablaAntencionMedica (DataGridView dgv_AntencionMedica, Label lbl_Total) {
            listaAM.Clear ();
            dgv_AntencionMedica.Rows.Clear ();
            listaAM = dam.ConsultarAntecionesMedicas ();
            int i = 0;
            foreach (AtencionMedica element in listaAM) {
                ++i;
                dgv_AntencionMedica.Rows.Add (i, dhc.ConsultarIdHistoriaClinica (element.Cita.Paciente.Nombre), element.Cita.Paciente.Nombre, element.Cita.Odontologo.Nombre, element.Cita.Odontologo.Consultorio, element.Cita.Fecha.ToString ("dd/MM/yyy"), element.Cita.Hora.ToString ("HH:mm"), element.PiezaDental.NumeroPieza, element.PiezaDental.CuadrantePieza, element.PiezaDental.NombrePieza, element.MotivoConsulta, element.Diagnostico);
            }
            lbl_Total.Text = i + "";
        }

        // Method: LlenarTablaAntencionMedicaBuscar
        public void LlenarTablaAntencionMedicaBuscar (DataGridView dgv_AntencionMedica, Label lbl_Total, ComboBox cmb_Paciente, DateTimePicker dtp_Fecha, ComboBox cmb_Hora, int n) {
            listaAM.Clear ();
            string paciente = cmb_Paciente.Text, hora = cmb_Hora.Text;
            DateTime fecha = dtp_Fecha.Value.Date;
            dgv_AntencionMedica.Rows.Clear ();
            listaAM = dam.ConsultarAntecionesMedicasBuscar (paciente, fecha, hora, n);
            int i = 0;
            foreach (AtencionMedica element in listaAM) {
                ++i;
                dgv_AntencionMedica.Rows.Add (i, dhc.ConsultarIdHistoriaClinica (element.Cita.Paciente.Nombre), element.Cita.Paciente.Nombre, element.Cita.Odontologo.Nombre, element.Cita.Odontologo.Consultorio, element.Cita.Fecha.ToString ("dd/MM/yyy"), element.Cita.Hora.ToString ("HH:mm"), element.PiezaDental.NumeroPieza, element.PiezaDental.CuadrantePieza, element.PiezaDental.NombrePieza, element.MotivoConsulta, element.Diagnostico);
            }
            lbl_Total.Text = i + "";
        }

        /*
         ---Frm_AtencionMedica_Editar_ROPB-------------------------------------------------------------------------------------------------*/

        // Method: LlenarDatosEditar
        public void LlenarDatosEditar (DateTimePicker dtp_Fecha, ComboBox cmb_Hora, ComboBox cmb_Paciente, ComboBox cmb_CuadrantePieza, ComboBox cmb_NombrePieza, TextBox txt_MotivoConsulta, TextBox txt_Diagnostico, ComboBox cmb_CuadrantePieza_Editar, ComboBox cmb_NombrePieza_Editar, TextBox txt_MotivoConsulta_Editar, TextBox txt_Diagnostico_Editar) {
            DateTime fecha = dtp_Fecha.Value;
            string hora = cmb_Hora.Text;
            string paciente = cmb_Paciente.Text;
            am = new AtencionMedica ();
            am = dam.ConsultarAtencionMedicaEditar (fecha, hora, paciente);
            if (hora == "---Seleccione---" || paciente == "---Seleccione---" || am.Diagnostico == "") {
                cmb_CuadrantePieza.Text = "---Seleccione---";
                cmb_NombrePieza.Text = "---Seleccione---";
                txt_MotivoConsulta.Text = "";
                txt_Diagnostico.Text = "";
                cmb_CuadrantePieza_Editar.Text = "---Seleccione---";
                cmb_NombrePieza_Editar.Text = "---Seleccione---";
                txt_MotivoConsulta_Editar.Text = "";
                txt_Diagnostico_Editar.Text = "";
            } else {
                cmb_CuadrantePieza.Text = am.PiezaDental.CuadrantePieza;
                cmb_NombrePieza.Text = am.PiezaDental.NombrePieza;
                txt_MotivoConsulta.Text = am.MotivoConsulta;
                txt_Diagnostico.Text = am.Diagnostico;
                cmb_CuadrantePieza_Editar.Text = am.PiezaDental.CuadrantePieza;
                cmb_NombrePieza_Editar.Text = am.PiezaDental.NombrePieza;
                txt_MotivoConsulta_Editar.Text = am.MotivoConsulta;
                txt_Diagnostico_Editar.Text = am.Diagnostico;
            }
        }

        // Method: GuardarEditar
        public bool GuardarEditar (DateTimePicker dtp_Fecha, ComboBox cmb_Hora, ComboBox cmb_Paciente, ComboBox cmb_CuadrantePieza, ComboBox cmb_NombrePieza, TextBox txt_MotivoConsulta, TextBox txt_Diagnostico, ComboBox cmb_CuadrantePieza_Editar, ComboBox cmb_NombrePieza_Editar, TextBox txt_MotivoConsulta_Editar, TextBox txt_Diagnostico_Editar, ErrorProvider errorProvider1, TextBox txt_Registro, Label lbl_Odontologo, Label lbl_NumeroPieza_Editar) {
            bool output = false;
            errorProvider1.Clear ();
            if (v.EsCorrectoGuardarEditar (cmb_CuadrantePieza, cmb_NombrePieza, txt_MotivoConsulta, txt_Diagnostico, cmb_CuadrantePieza_Editar, cmb_NombrePieza_Editar, txt_MotivoConsulta_Editar, txt_Diagnostico_Editar, errorProvider1)) {
                DateTime fecha = dtp_Fecha.Value;
                string hora = cmb_Hora.Text;
                string paciente = cmb_Paciente.Text;
                string numeroPieza = lbl_NumeroPieza_Editar.Text;
                string motivoConsulta = txt_MotivoConsulta_Editar.Text;
                string diagnostico = txt_Diagnostico_Editar.Text;
                output = GuardarEditarDatos (fecha, hora, paciente, numeroPieza, motivoConsulta, diagnostico, txt_Registro);
                LimpiarGuardarEditar (dtp_Fecha, cmb_Hora, cmb_Paciente, cmb_CuadrantePieza_Editar, cmb_NombrePieza_Editar, txt_MotivoConsulta_Editar, txt_Diagnostico_Editar);
            }
            return output;
        }

        // Method: LimpiarGuardarEditar
        private void LimpiarGuardarEditar (DateTimePicker dtp_Fecha, ComboBox cmb_Hora, ComboBox cmb_Paciente, ComboBox cmb_CuadrantePieza_Editar, ComboBox cmb_NombrePieza_Editar, TextBox txt_MotivoConsulta_Editar, TextBox txt_Diagnostico_Editar) {
            dtp_Fecha.Value = DateTime.Now;
            cmb_Hora.SelectedIndex = 0;
            cmb_Paciente.SelectedIndex = 0;
            cmb_CuadrantePieza_Editar.SelectedIndex = 0;
            cmb_NombrePieza_Editar.SelectedIndex = 0;
            txt_MotivoConsulta_Editar.Text = "";
            txt_Diagnostico_Editar.Text = "";
        }

        // Method: GuardarEditarDatos
        private bool GuardarEditarDatos (DateTime fecha, string hora, string paciente, string numeroPieza, string motivoConsulta, string diagnostico, TextBox txt_Registro) {
            bool output = false;
            int idCita = dc.CosultarIdCita (paciente, fecha, hora);
            string mensaje = dam.EditarAtencionMedica (idCita, numeroPieza, motivoConsulta, diagnostico);
            if (mensaje [0] == '1') {
                am = new AtencionMedica ();
                am = dam.ConsultarAtencionMedicaEditar (fecha, hora, paciente);
                txt_Registro.Text = am.ToString ();
                MessageBox.Show ("Datos actualizados", "Nice.");
                output = true;
            } else {
                MessageBox.Show ("Datos NO actualizados", "ERROR!");
            }
            return output;
        }

        /*
         ---Frm_AtencionMedica_Eliminar_ROPB-------------------------------------------------------------------------------------------------*/

        // Method: LlenarDatosEliminar
        public void LlenarDatosEliminar (DateTimePicker dtp_Fecha, ComboBox cmb_Hora, ComboBox cmb_Paciente, ComboBox cmb_CuadrantePieza, ComboBox cmb_NombrePieza, TextBox txt_MotivoConsulta, TextBox txt_Diagnostico) {
            DateTime fecha = dtp_Fecha.Value;
            string hora = cmb_Hora.Text;
            string paciente = cmb_Paciente.Text;
            am = new AtencionMedica ();
            am = dam.ConsultarAtencionMedicaEditar (fecha, hora, paciente);
            if (hora == "---Seleccione---" || paciente == "---Seleccione---" || am.Diagnostico == "") {
                cmb_CuadrantePieza.Text = "---Seleccione---";
                cmb_NombrePieza.Text = "---Seleccione---";
                txt_MotivoConsulta.Text = "";
                txt_Diagnostico.Text = "";
            } else {
                cmb_CuadrantePieza.Text = am.PiezaDental.CuadrantePieza;
                cmb_NombrePieza.Text = am.PiezaDental.NombrePieza;
                txt_MotivoConsulta.Text = am.MotivoConsulta;
                txt_Diagnostico.Text = am.Diagnostico;
            }
        }

        // Method: Eliminar
        public bool Eliminar (DateTimePicker dtp_Fecha, ComboBox cmb_Hora, ComboBox cmb_Paciente, ComboBox cmb_CuadrantePieza, ComboBox cmb_NombrePieza, TextBox txt_MotivoConsulta, TextBox txt_Diagnostico) {
            bool output = false;
            if (v.EsCorrectoEliminar (cmb_CuadrantePieza, cmb_NombrePieza, txt_MotivoConsulta, txt_Diagnostico)) {
                DateTime fecha = dtp_Fecha.Value;
                string hora = cmb_Hora.Text;
                string paciente = cmb_Paciente.Text;
                DialogResult dialogResult = MessageBox.Show ("Esta acción es irrevercible.\n¿Desea continuar?", "¡ADVERTENCIA!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) {
                    Console.WriteLine ("------------- pasó");
                    EliminarDatos (fecha, hora, paciente);
                    LimpiarEliminar (dtp_Fecha, cmb_Hora, cmb_Paciente);
                    output = true;
                }
            }
            return output;
        }

        // Method: EliminarDatos
        private void EliminarDatos (DateTime fecha, string hora, string paciente) {
            int idCita = dc.CosultarIdCita (paciente, fecha, hora);
            int idAM = dam.ConsultarIdAtencionMedica (idCita);
            string mensaje = dam.EliminarAtencionMedica (idAM);
            if (mensaje [0] == '1') {
                MessageBox.Show ("Datos eliminados correctamente.", "Nice.");
            } else {
                MessageBox.Show ("Datos NO fueron eliminados.", "ERROR!");
            }
        }

        // Mehod: LimpiarEliminar
        private void LimpiarEliminar (DateTimePicker dtp_Fecha, ComboBox cmb_Hora, ComboBox cmb_Paciente) {
            dtp_Fecha.Value = DateTime.Now;
            cmb_Hora.SelectedIndex = 0;
            cmb_Paciente.SelectedIndex = 0;
        }

        /*
         ---Frm_AtencionMedica_Reporte_ROPB-------------------------------------------------------------------------------------------------*/

        // Method: CrearReportePDF
        public void CrearReportePDF (ComboBox cmb_Paciente, DateTimePicker dtp_Fecha, ComboBox cmb_Hora, int n) { // it Works!
            listaAM.Clear ();
            string paciente = cmb_Paciente.Text, hora = cmb_Hora.Text;
            DateTime fecha = dtp_Fecha.Value.Date;//------------------------------------------

            string pdfNombre = "Reporte_AtencionMedica.pdf";

            // SaveFileDialog
            SaveFileDialog sfd = new SaveFileDialog ();
            sfd.Filter = "Pdf File |*.pdf";
            sfd.InitialDirectory = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments); // Se abre escritori por defecto
            sfd.Title = "Dentalig: Atención Médica - Guardar";
            DialogResult dr = sfd.ShowDialog ();
            if (dr == DialogResult.OK) {
                string folder = sfd.FileName; // Dirección a guardar pdf
                //PdfWriter pdfWriter = new PdfWriter ("Reporte_AtencionMedica.pdf");  // seleccionar donde guardar ¿?
                PdfWriter pdfWriter = new PdfWriter (folder);  // seleccionar donde guardar ¿?
                PdfDocument pdfDocument = new PdfDocument (pdfWriter);
                Document document = new Document (pdfDocument, PageSize.A4.Rotate ()); // Tamño y orientación del pdf
                document.SetMargins ((float)15, (float)2.54, (float)2.54, (float)2.54); // Margenes del pdf
                PdfFont fontColumnas = PdfFontFactory.CreateFont (StandardFonts.HELVETICA_BOLD); // Tipo de letra Titulo de columnas
                PdfFont fontContenido = PdfFontFactory.CreateFont (StandardFonts.HELVETICA);    // Tipo de letra contenido
                var titulo = new Paragraph ("Reporte de Atenciones Médicas");
                titulo.SetTextAlignment (TextAlignment.CENTER);
                titulo.SetFontSize (12);
                string [] columnas = { "#", "#HistoriaClínica", "Paciente", "Odontólogo", "Consultorio", "Fecha", "Hora", "#Pieza", "CuadrantePieza", "NombrePieza", "MotivoConsulta", "Diagnóstico" };
                float [] espacio = { 1, 4, 4, 4, 4, 2, 2, 2, 4, 4, 4, 4 };
                Table tabla = new Table (UnitValue.CreatePercentArray (espacio));
                tabla.SetWidth (UnitValue.CreatePercentValue (100));

                document.Add (titulo.SetFont (fontColumnas));
                foreach (string element in columnas) {
                    tabla.AddHeaderCell (new Cell ().Add (new Paragraph (element).SetFont (fontColumnas)));
                }
                listaAM = dam.BuscarAtencionMedicaReporte (paciente, fecha, hora, n);
                int i = 0;
                foreach (AtencionMedica element in listaAM) {
                    ++i;
                    tabla.AddCell (new Cell ().Add (new Paragraph (i + "").SetFont (fontContenido))); // #
                    tabla.AddCell (new Cell ().Add (new Paragraph (dhc.ConsultarIdHistoriaClinica (element.Cita.Paciente.Nombre) + "").SetFont (fontContenido)));   // #HistoriaClínica
                    tabla.AddCell (new Cell ().Add (new Paragraph (element.Cita.Paciente.Nombre).SetFont (fontContenido)));
                    tabla.AddCell (new Cell ().Add (new Paragraph (element.Cita.Odontologo.Nombre).SetFont (fontContenido)));
                    tabla.AddCell (new Cell ().Add (new Paragraph (element.Cita.Odontologo.Consultorio + "").SetFont (fontContenido)));
                    tabla.AddCell (new Cell ().Add (new Paragraph (element.Cita.Fecha.ToString ("dd/MM/yyy")).SetFont (fontContenido)));
                    tabla.AddCell (new Cell ().Add (new Paragraph (element.Cita.Hora.ToString ("HH:mm")).SetFont (fontContenido)));
                    tabla.AddCell (new Cell ().Add (new Paragraph (element.PiezaDental.NumeroPieza + "").SetFont (fontContenido)));
                    tabla.AddCell (new Cell ().Add (new Paragraph (element.PiezaDental.CuadrantePieza).SetFont (fontContenido)));
                    tabla.AddCell (new Cell ().Add (new Paragraph (element.PiezaDental.NombrePieza).SetFont (fontContenido)));
                    tabla.AddCell (new Cell ().Add (new Paragraph (element.MotivoConsulta).SetFont (fontContenido)));
                    tabla.AddCell (new Cell ().Add (new Paragraph (element.Diagnostico).SetFont (fontContenido)));
                }
                document.Add (tabla);
                document.Close ();


                //var dfecha = DateTime.Now.ToString ("dd/MM/yyyy");
                //var dhora = DateTime.Now.ToString ("HH:mm:ss");

                Console.WriteLine ("---!!!");
            }
        }

    }
}
