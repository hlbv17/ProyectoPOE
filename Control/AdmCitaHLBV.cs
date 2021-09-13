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
using System.Windows.Forms;

namespace Control
{
    public class AdmCitaHLBV
    {
        private ConexionHLBV con = new ConexionHLBV();
        private static AdmCitaHLBV adm = new AdmCitaHLBV();
        DatosCitaHLBV dCita = new DatosCitaHLBV();
        DatosPacienteVLRS dPaciente = new DatosPacienteVLRS();
        DatosOdontologoEGGM dOdontologo = new DatosOdontologoEGGM();

        List<Cita> citas = null;
        //Validacion val = null;
        Cita c = null;
        Paciente pa = null;
        Odontologo o = null;

        public Cita C { get => c; set => c = value; }
        public List<Cita> Citas { get => citas; set => citas = value; }
        public Paciente Pa { get => pa; set => pa = value; }
        public Odontologo O { get => o; set => o = value; }

        public int TotalElementos()
        {
            return Citas.Count;
        }

        public AdmCitaHLBV()
        {
            citas = new List<Cita>();
            //val = new Validacion();
        }

        public static AdmCitaHLBV GetAdm()
        {
            if (adm == null)
            {
                adm = new AdmCitaHLBV();
            }
            return adm;
        }

        public void Conectar()
        {
            string mensaje = "";
            mensaje = con.Conectar();
            if (mensaje[0] == '1')
            {
                MessageBox.Show("Conexión exitosa");
            }
            else
            {
                MessageBox.Show("Error: " + mensaje);
            }
            con.Cerrar();
        }

        public void LlenarComboH(ComboBox cmbHora)
        {
            cmbHora.Items.Add("--Seleccionar--");
            cmbHora.Items.Add("07:00");
            cmbHora.Items.Add("09:00");
            cmbHora.Items.Add("10:00");
            cmbHora.Items.Add("11:00");
            cmbHora.Items.Add("12:00");
            cmbHora.Items.Add("13:00");
            cmbHora.Items.Add("14:00");
            cmbHora.Items.Add("15:00");
            cmbHora.Items.Add("16:00");
        }

        //----------------REGISTRAR CITAS------------------------------
        public bool Validar(TextBox txtCedula, ComboBox cmbHora, DateTimePicker dtpFecha, ComboBox cmbOdontologo, ErrorProvider errorP)
        {
            bool no_error = true;
            string cedula = txtCedula.Text;
            if (String.IsNullOrEmpty(txtCedula.Text.Trim()))
            {
                errorP.SetError(txtCedula, "Ingrese una cédula");
                no_error = false;
            }
            if (cedula.Length < 10 || dPaciente.ConsultarPacienteCedula(txtCedula.Text))
            {
                errorP.SetError(txtCedula, "Esa cédula no está registrada\nLa cédula debe ser de 10 dígitos");
                no_error = false;
            }
            if (dtpFecha.Value.Date < DateTime.Now)
            {
                errorP.SetError(dtpFecha, "Debe escoger una fecha posterior al día de hoy " + DateTime.Now);
                no_error = false;
            }
            if (cmbHora.Text == "--Seleccionar--")
            {
                errorP.SetError(cmbHora, "Seleccione una hora");
                no_error = false;
            }
            if (cmbOdontologo.Text == "--Seleccionar--")
            {
                errorP.SetError(cmbOdontologo, "Seleccione un odontólogo");
                no_error = false;
            }
            return no_error;
        }

        public void Guardar(int id_cita, string cedula, string odonto, DateTime fecha, DateTime hora)
        {
            Cita c = null;
            Paciente pa = null;
            Odontologo o = null;
            if (dCita.ConsultarCitasExistentes(cedula, fecha, hora) == false)
            {
                pa = dPaciente.ConsultarPacienteNombre(cedula);
                o = dOdontologo.ConsultarOdontologo(odonto);
                c = new Cita(id_cita, fecha, hora, o, pa);
                citas.Add(c);
                GuardarBD(c);
            }
            else
            {
                MessageBox.Show("La cita ya existe");
            }

        }

        public void GuardarBD(Cita cita)
        {
            string mensaje = "";
            mensaje = dCita.insertarCita(cita);
            if (mensaje[0] == '1')
                MessageBox.Show("Ingreso de datos correctamente");
            else
                MessageBox.Show("Error: " + mensaje);
        }


        public void Agregar(TextBox txtRegistro)
        {
            if (citas.Count != 0)
                txtRegistro.Text += Citas[Citas.Count - 1].ToString() + "\r\n";
        }

