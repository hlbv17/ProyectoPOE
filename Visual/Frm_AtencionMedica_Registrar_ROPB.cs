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
    public partial class Frm_AtencionMedica_Registrar_ROPB : Form {


        Adm_AtencionMedica_ROPB adm = Adm_AtencionMedica_ROPB.GetAdm ();

        public Frm_AtencionMedica_Registrar_ROPB () {
            InitializeComponent ();
            adm.LlenarComboHoraAutomatico (dtp_Fecha, cmb_Hora, 1);
            adm.LlenarComboCuadrantePieza (cmb_CuadrantePieza);
            adm.LlenarComboNombrePieza (cmb_NombrePieza);
        }

        private void dtp_Fecha_ValueChanged (object sender, EventArgs e) {
            adm.LlenarComboPacienteAutomatico (dtp_Fecha, cmb_Hora, cmb_Paciente, 1); // 1: some
            adm.LlenarComboHoraAutomatico (dtp_Fecha, cmb_Hora, 1); // 1: some
        }

        private void cmb_Hora_SelectedValueChanged (object sender, EventArgs e) {
            adm.LlenarComboPacienteAutomatico (dtp_Fecha, cmb_Hora, cmb_Paciente, 1); // 1: some
        }

        private void cmb_Paciente_SelectedValueChanged (object sender, EventArgs e) {
            adm.LlenarLabelOdontologo (dtp_Fecha, cmb_Hora, cmb_Paciente, lbl_Odontologo);
        }

        private void cmb_CuadrantePieza_SelectedValueChanged (object sender, EventArgs e) {
            adm.LlenarLabelNumeroPieza (cmb_CuadrantePieza, cmb_NombrePieza, lbl_NumeroPieza);
        }

        private void cmb_NombrePieza_SelectedValueChanged (object sender, EventArgs e) {
            adm.LlenarLabelNumeroPieza (cmb_CuadrantePieza, cmb_NombrePieza, lbl_NumeroPieza);
        }

        private void button1_Click (object sender, EventArgs e) {
            adm.Guardar (dtp_Fecha, cmb_Hora, cmb_Paciente, cmb_CuadrantePieza, cmb_NombrePieza, txt_MotivoConsulta, txt_Diagnostico, errorProvider1, txt_Registro, lbl_Odontologo, lbl_NumeroPieza, 1); // 1: LlenarComoboAutomático some of them
        }

    }
}
