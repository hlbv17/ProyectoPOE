using Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visual {
    public partial class Frm_HistoriaClinica_Filtrar : Form {

        Adm_HistoriaClinicaVLRS admHisClinica = Adm_HistoriaClinicaVLRS.GetAdm ();
        Validacion val = new Validacion ();
        int rbindex, index;
        string sexo, cedula;
        DateTime fechaDesde, fechaHasta;

        public Frm_HistoriaClinica_Filtrar () {
            InitializeComponent ();
            panelCedu.Visible = false;
            panelSeFech.Visible = false;
            btnBuscar.Visible = false;
            btnLimpiar.Visible = false;
            gbopciones.Visible = false;
            rbtambos.Checked = true;
            button1.Visible = false;
            admHisClinica.LlenarGrid (dgvPacientes, lblTotal);
        }

        private void btnLimpiar_Click (object sender, EventArgs e) {
            dgvPacientes.Rows.Clear ();
            admHisClinica.LlenarGrid (dgvPacientes, lblTotal);
            txtCedula.Text = "";
            cmbSexo.Text = null;
            dtpFnac1.Value = DateTime.Now;
            dtpFnac2.Value = DateTime.Now;
        }

        private void btnEliminar_Click (object sender, EventArgs e) {

            var filaSeleccionada = dgvPacientes.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {
                string cedula = filaSeleccionada.Cells [1].Value.ToString ();
                Console.WriteLine (cedula);
                admHisClinica.Eliminar (dgvPacientes, cedula, lblTotal, filaSeleccionada);
            }
        }

        private void btnEditar_Click (object sender, EventArgs e) {
            Frm_HistoriaClinica_Editar frm = new Frm_HistoriaClinica_Editar ();
            var filaSeleccionada = dgvPacientes.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {
                string cedula = filaSeleccionada.Cells [1].Value.ToString ();
                Console.WriteLine (cedula);
                frm.LlenarFormulario (cedula);
                button1.Visible = true;

            }
            frm.ShowDialog ();
        }

        private void txtCedula_KeyPress (object sender, KeyPressEventArgs e) {
            char c = e.KeyChar;
            if (!char.IsDigit (c) && (e.KeyChar != Convert.ToChar (Keys.Back))) {
                e.Handled = true;
                return;
            }
        }

        private void btnBuscar_Click (object sender, EventArgs e) {
            sexo = cmbSexo.Text;
            cedula = txtCedula.Text;
            index = cmbFiltro.SelectedIndex;
            fechaDesde = dtpFnac1.Value.Date;
            fechaHasta = dtpFnac2.Value.Date;
            if (val.ValidarFiltro (errorProvider1, cmbFiltro, txtCedula, cmbSexo, dtpFnac1, dtpFnac2, rbindex)) {
                errorProvider1.Clear ();
                admHisClinica.ConsultarBBDXsexoXCedulaXFechas (sexo, cedula, fechaDesde, fechaHasta, dgvPacientes, lblTotal, index, rbindex);
                btnImprimir.Visible = true;
            } else {
                MessageBox.Show ("Escoja correctamente el campo a filtrar");
            }
        }

        private void cmbFiltro_SelectedIndexChanged (object sender, EventArgs e) {
            index = cmbFiltro.SelectedIndex;

            if (index == 0) {//filtrar cedula
                panelSeFech.Visible = false;
                gbopciones.Visible = false;
                panelCedu.Visible = true;
                btnBuscar.Visible = true;
                btnLimpiar.Visible = true;

            } else if (index == 1)//filtrar xsexoy/ofechas
              {
                panelSeFech.Visible = true;
                gbopciones.Visible = true;
                panelCedu.Visible = false;
                btnBuscar.Visible = true;
                btnLimpiar.Visible = true;

            }
        }

        private void rbxsexo_CheckedChanged (object sender, EventArgs e) {
            rbindex = 2;
            cmbSexo.Visible = true;
            dtpFnac1.Visible = false;
            dtpFnac2.Visible = false;
            lblfechas.Visible = false;
            lblsexo.Visible = true;
        }

        private void button1_Click (object sender, EventArgs e) {
            sexo = cmbSexo.Text;
            cedula = txtCedula.Text;
            index = cmbFiltro.SelectedIndex;
            fechaDesde = dtpFnac1.Value.Date;
            fechaHasta = dtpFnac2.Value.Date;
            if (val.ValidarFiltro (errorProvider1, cmbFiltro, txtCedula, cmbSexo, dtpFnac1, dtpFnac2, rbindex)) {
                errorProvider1.Clear ();
                admHisClinica.ConsultarBBDXsexoXCedulaXFechas (sexo, cedula, fechaDesde, fechaHasta, dgvPacientes, lblTotal, index, rbindex);
                btnImprimir.Visible = true;
            } else {
                MessageBox.Show ("Escoja correctamente el campo a filtrar");
            }
        }

        private void btn_AtencionMedica_Click (object sender, EventArgs e) {
            var filaSeleccionada = dgvPacientes.CurrentRow;
            if (filaSeleccionada != null) { //¿Existe una referencia?
                string paciente = filaSeleccionada.Cells [2].Value.ToString ();
                Console.WriteLine (paciente);
                Frm_AtencionMedica_Buscar_ROPB frm = new Frm_AtencionMedica_Buscar_ROPB (paciente);
                frm.ShowDialog ();
            }
        }

        private void rbtambos_CheckedChanged (object sender, EventArgs e) {
            rbindex = 4;
            cmbSexo.Visible = true;
            dtpFnac1.Visible = true;
            dtpFnac2.Visible = true;
            lblsexo.Visible = true;
            lblfechas.Visible = true;
            cmbSexo.Visible = false;
            dtpFnac1.Visible = true;
            dtpFnac2.Visible = true;
            lblsexo.Visible = false;
            lblfechas.Visible = true;
        }

        private void rbtxfechas_CheckedChanged (object sender, EventArgs e) {
            rbindex = 3;
            cmbSexo.Visible = false;
            dtpFnac1.Visible = true;
            dtpFnac2.Visible = true;
            lblsexo.Visible = false;
            lblfechas.Visible = true;
        }

        private void btnImprimir_Click (object sender, EventArgs e) {
            char Csexo = ' ';
            if (sexo != "") {
                Csexo = sexo [0];
            }
            admHisClinica.ReporteiText (Csexo, cedula, fechaDesde, fechaHasta, index, rbindex);
        }

    }
}