        public void LimpiarCamposR(TextBox txtCedula, Label lblNombre, DateTimePicker dtpFecha,
            ComboBox cmbHora, ComboBox cmbOdontologo, Label lblConsultorio, TextBox txtRegistro)
        {
            txtCedula.Text = "";
            cmbHora.SelectedIndex = 0;
            cmbOdontologo.Items.Clear();
            cmbOdontologo.Items.Add("--Seleccionar--");
            cmbOdontologo.SelectedIndex = 0;
            cmbOdontologo.Enabled = false;
            dtpFecha.Value = DateTime.Now;
            lblNombre.Text = "____________________";
            lblConsultorio.Text = "___";
            txtRegistro.Text = "";
        }

        //----------------------------LISTAR CITAS--------------------------------------------------

        public void LlenarTabla(DataGridView dgvCitas)
        {
            int i = 1;
            citas.Clear();
            Citas = dCita.ListarCitas();
            foreach (Cita c in citas)
            {
                dgvCitas.Rows.Add(i, c.Id_cita, c.Paciente.Cedula, c.Paciente.Nombre, c.Fecha.ToString("yyyy-MM-dd"),
                    c.Hora.ToString("HH:mm"), c.Odontologo.Nombre, c.Odontologo.Consultorio);
                i++;
            }

        }

        //---------------------------------FILTRAR CITAS------------------------------------------------------
        public void FiltrarDatos(DataGridView dgvCitas, string cedula, DateTime fecha, string hora, int n, Button btnImprimir)
        {
            citas.Clear();
            int i = 1;
            citas = dCita.ConsultarCitas(cedula, fecha, hora, n);
            dgvCitas.Rows.Clear();
            if (citas.Count != 0)
            {
                foreach (Cita c in citas)
                {
                    dgvCitas.Rows.Add(i, c.Id_cita, c.Paciente.Cedula, c.Paciente.Nombre,
                        c.Fecha.ToString("yyyy-MM-dd"), c.Hora.ToString("HH:mm"), c.Odontologo.Nombre,
                        c.Odontologo.Consultorio);
                    i++;
                }

                btnImprimir.Enabled = true;
            }
            else
            {
                MessageBox.Show("No existen citas con esos datos");
                btnImprimir.Enabled = false;
            }
        }

        public void LimpiarCampos(TextBox txtCedula, DataGridView dgvCitas, DateTimePicker dtpFecha,
            ComboBox cmbHora, Button btnImprimir)
        {
            txtCedula.Text = "";
            cmbHora.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Now;
            dgvCitas.Rows.Clear();
            btnImprimir.Enabled = false;
        }

        //---------------------------------ELIMINAR CITAS-------------------------------------------------
        public void FiltrarDatos(DataGridView dgvCitas, DateTime fecha)
        {
            citas.Clear();
            int i = 1;
            citas = dCita.ConsultarCitasF(fecha);
            dgvCitas.Rows.Clear();
            foreach (Cita c in citas)
            {
                dgvCitas.Rows.Add(i, c.Id_cita, c.Paciente.Nombre, c.Fecha.ToString("yyyy-MM-dd"),
                    c.Hora.ToString("HH:mm"), c.Odontologo.Nombre, c.Odontologo.Consultorio);
                i++;
            }
        }

        public void EliminarCita(DataGridView dgvCitas, int posicion)
        {

            int indice = 0, id = Convert.ToInt32(dgvCitas.Rows[posicion].Cells["col_id"].Value);
            dgvCitas.Rows.RemoveAt(posicion);
            dCita.EliminarCitas(id);
            indice = citas.FindIndex(x => x.Id_cita == id);
            citas.RemoveAt(indice);
        }

        //-----------------------------------EDITAR CITAS------------------------------------------------
        public void BuscarDatos(DataGridView dgvCitas, string cedula, TextBox txtCedula, DateTimePicker dtpFecha,
            ComboBox cmbHora, ComboBox cmbOdontologo)
        {
            int i = 1;
            citas.Clear();
            citas = dCita.ConsultarCitasxCedula(cedula);
            dgvCitas.Rows.Clear();
            if (citas.Count != 0)
            {
                foreach (Cita c in citas)
                {
                    dgvCitas.Rows.Add(i, c.Id_cita, c.Paciente.Cedula, c.Paciente.Nombre, c.Fecha.ToString("yyyy-MM-dd"),
                        c.Hora.ToString("HH:ss"), c.Odontologo.Nombre, c.Odontologo.Consultorio);
                    i++;
                }
                DesbloquearCampos(txtCedula, dtpFecha, cmbHora, cmbOdontologo);
            }
            else
            {
                MessageBox.Show("No existe esa cédula");
            }

        }

