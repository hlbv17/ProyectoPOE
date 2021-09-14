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
    public partial class Frm_AtencionMedica_Editar_ROPB : Form {

        Adm_AtencionMedica adm = Adm_AtencionMedica.GetAdm ();
        Frm_AtencionMedica_Buscar_ROPB frmBuscar;

        public Frm_AtencionMedica_Editar_ROPB (DateTime fecha, string hora, string paciente, Frm_AtencionMedica_Buscar_ROPB frmB) {
            InitializeComponent ();
            //adm.LlenarComboHora (cmb_Hora);
            adm.LlenarComboHoraAutomatico (dtp_Fecha, cmb_Hora, 2);
            adm.LlenarComboPacienteAutomatico (dtp_Fecha, cmb_Hora, cmb_Paciente, 2); // 2: ALL
            adm.LlenarComboCuadrantePieza (cmb_CuadrantePieza);
            adm.LlenarComboCuadrantePieza (cmb_CuadrantePieza_Editar);
            adm.LlenarComboNombrePieza (cmb_NombrePieza);
            adm.LlenarComboNombrePieza (cmb_NombrePieza_Editar);
            dtp_Fecha.Value = fecha;
            cmb_Hora.Text = hora;
            cmb_Paciente.Text = paciente;
            frmBuscar = frmB;
        }

        private void dtp_Fecha_ValueChanged (object sender, EventArgs e) {
            // Method
            adm.LlenarDatosEditar (dtp_Fecha, cmb_Hora, cmb_Paciente, cmb_CuadrantePieza, cmb_NombrePieza, txt_MotivoConsulta, txt_Diagnostico, cmb_CuadrantePieza_Editar, cmb_NombrePieza_Editar, txt_MotivoConsulta_Editar, txt_Diagnostico_Editar);
        }

        private void cmb_Paciente_SelectedValueChanged (object sender, EventArgs e) {
            adm.LlenarLabelOdontologo (dtp_Fecha, cmb_Hora, cmb_Paciente, lbl_Odontologo);
            // Method
            adm.LlenarDatosEditar (dtp_Fecha, cmb_Hora, cmb_Paciente, cmb_CuadrantePieza, cmb_NombrePieza, txt_MotivoConsulta, txt_Diagnostico, cmb_CuadrantePieza_Editar, cmb_NombrePieza_Editar, txt_MotivoConsulta_Editar, txt_Diagnostico_Editar);
        }

        private void cmb_CuadrantePieza_SelectedValueChanged (object sender, EventArgs e) {
            adm.LlenarLabelNumeroPieza (cmb_CuadrantePieza, cmb_NombrePieza, lbl_NumeroPieza);
        }

        private void cmb_CuadrantePieza_Editar_SelectedValueChanged (object sender, EventArgs e) {
            adm.LlenarLabelNumeroPieza (cmb_CuadrantePieza_Editar, cmb_NombrePieza_Editar, lbl_NumeroPieza_Editar);
        }

        private void btn_Guardar_Editar_Click (object sender, EventArgs e) {
            bool frmEditar = adm.GuardarEditar (dtp_Fecha, cmb_Hora, cmb_Paciente, cmb_CuadrantePieza, cmb_NombrePieza, txt_MotivoConsulta, txt_Diagnostico, cmb_CuadrantePieza_Editar, cmb_NombrePieza_Editar, txt_MotivoConsulta_Editar, txt_Diagnostico_Editar, errorProvider1, txt_Registro, lbl_Odontologo, lbl_NumeroPieza_Editar);
            if (frmEditar && frmBuscar != null) { // Atualiza DataGridView
                if (frmBuscar.buscarGlobal == 0) {
                    frmBuscar.btn_Limpiar_Click (sender, e);
                } else {
                    frmBuscar.btn_Buscar_Click (sender, e);
                }
            }
        }

    }
}
