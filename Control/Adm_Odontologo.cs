using Datos;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Control {
    public class Adm_Odontologo {

        List<Odontologo> odontologos = new List<Odontologo> ();
        private static Adm_Odontologo admO = new Adm_Odontologo ();
        Datos_Odontologo datosOdonto = new Datos_Odontologo ();
        Adm_Horario admhorario = Adm_Horario.GetAdm ();
        public Odontologo odontologo = null;
        Datos_Odontologo datosOdon = new Datos_Odontologo ();

        List<Odontologo> odontologosF = new List<Odontologo> ();
        Datos_Odontologo datosodo = new Datos_Odontologo ();
        public List<Odontologo> odontologosR = new List<Odontologo> ();

        //Validacion val = null;

        public List<Odontologo> Odontologos { get => odontologos; set => odontologos = value; }
        public Odontologo Odontologo { get => odontologo; set => odontologo = value; }

        public Adm_Odontologo () {
            odontologos = new List<Odontologo> ();
            //val = new Validacion();
        }

        public static Adm_Odontologo GetAdm () {
            if (admO == null) {
                admO = new Adm_Odontologo ();
            }
            return admO;
        }

        public void ConsultarOdontologos (DateTime fecha, DateTime hora, ComboBox cmbHora, ComboBox cmbOdontologo) {
            string dia = DayOfWeek (fecha);
            if (cmbHora.Text != "--Seleccionar--") {
                cmbOdontologo.Items.Add ("--Seleccionar--");
                cmbOdontologo.SelectedIndex = 0;
                odontologos = datosOdonto.ConsultarOdontologos (dia, hora);
                foreach (Odontologo x in odontologos) {
                    cmbOdontologo.Items.Add (x.Nombre);
                }
            }

            if (odontologos == null) {
                MessageBox.Show ("No existe un odontologo disponible");
            }
        }

        public string DayOfWeek (DateTime? date) {
            return date.Value.ToString ("dddd", new CultureInfo ("Es-Es"));
        }

        public void llenarComboO (DateTime fecha, DateTime hora, ComboBox cmbHora, ComboBox cmbOdontologo) {
            ConsultarOdontologos (fecha, hora, cmbHora, cmbOdontologo);
        }

        public void LabelConsultorio (string nombre, ComboBox cmbOdontologo, Label lblConsultorio) {
            int indice = 0, label = 0;

            indice = odontologos.FindIndex (x => x.Nombre == nombre);
            if (indice >= 0) {
                label = odontologos [indice].Consultorio;
                lblConsultorio.Text = label.ToString ();

            }

        }

        public void consultarOdo (string cedula, TextBox txtNombre, TextBox txtCorreo, TextBox txttelfono) {
            if (!String.IsNullOrEmpty (cedula))
                odontologo = datosOdon.ConsultarPersonaOdont (cedula);
            if (odontologo.Nombre != "") {
                MessageBox.Show ("Existe odontologo con esta cedula sus datos son los siguientes " + cedula + " " + odontologo.Nombre);

            } else {
                txtNombre.Text = " ";
                MessageBox.Show ("No existe un odontologo con la cedula registrada");
            }
        }

        public string Actualizar (int posicion) {
            //dvgOdontologo.Rows.RemoveAt(posicion);
            int id = odontologos [posicion].Id_Odontologo;
            string cedula = odontologos [posicion].Cedula;


            odontologo = datosOdon.ConsultarPersonaOdont (cedula);

            MessageBox.Show (cedula);

            return cedula;
        }

        public void consultarOdoParaActualizar (string cedula, TextBox txtCedula, TextBox txtNombre, TextBox txtCorreo, TextBox txttelfono, ComboBox cmbConsultorio, ComboBox cmbEspecialidad, ComboBox cmbSexo, DateTimePicker dateTimePicker1, DataGridView dgvHorarioOdontologo, Label idodo) {
            if (!String.IsNullOrEmpty (cedula))
                odontologo = datosOdon.ConsultarPersonaOdont (cedula);
            if (odontologo != null) {
                txtCedula.Text = odontologo.Cedula;

                txtNombre.Text = odontologo.Nombre;
                txtCorreo.Text = odontologo.Correo;
                txttelfono.Text = odontologo.Telefono;
                txtNombre.ReadOnly = false;
                txttelfono.ReadOnly = false;
                txtCorreo.ReadOnly = false;
                int c;
                string espe = odontologo.Especialidad;
                char se = odontologo.Sexo;
                c = odontologo.Consultorio;
                cmbConsultorio.SelectedIndex = c - 1;
                if (espe == "Peridoncia") {
                    cmbEspecialidad.SelectedIndex = 1;
                } else if (espe == "Ortodoncia") {
                    cmbEspecialidad.SelectedIndex = 0;
                } else if (espe == "Endodoncia") {
                    cmbEspecialidad.SelectedIndex = 2;
                }
                if (se == 'F') {
                    cmbSexo.SelectedIndex = 0;
                } else {
                    cmbSexo.SelectedIndex = 1;
                }

                dateTimePicker1.Value = odontologo.FechaNacimiento;

                string horario = odontologo.Horario.Tipo;
                Console.WriteLine (horario);
                admhorario.LlenarGridHorarioAc (dgvHorarioOdontologo, horario);
                idodo.Text = Convert.ToString (odontologo.Id_Odontologo);





            } else {
                txtNombre.Text = " ";
                MessageBox.Show ("No existe un odontologo con la cedula registrada");
            }
        }
        //public void guardar(int id_Odontologo, string nombre, string cedula, string especialidad, char sexo, DateTime fechaNacimiento, string correo, string telefono, int consultorio)
        //{
        //    Odontologo od = null;
        //    od = new Odontologo(id_Odontologo, nombre, cedula, especialidad, sexo, fechaNacimiento, correo, telefono, consultorio);
        //    odontologos.Add(od);
        //    // guardarDBB(od);
        //}

        public void guardarActualizar (int id_Odontologo, string nombre, string cedula, string especialidad, char sexo, DateTime fechaNacimiento, string correo, string telefono, int consultorio, Horario e) {
            Odontologo od = null;
            int hora = 0, espe = 0;
            od = new Odontologo (id_Odontologo, especialidad, consultorio, e, cedula, sexo, nombre, fechaNacimiento, telefono, correo);

            if (especialidad == "Ortodoncia") {
                espe = 1;
            } else if (especialidad == "Peridoncia") {
                espe = 2;
            } else if (especialidad == "Endodoncia") {
                espe = 3;
            } else if (especialidad == "Odontopediatría") {
                espe = 4;
            } else { espe = 0; }
            if (e.Tipo == "Matutino I") {
                hora = 1;
            } else if (e.Tipo == "Matutino II") {
                hora = 2;
            } else if (e.Tipo == "Vespertino I") {
                hora = 3;
            } else if (e.Tipo == "Vespertino II") {
                hora = 4;
            } else if (e.Tipo == "Fines de semana") {
                hora = 5;
            }

            odontologos.Add (od);
            ACtDBB (od, hora, espe);
        }

        public void guardarprueba (int id_Odontologo, string nombre, string cedula, string especialidad, char sexo, DateTime fechaNacimiento, string correo, string telefono, int consultorio, Horario e, Label label) {
            Odontologo od = null;
            od = new Odontologo (id_Odontologo, especialidad, consultorio, e, cedula, sexo, nombre, fechaNacimiento, telefono, correo);
            int espe = 0, hora = 0;

            if (especialidad == "Ortodoncia") {
                espe = 1;
            } else if (especialidad == "Peridoncia") {
                espe = 2;
            } else if (especialidad == "Endodoncia") {
                espe = 3;
            } else if (especialidad == "Odontopediatría") {
                espe = 4;
            } else { espe = 0; }

            if (e.Tipo == "Matutino I") {
                hora = 1;
            } else if (e.Tipo == "Matutino II") {
                hora = 2;
            } else if (e.Tipo == "Vespertino I") {
                hora = 3;
            } else if (e.Tipo == "Vespertino II") {
                hora = 4;
            } else if (e.Tipo == "Fines de semana") {
                hora = 5;
            }


            odontologos.Add (od);
            Console.WriteLine (" " + e.Tipo + " " + especialidad + " " + hora + " " + espe);

            guardarDBB (od, espe, hora);
        }

        public void ACtDBB (Odontologo od, int tipo, int espe) {
            string mensaje = "";
            datosodo.ACtualizar2 (od, tipo, espe);
            mensaje = datosodo.ACtualizar (od);
            if (mensaje [0] == '1')
                MessageBox.Show ("Ingreso de datos de persona correctamente");
            else
                MessageBox.Show ("Error: " + mensaje);

        }

        public void guardarDBB (Odontologo od, int especialidad, int horario) {
            string mensaje = "", mensaje2 = "";
            mensaje = datosodo.insertarPersonas (od);
            if (mensaje [0] == '1')
                MessageBox.Show ("Ingreso de datos de persona correctamente");
            else
                MessageBox.Show ("Error: " + mensaje);
            mensaje2 = datosodo.insertarOdontologo (od, especialidad, horario);
            if (mensaje [0] == '1')
                MessageBox.Show ("Ingresp de datos de odontologo correctamente");
            else
                MessageBox.Show ("Error: " + mensaje);

        }

        public void llenarGridT (DataGridView dgvOdontologo, string cedulas) {
            consultarDBBFC (cedulas);
            int i = 1;

            foreach (Odontologo x in odontologos) {
                dgvOdontologo.Rows.Add (i, x.Cedula, x.Nombre, x.Sexo, x.Especialidad, x.Estado (x.Consultorio), x.FechaNacimiento, x.Correo, x.Telefono, x.Horario.Tipo);
                i++;
            }

        }

        public void llenarGrid (DataGridView dgvOdontologo) {
            consultarDBB ();
            int i = 0;
            foreach (Odontologo x in odontologos) {
                i++;
                dgvOdontologo.Rows.Add (i, x.Cedula, x.Nombre, x.Sexo, x.Especialidad, x.Estado (x.Consultorio), x.FechaNacimiento, x.Correo, x.Telefono, x.Horario.Tipo);
            }
        }

        private void consultarDBB () {
            odontologos.Clear ();
            odontologos = datosodo.ConsultarPersonaOdontTodos ();
            if (odontologos == null)
                MessageBox.Show ("Error: Se se consultaron los datos");
        }

        public void llenarGridFiltrar (DataGridView dgvOdontologo, string jornada, string especialidad, int consultorio) {
            dgvOdontologo.Rows.Clear ();
            consultarDBBFiltrar (jornada, especialidad, consultorio);
            int i = 1;

            foreach (Odontologo x in odontologos) {
                dgvOdontologo.Rows.Add (i, x.Cedula, x.Nombre, x.Sexo, x.Especialidad, x.Estado (x.Consultorio), x.FechaNacimiento, x.Correo, x.Telefono, x.Horario.Tipo);
                i++;
            }
        }

        private void consultarDBBFiltrar (string jornada, string especialidad, int consultorio) {
            odontologos.Clear ();
            odontologos = datosodo.ConsultarPersonaOdontTodosF (jornada, especialidad, consultorio);
            if (odontologos == null)
                MessageBox.Show ("Error: No se consultaron los datos");
        }

        private void consultarDBBFC (string cedulas) {
            odontologos = datosodo.consultarodontologpFiltro2 (cedulas);
            if (odontologos == null)
                MessageBox.Show ("Error: Se se consultaron los datos");
        }

        public void Eliminar (DataGridView dgvOdontologo, int posicion) {
            dgvOdontologo.Rows.RemoveAt (posicion);
            int id = odontologos [posicion].Id_Odontologo;
            string cedula = odontologos [posicion].Cedula;

            Eliminar (id, cedula);
            odontologos.RemoveAt (posicion);

        }

        private void Eliminar (int id, string cedula) {
            string mensaje = mensaje = datosodo.eliminar (id);
            datosodo.eliminarOdontologoPersona (cedula);
            if (mensaje [0] == '1')
                MessageBox.Show ("Eliminacion del registro");
            else
                MessageBox.Show ("Error: " + mensaje);
        }

        public string mostrardatos () {
            return odontologos [odontologos.Count - 1].ToString ();

        }

        public int Contarbasedato () {
            int e;

            e = datosodo.A () + 1;

            return e;
        }

        public void pdf (string jornada, string especialidad, int consultorio) {
            odontologos.Clear ();
            //PdfWriter pdfWriter = new PdfWriter(@"C:\Users\emely\source\Reporte.pdf");
            //PdfDocument pdf = new PdfDocument(pdfWriter);
            //Document doc = new Document(pdf, PageSize.LETTER);
            //doc.SetMargins(60, 20, 55, 20);
            //var parrafo = new Paragraph("Hola Mundo");
            //doc.Add(parrafo);
            //doc.Close();

            //string pdfNombre = "DENTALING_CONSULTORIO_DENTAL_ODONTOLOGO.pdf";
            SaveFileDialog sfd = new SaveFileDialog ();
            sfd.Filter = "Pdf File |*.pdf";
            sfd.InitialDirectory = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
            sfd.Title = "Dentalig: Odontologo - Guardar";
            DialogResult dr = sfd.ShowDialog ();
            if (dr == DialogResult.OK) {
                //string folder = sfd.FileName; // Dirección a guardar pdf
                PdfWriter pdfWriter = new PdfWriter ("Reporte_Odontologo.pdf");  // seleccionar donde guardar ¿?
                                                                                 //PdfWriter pdfWriter = new PdfWriter(folder);  // seleccionar donde guardar ¿?
                PdfDocument pdfDocument = new PdfDocument (pdfWriter);
                Document doc = new Document (pdfDocument, PageSize.A4.Rotate ());
                doc.SetMargins ((float)15, (float)2.54, (float)2.54, (float)2.54);

                PdfFont fontColumnas = PdfFontFactory.CreateFont (StandardFonts.HELVETICA_BOLD); // Tipo de letra Titulo de columnas
                PdfFont fontContenido = PdfFontFactory.CreateFont (StandardFonts.HELVETICA);    // Tipo de letra contenido
                var titulo = new Paragraph ("Reporte de Odontologos");
                titulo.SetTextAlignment (TextAlignment.CENTER);
                titulo.SetFontSize (12);
                string [] columnas = { "#", "#Cedula", "Nombre", "Odontólogo", "Especialidad", "Consultorio", "Jornada", "Sexo", "FechaNacimiento", "NombrePieza", "Correo", "Telefono" };
                float [] espacio = { 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
                Table tabla = new Table (UnitValue.CreatePercentArray (espacio));
                tabla.SetWidth (UnitValue.CreatePercentValue (100));

                doc.Add (titulo.SetFont (fontColumnas));
                foreach (string element in columnas) {
                    tabla.AddHeaderCell (new Cell ().Add (new Paragraph (element).SetFont (fontColumnas)));
                }
                odontologosF = datosOdon.ConsultarPersonaOdontTodosF (jornada, especialidad, consultorio);
                int i = 0;
                foreach (Odontologo element in odontologosF) {
                    ++i;
                    tabla.AddCell (new Cell ().Add (new Paragraph (i + "").SetFont (fontContenido))); // #
                    //tabla.AddCell(new Cell().Add(new Paragraph(dhc.ConsultarIdHistoriaClinica(element.Cita.Paciente.Nombre) + "").SetFont(fontContenido)));   // #HistoriaClínica
                    tabla.AddCell (new Cell ().Add (new Paragraph (element.Cedula).SetFont (fontContenido)));
                    tabla.AddCell (new Cell ().Add (new Paragraph (element.Nombre).SetFont (fontContenido)));
                    tabla.AddCell (new Cell ().Add (new Paragraph (element.Sexo + " ").SetFont (fontContenido)));
                    tabla.AddCell (new Cell ().Add (new Paragraph (element.Consultorio + "").SetFont (fontContenido)));
                    tabla.AddCell (new Cell ().Add (new Paragraph (element.Especialidad).SetFont (fontContenido)));

                    tabla.AddCell (new Cell ().Add (new Paragraph (element.Horario.Tipo).SetFont (fontContenido)));
                    tabla.AddCell (new Cell ().Add (new Paragraph (element.FechaNacimiento.ToString ("dd/MM/yyy")).SetFont (fontContenido)));
                    tabla.AddCell (new Cell ().Add (new Paragraph (element.Correo).SetFont (fontContenido)));

                    tabla.AddCell (new Cell ().Add (new Paragraph (element.Telefono).SetFont (fontContenido)));

                }
                doc.Add (tabla);
                doc.Close ();

            }
        }

    }
}
