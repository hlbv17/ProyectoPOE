using Control;
using System;
using System.Windows.Forms;

namespace Visual
{
    public partial class Frm_Cita_Registrar : Form
    {
        Adm_Paciente admPa = new Adm_Paciente();
        Adm_Odontologo admO = Adm_Odontologo.GetAdm();
        Adm_Cita admCita = Adm_Cita.GetAdm();
        public Frm_Cita_Registrar()
        {
            InitializeComponent();
            admCita.LlenarComboH(cmbHora);
            cmbHora.SelectedIndex = 0;
            cmbOdontologo.Enabled = false;
        }

        private void txtPaciente_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if(!char.IsDigit(c) && (e.KeyChar != Convert.ToChar(Keys.Back))){
                if (e.KeyChar == Convert.ToChar(Keys.Enter) && txtPaciente.Text.Length >= 10)
                    admPa.ConsultarPacientes(txtPaciente.Text, lblNombre);
                else
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string cedula = txtPaciente.Text, hora = cmbHora.Text, odontologo = cmbOdontologo.Text;
            DateTime fecha = dtpFecha.Value.Date;
            DateTime dHora = DateTime.Now;
            if (cmbHora.Text != "--Seleccionar--")
            {
                dHora = DateTime.Parse(hora, System.Globalization.CultureInfo.CurrentCulture);
            }
            errorP.Clear();
            if (admCita.Validar(txtPaciente, cmbHora, dtpFecha, cmbOdontologo, errorP))
            {
                errorP.Clear();
                admCita.Guardar(1, cedula, odontologo, fecha, dHora);
                admCita.Agregar(txtRegistro);
            }
        }

        private void cmbHora_SelectedValueChanged(object sender, EventArgs e)
        {
            string hora = cmbHora.Text;
            DateTime fecha = dtpFecha.Value.Date;
            if(hora != "--Seleccionar--")
            {
                cmbOdontologo.Enabled = true;
                DateTime dHora = DateTime.Parse(hora, System.Globalization.CultureInfo.CurrentCulture);
                cmbOdontologo.Items.Clear();
                admO.llenarComboO(fecha, dHora, cmbHora, cmbOdontologo);
            }
            
        }

        private void cmbOdontologo_SelectedValueChanged(object sender, EventArgs e)
        {
            string odontologo = (string)cmbOdontologo.SelectedItem;
            admO.LabelConsultorio(odontologo, cmbOdontologo, lblConsultorio);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            admCita.LimpiarCamposR(txtPaciente, lblNombre, dtpFecha, cmbHora, cmbOdontologo, lblConsultorio, txtRegistro);
        }
    }
}
