using Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visual
{
    public partial class FrmFiltrarVLRS : Form
    {

        Adm_HistoriaClinicaVLRS admHisClinica = Adm_HistoriaClinicaVLRS.GetAdm();
        ValidacionesVLRS val = new ValidacionesVLRS();
        int rbindex, index;
        string sexo, cedula;
        DateTime fechaDesde, fechaHasta;
        public FrmFiltrarVLRS()
        {
            InitializeComponent();
            panelCedu.Visible = false;
            panelSeFech.Visible = false;
            btnBuscar.Visible = false;
            btnLimpiar.Visible = false;
            gbopciones.Visible = false;
            rbtambos.Checked = true;

            admHisClinica.LlenarGrid(dgvPacientes, lblTotal);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvPacientes.Rows.Clear();
            admHisClinica.LlenarGrid(dgvPacientes, lblTotal);
            txtCedula.Text = "";
            cmbSexo.Text = null;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rbxsexo_CheckedChanged(object sender, EventArgs e)
        {
            rbindex = 2;
            cmbSexo.Visible = true;
            dtpFnac1.Visible = false;
            dtpFnac2.Visible = false;
            lblfechas.Visible = false;
            lblsexo.Visible = true;
        }

        private void rbtxfechas_CheckedChanged(object sender, EventArgs e)
        {
            rbindex = 3;
            cmbSexo.Visible = false;
            dtpFnac1.Visible = true;
            dtpFnac2.Visible = true;
            lblsexo.Visible = false;
            lblfechas.Visible = true;
        }

        private void rbtambos_CheckedChanged(object sender, EventArgs e)
        {
            rbindex = 4;
            cmbSexo.Visible = true;
            dtpFnac1.Visible = true;
            dtpFnac2.Visible = true;
            lblsexo.Visible = true;
            lblfechas.Visible = true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }
    }
}
