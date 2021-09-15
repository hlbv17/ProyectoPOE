using Control;
using System;
using System.Windows.Forms;

namespace Visual {
    public partial class Frm_Menu : Form {

        Adm_Cita adm = Adm_Cita.GetAdm ();
        Adm_AtencionMedica admAM = Adm_AtencionMedica.GetAdm ();
        public Frm_Menu () {
            InitializeComponent ();
        }

        private void conexionToolStripMenuItem_Click (object sender, EventArgs e) {
            adm.Conectar ();
        }

        private void registrarToolStripMenuItem2_Click (object sender, EventArgs e) {
            Frm_Cita_Registrar frmR = new Frm_Cita_Registrar ();
            frmR.ShowDialog ();
        }

        private void listarToolStripMenuItem_Click (object sender, EventArgs e) {
            Frm_Cita_Listar frmL = new Frm_Cita_Listar ();
            frmL.ShowDialog ();
        }

        private void editarToolStripMenuItem2_Click (object sender, EventArgs e) {
            Frm_Cita_Filtrar frmF = new Frm_Cita_Filtrar();
            frmF.ShowDialog();
            /*Frm_Cita_Editar frmE = new Frm_Cita_Editar ();
            frmE.ShowDialog ();*/
        }

        private void consultarToolStripMenuItem2_Click (object sender, EventArgs e) {
            Frm_Cita_Filtrar frmF = new Frm_Cita_Filtrar ();
            frmF.ShowDialog ();

        }

        private void eliminarToolStripMenuItem2_Click (object sender, EventArgs e) {
            Frm_Cita_Eliminar frmEl = new Frm_Cita_Eliminar ();
            frmEl.ShowDialog ();
        }

        private void acercaDeToolStripMenuItem_Click (object sender, EventArgs e) {
            Frm_About frm = new Frm_About ();
            frm.ShowDialog ();
        }

        private void registrarToolStripMenuItem1_Click (object sender, EventArgs e) {
            Frm_Odontologo_Registrar f = new Frm_Odontologo_Registrar ();
            f.ShowDialog ();
        }

        private void editarToolStripMenuItem1_Click (object sender, EventArgs e) {
            Frm_Odontologo_ConsultarEliminar f = new Frm_Odontologo_ConsultarEliminar ();
            f.ShowDialog ();
        }

        private void eliminarToolStripMenuItem1_Click (object sender, EventArgs e) {
            Frm_Odontologo_ConsultarEliminar f = new Frm_Odontologo_ConsultarEliminar ();
            f.ShowDialog ();
        }

        private void consultarToolStripMenuItem1_Click (object sender, EventArgs e) {
            Frm_Odontologo_ConsultarEliminar f = new Frm_Odontologo_ConsultarEliminar ();
            f.ShowDialog ();
        }

        private void registrarToolStripMenuItem_Click (object sender, EventArgs e) {
            Frm_HistoriaClinica_Registrar frm = new Frm_HistoriaClinica_Registrar ();
            frm.ShowDialog ();
        }

        private void editarToolStripMenuItem_Click (object sender, EventArgs e) {
            Frm_HistoriaClinica_Filtrar frm = new Frm_HistoriaClinica_Filtrar ();
            frm.ShowDialog ();
        }

        private void registrarToolStripMenuItem_Click_1 (object sender, EventArgs e) {
            Frm_HistoriaClinica_Registrar frm = new Frm_HistoriaClinica_Registrar ();
            frm.ShowDialog ();
        }

        private void editarToolStripMenuItem_Click_1 (object sender, EventArgs e) {
            Frm_HistoriaClinica_Filtrar frm = new Frm_HistoriaClinica_Filtrar ();
            frm.ShowDialog ();
        }

        private void eliminarToolStripMenuItem_Click (object sender, EventArgs e) {
            Frm_HistoriaClinica_Filtrar frm = new Frm_HistoriaClinica_Filtrar ();
            frm.ShowDialog ();
        }

        private void consultarToolStripMenuItem_Click (object sender, EventArgs e) {
            Frm_HistoriaClinica_Filtrar frm = new Frm_HistoriaClinica_Filtrar ();
            frm.ShowDialog ();
        }

        private void reporteToolStripMenuItem_Click (object sender, EventArgs e) {
            Frm_HistoriaClinica_Filtrar frm = new Frm_HistoriaClinica_Filtrar ();
            frm.ShowDialog ();
        }

        private void mni_AM_Registrar_Click (object sender, EventArgs e) {
            Frm_AtencionMedica_Registrar frm = new Frm_AtencionMedica_Registrar ();
            frm.ShowDialog ();
        }

        private void mni_AM_Editar_Click (object sender, EventArgs e) {
            if (admAM.ContarLista () > 0) {
                Frm_AtencionMedica_Editar frm = new Frm_AtencionMedica_Editar (DateTime.Now, "---Seleccione---", "---Seleccione---", null);
                frm.ShowDialog ();
            } else {
                MessageBox.Show ("No hay registro de Atenciones Médicas", "Error!");
            }
        }

        private void mni_AM_Eliminar_Click (object sender, EventArgs e) {
            if (admAM.ContarLista () > 0) {
                Frm_AtencionMedica_Eliminar frm = new Frm_AtencionMedica_Eliminar (DateTime.Now, "---Seleccione---", "---Seleccione---", null);
                frm.ShowDialog ();
            } else {
                MessageBox.Show ("No hay registro de Atenciones Médicas", "Error!");
            }
        }

        private void mni_AM_Consultar_Click (object sender, EventArgs e) {
            if (admAM.ContarLista () > 0) {
                Frm_AtencionMedica_Busca frm = new Frm_AtencionMedica_Busca ("");
                frm.ShowDialog ();
            } else {
                MessageBox.Show ("No hay registro de Atenciones Médicas", "Error!");
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
