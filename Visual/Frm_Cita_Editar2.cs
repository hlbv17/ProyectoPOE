using Control;
using System;
using System.Windows.Forms;

namespace Visual
{
    public partial class Frm_Cita_Editar2 : Form
    {
        Adm_Odontologo admO = Adm_Odontologo.GetAdm();
        Adm_Cita admCita = Adm_Cita.GetAdm();
        public Frm_Cita_Editar2(DataGridView dgvCitas)
        {
            InitializeComponent();
            txtCedula.Enabled = false;
            int posicion = dgvCitas.CurrentRow.Index;
            int id = Convert.ToInt32(dgvCitas.Rows[posicion].Cells["col_id"].Value);
            admCita.ActualizarDatos(posicion, id, lblId, txtCedula, lblPaciente, dtpFecha, cmbHora, cmbOdontologo, lblConsultorio);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text, hora = cmbHora.Text, odontologo = cmbOdontologo.Text; 
            int id = Convert.ToInt32(lblId.Text);
            DateTime fecha = dtpFecha.Value.Date;
            DateTime dHora = DateTime.Parse(hora, System.Globalization.CultureInfo.CurrentCulture);
            errorP.Clear();
            if (admCita.Validar(txtCedula, cmbHora, dtpFecha, cmbOdontologo, errorP))
            {
                errorP.Clear();
                admCita.Editar(id, cedula, odontologo, fecha, dHora, txtRegistro);
            }
            
        }

        private void cmbHora_SelectedValueChanged(object sender, EventArgs e)
        {
            string hora = cmbHora.Text;
            DateTime fecha = dtpFecha.Value.Date;
            DateTime dHora = DateTime.Parse(hora, System.Globalization.CultureInfo.CurrentCulture);
            cmbOdontologo.Items.Clear();
            admO.llenarComboO(fecha, dHora, cmbHora, cmbOdontologo);
        }

        private void cmbOdontologo_SelectedValueChanged(object sender, EventArgs e)
        {
            string odontologo = (string)cmbOdontologo.SelectedItem;
            admO.LabelConsultorio(odontologo, cmbOdontologo, lblConsultorio);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            admCita.LimpiarCamposE(lblId, txtCedula, lblPaciente, dtpFecha, cmbHora, cmbOdontologo, lblConsultorio, txtRegistro);
        }
    }
}
