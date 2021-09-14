using Control;
using System;
using System.Windows.Forms;

namespace Visual {
    public partial class Frm_Menu : Form {

        AdmCitaHLBV adm = AdmCitaHLBV.GetAdm ();
        Adm_AtencionMedica_ROPB admAM = Adm_AtencionMedica_ROPB.GetAdm ();
        public Frm_Menu () {
            InitializeComponent ();
        }

        private void conexionToolStripMenuItem_Click (object sender, EventArgs e) {
            adm.Conectar ();
        }

        private void registrarToolStripMenuItem2_Click (object sender, EventArgs e) {
            FrmRegistrarCitaHLBV frmR = new FrmRegistrarCitaHLBV ();
            frmR.ShowDialog ();
        }

        private void listarToolStripMenuItem_Click (object sender, EventArgs e) {
            FrmListarCitasHLBV frmL = new FrmListarCitasHLBV ();
            frmL.ShowDialog ();
        }

        private void editarToolStripMenuItem2_Click (object sender, EventArgs e) {
            FrmEditarCitasHLBV frmE = new FrmEditarCitasHLBV ();
            frmE.ShowDialog ();
        }

        private void consultarToolStripMenuItem2_Click (object sender, EventArgs e) {
            FrmFiltrarCitasHLBV frmF = new FrmFiltrarCitasHLBV ();
            frmF.ShowDialog ();

        }

        private void eliminarToolStripMenuItem2_Click (object sender, EventArgs e) {
            FrmEliminarCitasHLBV frmEl = new FrmEliminarCitasHLBV ();
            frmEl.ShowDialog ();
        }

        private void acercaDeToolStripMenuItem_Click (object sender, EventArgs e) {

        }

        private void registrarToolStripMenuItem1_Click (object sender, EventArgs e) {
            FrmOdontologoEGGM f = new FrmOdontologoEGGM ();
            f.ShowDialog ();
        }

        private void editarToolStripMenuItem1_Click (object sender, EventArgs e) {
            FrmConsultarANDEliminarodontologo f = new FrmConsultarANDEliminarodontologo ();
            f.ShowDialog ();
        }

        private void eliminarToolStripMenuItem1_Click (object sender, EventArgs e) {
            FrmConsultarANDEliminarodontologo f = new FrmConsultarANDEliminarodontologo ();
            f.ShowDialog ();
        }

        private void consultarToolStripMenuItem1_Click (object sender, EventArgs e) {
            FrmConsultarANDEliminarodontologo f = new FrmConsultarANDEliminarodontologo ();
            f.ShowDialog ();
        }

        private void registrarToolStripMenuItem_Click (object sender, EventArgs e) {
            FrmIngresoHisClinicaVLRS frm = new FrmIngresoHisClinicaVLRS ();
            frm.ShowDialog ();
        }

        private void editarToolStripMenuItem_Click (object sender, EventArgs e) {
            FrmFiltrarVLRS frm = new FrmFiltrarVLRS ();
            frm.ShowDialog ();
        }

        private void registrarToolStripMenuItem_Click_1 (object sender, EventArgs e) {
            FrmIngresoHisClinicaVLRS frm = new FrmIngresoHisClinicaVLRS ();
            frm.ShowDialog ();
        }

        private void editarToolStripMenuItem_Click_1 (object sender, EventArgs e) {
            FrmFiltrarVLRS frm = new FrmFiltrarVLRS ();
            frm.ShowDialog ();
        }

        private void eliminarToolStripMenuItem_Click (object sender, EventArgs e) {
            FrmFiltrarVLRS frm = new FrmFiltrarVLRS ();
            frm.ShowDialog ();
        }

        private void consultarToolStripMenuItem_Click (object sender, EventArgs e) {
            FrmFiltrarVLRS frm = new FrmFiltrarVLRS ();
            frm.ShowDialog ();
        }

        private void reporteToolStripMenuItem_Click (object sender, EventArgs e) {
            FrmFiltrarVLRS frm = new FrmFiltrarVLRS ();
            frm.ShowDialog ();
        }

        private void mni_AM_Registrar_Click (object sender, EventArgs e) {
            Frm_AtencionMedica_Registrar_ROPB frm = new Frm_AtencionMedica_Registrar_ROPB ();
            frm.ShowDialog ();
        }

        private void mni_AM_Editar_Click (object sender, EventArgs e) {
            if (admAM.ContarLista () > 0) {
                Frm_AtencionMedica_Editar_ROPB frm = new Frm_AtencionMedica_Editar_ROPB (DateTime.Now, "---Seleccione---", "---Seleccione---", null);
                frm.ShowDialog ();
            } else {
                MessageBox.Show ("No hay registro de Atenciones Médicas", "Error!");
            }
        }

        private void mni_AM_Eliminar_Click (object sender, EventArgs e) {
            if (admAM.ContarLista () > 0) {
                Frm_AtencionMedica_Eliminar_ROPB frm = new Frm_AtencionMedica_Eliminar_ROPB (DateTime.Now, "---Seleccione---", "---Seleccione---", null);
                frm.ShowDialog ();
            } else {
                MessageBox.Show ("No hay registro de Atenciones Médicas", "Error!");
            }
        }

        private void mni_AM_Consultar_Click (object sender, EventArgs e) {
            if (admAM.ContarLista () > 0) {
                Frm_AtencionMedica_Buscar_ROPB frm = new Frm_AtencionMedica_Buscar_ROPB ("");
                frm.ShowDialog ();
            } else {
                MessageBox.Show ("No hay registro de Atenciones Médicas", "Error!");
            }
        }

    }
}
