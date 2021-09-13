using Datos;
using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Control
{
    public class AdmOdontologoEGGM
    {
        List<Odontologo> odontologos = new List<Odontologo>();
        private static AdmOdontologoEGGM admO = new AdmOdontologoEGGM();
        DatosOdontologoEGGM datosOdonto = new DatosOdontologoEGGM();
        Odontologo odontologo = null;

        //Validacion val = null;

        public List<Odontologo> Odontologos { get => odontologos; set => odontologos = value; }
        public Odontologo Odontologo { get => odontologo; set => odontologo = value; }

        public AdmOdontologoEGGM()
        {
            odontologos = new List<Odontologo>();
            //val = new Validacion();
        }

        public static AdmOdontologoEGGM GetAdm()
        {
            if (admO == null)
            {
                admO = new AdmOdontologoEGGM();
            }
            return admO;
        }

        public void ConsultarOdontologos(DateTime fecha, DateTime hora, ComboBox cmbHora,
            ComboBox cmbOdontologo)
        {
            string dia = DayOfWeek(fecha);
            if (cmbHora.Text != "--Seleccionar--")
            {
                cmbOdontologo.Items.Add("--Seleccionar--");
                cmbOdontologo.SelectedIndex = 0;
                odontologos = datosOdonto.ConsultarOdontologos(dia, hora);
                foreach (Odontologo x in odontologos)
                {
                    cmbOdontologo.Items.Add(x.Nombre);
                }
            }

            if (odontologos == null)
            {
                MessageBox.Show("No existe un odontologo disponible");
            }
        }

        public string DayOfWeek(DateTime? date)
        {
            return date.Value.ToString("dddd", new CultureInfo("Es-Es"));
        }

        public void llenarComboO(DateTime fecha, DateTime hora, ComboBox cmbHora, ComboBox cmbOdontologo)
        {
            ConsultarOdontologos(fecha, hora, cmbHora, cmbOdontologo);
        }

        public void LabelConsultorio(string nombre, ComboBox cmbOdontologo, Label lblConsultorio)
        {
            int indice = 0, label = 0;

            indice = odontologos.FindIndex(x => x.Nombre == nombre);
            if (indice >= 0)
            {
                label = odontologos[indice].Consultorio;
                lblConsultorio.Text = label.ToString();

            }

        }
    }
}