        public void ActualizarDatos(int posicion, int id, Label lblID, TextBox txtCedula, Label lblPaciente, DateTimePicker dtpFecha,
            ComboBox cmbHora, ComboBox cmbOdontologo, Label lblConsultorio)
        {
            if (posicion >= 0)
            {
                foreach (Cita c in citas)
                {
                    if (c.Id_cita.CompareTo(id) == 0)
                    {
                        lblID.Text = c.Id_cita.ToString();
                        txtCedula.Text = c.Paciente.Cedula.ToString();
                        lblPaciente.Text = c.Paciente.Nombre.ToString();
                        dtpFecha.Value = c.Fecha;
                        cmbHora.Items.Clear();
                        LlenarComboH(cmbHora);
                        cmbHora.SelectedItem = c.Hora.ToString("HH:mm");
                        //cmbOdontologo.Items.Clear();
                        cmbOdontologo.SelectedItem = c.Odontologo.Nombre.ToString();
                        lblConsultorio.Text = c.Odontologo.Consultorio.ToString();
                    }

                }
            }
        }

        public void Editar(int id, string cedula, string odonto, DateTime fecha, DateTime hora, TextBox txtRegistro)
        {
            int indice = 0;
            //CitaHLBV c = null;
            Paciente pa = null;
            Odontologo o = null;
            indice = citas.FindIndex(x => x.Id_cita == id);
            c = citas[indice];
            c.Id_cita = c.Id_cita;
            pa = dPaciente.ConsultarPacienteNombre(cedula);
            c.Paciente = pa;
            o = dOdontologo.ConsultarOdontologo(odonto);
            c.Odontologo = o;
            c.Fecha = fecha;
            c.Hora = hora;
            UpdateBD(c);
            AgregarE(indice, txtRegistro);
        }

        public void UpdateBD(Cita c)
        {
            string mensaje = "";
            mensaje = dCita.EditarCitas(c);
            if (mensaje[0] == '1')
                MessageBox.Show("Ingreso de datos correctamente");
            else
                MessageBox.Show("Error: " + mensaje);
        }

        public void AgregarE(int indice, TextBox txtRegistro)
        {
            if (citas.Count != 0)
                txtRegistro.Text += Citas[indice].ToString() + "\r\n";
        }

        public void LimpiarCampos(TextBox txtCedula, Label lblNombre, DataGridView dgvCitas, DateTimePicker dtpFecha,
            ComboBox cmbHora, ComboBox cmbOdontologo, Label lblConsultorio, TextBox txtRegistro)
        {
            lblNombre.Text = "";
            txtCedula.Text = "";
            cmbHora.Text = "";
            cmbOdontologo.Text = "";
            lblConsultorio.Text = "";
            dtpFecha.Value = DateTime.Now;
            dgvCitas.Rows.Clear();
            BloquearCampos(txtCedula, dtpFecha, cmbHora, cmbOdontologo);
            txtRegistro.Text = "";
        }

        public void BloquearCampos(TextBox txtCedula, DateTimePicker dtpFecha, ComboBox cmbHora,
            ComboBox cmbOdontologo)
        {
            txtCedula.Enabled = true;
            dtpFecha.Enabled = false;
            cmbHora.Enabled = false;
            cmbOdontologo.Enabled = false;
        }

        public void DesbloquearCampos(TextBox txtCedula, DateTimePicker dtpFecha, ComboBox cmbHora,
            ComboBox cmbOdontologo)
        {
            txtCedula.Enabled = false;
            dtpFecha.Enabled = true;
            cmbHora.Enabled = true;
            cmbOdontologo.Enabled = true;
        }

        //-----------------------------IMPRIMIR CITAS-------------------------------------
        public void CrearPdf(string cedula, DateTime fecha, string hora, int n, string file)
        {
            PdfWriter pdfWriter = new PdfWriter(file);
            PdfDocument pdf = new PdfDocument(pdfWriter);
            Document documento = new Document(pdf, PageSize.LETTER);

            documento.SetMargins(60, 20, 55, 20);
            PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            string[] columnas = { "Nº", "Cédula", "Paciente", "Odontólogo", "Fecha", "Hora", "Consultorio" };
            float[] tamanios = { 2, 4, 4, 4, 4, 3, 2 };

            Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (string columna in columnas)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontColumnas)));
            }
            citas = dCita.ConsultarCitas(cedula, fecha, hora, n);
            int i = 1;
            foreach (Cita c in citas)
            {
                tabla.AddCell(new Cell().Add(new Paragraph(i + "").SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(c.Paciente.Cedula).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(c.Paciente.Nombre).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(c.Odontologo.Nombre).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(c.Fecha.ToString("yyyy-MM-dd")).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(c.Hora.ToString("HH:mm")).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(c.Odontologo.Consultorio + "").SetFont(fontContenido)));
                i++;
            }
            documento.Add(tabla);
            documento.Close();
        }

    }
}
