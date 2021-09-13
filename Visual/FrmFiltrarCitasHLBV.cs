using Control;
using System;
using System.Windows.Forms;

namespace Visual
{
    public partial class FrmFiltrarCitasHLBV : Form
    {
        AdmCitaHLBV admC = AdmCitaHLBV.GetAdm();
        public FrmFiltrarCitasHLBV()
        {
            InitializeComponent();
            admC.LlenarComboH(cmbHora);
            cmbHora.SelectedIndex = 0;
            chbCedula.Checked = true;
            chbFecha.Checked= true;
            chbHora.Checked = true;
            //btnImprimir.Enabled = false;
            admC.LlenarTabla(dgvCitas);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text, hora = cmbHora.Text;
            DateTime fecha = dtpFecha.Value.Date;
            int n = 0;
            if (chbFecha.Checked && chbCedula.Checked && chbHora.Checked)
            {
                n = 7;
            }
            else if (chbFecha.Checked && chbHora.Checked)
            {
                n = 6;
            }
            else if (chbFecha.Checked && chbCedula.Checked)
            {
                n = 5;
            }
            else if (chbHora.Checked && chbCedula.Checked)
            {
                n = 4;
            }
            else if (chbHora.Checked)
            {
                n = 3;
            }
            else if (chbFecha.Checked)
            {
                n = 2;
            }
            else if (chbCedula.Checked)
            {
                n = 1;
            }
            admC.FiltrarDatos(dgvCitas, cedula, fecha, hora, n, btnImprimir);
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (char.IsLetter(c) && (e.KeyChar != Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            dgvCitas.Rows.Clear();
            admC.LlenarTabla(dgvCitas);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            admC.LimpiarCampos(txtCedula, dgvCitas, dtpFecha, cmbHora, btnImprimir);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int posicion = dgvCitas.Rows.Count;
            if (posicion != 1)
            {
                FrmEditar2HLBV frmE = new FrmEditar2HLBV(dgvCitas);
                frmE.Visible = true;
                
            }
            else
            {
                MessageBox.Show("No ha realizado la consulta");
            }   
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int posicion = dgvCitas.CurrentRow.Index;
            if (posicion >= 0)
            {
                admC.EliminarCita(dgvCitas, posicion);
            }
            else
            {
                MessageBox.Show("No ha realizado la consulta");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text, hora = cmbHora.Text;
            DateTime fecha = dtpFecha.Value.Date;
            int n = 0;
            if (chbFecha.Checked && chbCedula.Checked && chbHora.Checked)
            {
                n = 7;
            }
            else if (chbHora.Checked && chbCedula.Checked)
            {
                n = 4;
            }
            else if (chbFecha.Checked && chbCedula.Checked)
            {
                n = 5;
            }
            else if (chbFecha.Checked && chbHora.Checked)
            {
                n = 6;
            }
            else if (chbCedula.Checked)
            {
                n = 1;
            }
            else if (chbFecha.Checked)
            {
                n = 2;
            }
            else if (chbHora.Checked)
            {
                n = 3;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = saveFileDialog1.FileName;
                FrmReporteCitaHLBV frmR = new FrmReporteCitaHLBV(cedula, fecha, hora, n, file);
                frmR.Visible = true;
            }
            
        }

        private void chbCedula_CheckedChanged(object sender, EventArgs e)
        {
            if (chbCedula.Checked)
            {
                txtCedula.Enabled = true;
            }
            else
            {
                txtCedula.Enabled = false;
            }
        }

        private void chbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (chbFecha.Checked)
            {
                dtpFecha.Enabled = true;
            }
            else
            {
                dtpFecha.Enabled = false;
            }
        }

        private void chbHora_CheckedChanged(object sender, EventArgs e)
        {
            if (chbHora.Checked)
            {
                cmbHora.Enabled = true;
            }
            else
            {
                cmbHora.Enabled = false;
            }
        }
    }
}
