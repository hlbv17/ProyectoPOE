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
    public partial class FrmConsultarANDEliminarodontologo : Form {

        AdmOdontologoEGGM admodo = AdmOdontologoEGGM.GetAdm ();
        public string cedula;

        public FrmConsultarANDEliminarodontologo () {
            InitializeComponent ();
            admodo.llenarGrid (dvgOdontologo);
        }

        private void btnEliminar_Click (object sender, EventArgs e) {
            int posicion = dvgOdontologo.CurrentRow.Index;
            if (posicion >= 0) {
                admodo.Eliminar (dvgOdontologo, posicion);
            }
        }

        private void btnActualizar_Click (object sender, EventArgs e) {
            FrmActualizarOdontologo frm = new FrmActualizarOdontologo ();
            int posicion = dvgOdontologo.CurrentRow.Index;
            if (posicion >= 0) {
                cedula = admodo.Actualizar (posicion);
                frm.cedula = cedula;
                frm.ShowDialog ();
            }
        }

        private void btnBuscar_Click (object sender, EventArgs e) {
            dvgOdontologo.Rows.Clear ();
            cedula = txtCedula.Text;
            admodo.llenarGridT (dvgOdontologo, cedula);
        }

        private void rtCedula_CheckedChanged (object sender, EventArgs e) {
            PanelCedula.Visible = true;
            PanelCampos.Visible = false;
        }

        private void rtCampos_CheckedChanged (object sender, EventArgs e) {
            PanelCedula.Visible = false;
            PanelCampos.Visible = true;
        }

        private void txtCedula_KeyPress (object sender, KeyPressEventArgs e) {
            char c = e.KeyChar;
            if (!char.IsDigit (c) && (e.KeyChar != Convert.ToChar (Keys.Back))) {
                e.Handled = true;
                return;
            }
        }

        private void btnImprimir_Click (object sender, EventArgs e) {
            int posicion = dvgOdontologo.CurrentRow.Index;
            string cedula1 = txtCedula.Text.Trim ();
            string jornada = cmbjornada.Text, especialidad = cmbEspecialidad.Text;
            int consultorio;
            try {
                int consul = Convert.ToInt32 (cmbConsultorio.Text);
                if (posicion >= 0) {
                    cedula1 = admodo.Actualizar (posicion);
                }
                admodo.pdf (jornada, especialidad, consul);
            } catch (Exception ex) {
                consultorio = 0;

                if (posicion >= 0) {
                    cedula1 = admodo.Actualizar (posicion);
                }
                admodo.pdf (jornada, especialidad, consultorio);
                Console.WriteLine(ex);
            }
        }

        private void btnRefres_Click (object sender, EventArgs e) {
            dvgOdontologo.Rows.Clear ();
            admodo.llenarGrid (dvgOdontologo);
            cmbConsultorio.SelectedIndex = 0;
            cmbEspecialidad.SelectedIndex = 0;
            cmbjornada.SelectedIndex = 0;
        }

        private void cmbjornada_SelectedValueChanged (object sender, EventArgs e) {
            dvgOdontologo.Rows.Clear ();
            string esoecialida = cmbEspecialidad.Text, jornada = cmbjornada.Text;
            try {
                int consul = Convert.ToInt32 (cmbConsultorio.Text);
                admodo.llenarGridFiltrar (dvgOdontologo, jornada, esoecialida, consul);
            } catch (Exception ex) {
                int consultorio = 0;
                admodo.llenarGridFiltrar (dvgOdontologo, jornada, esoecialida, consultorio);
                Console.WriteLine(ex);
            }
        }
    }
}
