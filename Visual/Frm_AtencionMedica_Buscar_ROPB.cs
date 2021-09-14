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
    public partial class Frm_AtencionMedica_Buscar_ROPB : Form {


        // Global Variables
        Adm_AtencionMedica adm = Adm_AtencionMedica.GetAdm ();
        DateTime fecha;
        string hora;
        string paciente;
        int index;
        public int buscarGlobal;
        //bool firstTime;


        public Frm_AtencionMedica_Buscar_ROPB (string nombre) {
            InitializeComponent ();
            // Ejecuciones al inicar el formulario.
            buscarGlobal = 0;
            adm.LlenarComboPacienteAutomatico (dtp_Fecha, cmb_Hora, cmb_Paciente, 2);
            adm.LlenarComboHoraAutomatico (dtp_Fecha, cmb_Hora, 2);
            adm.LlenarTablaAntencionMedica (dgv_AntencionMedica, lbl_Total);
            btn_Reporte.Enabled = true;
            HistoriaClinica (nombre);
        }

        private void HistoriaClinica (string nombre) {
            if (nombre != "") {
                rdb_No.Checked = true;
                cmb_Paciente.SelectedItem = nombre;
                buscarGlobal = 2;   // 2: btn_Buscar_PacienteHora
                adm.LlenarTablaAntencionMedicaBuscar (dgv_AntencionMedica, lbl_Total, cmb_Paciente, dtp_Fecha, cmb_Hora, buscarGlobal);
                if (adm.ContarListaBuscar () > 0) {
                    AutoSeleccionFilaDefault ();
                    HabilitarCampos ();
                } else {
                    DeshabilitarCampos ();
                }
            } else {
                AutoSeleccionFilaDefault ();
            }
        }

        // Method: AutoSeleccionFilaDefault
        private void AutoSeleccionFilaDefault () {
            // Almacena los valores de la primera fila
            paciente = dgv_AntencionMedica.Rows [0].Cells ["col_Paciente"].Value.ToString ();
            hora = dgv_AntencionMedica.Rows [0].Cells ["col_Hora"].Value.ToString ();
            fecha = Convert.ToDateTime (dgv_AntencionMedica.Rows [0].Cells ["col_Fecha"].Value.ToString ());
        }

        // Method: HabilitarCampos
        private void HabilitarCampos () {
            btn_Reporte.Enabled = true;
            btn_Editar.Enabled = true;
            btn_Eliminar.Enabled = true;
        }

        // Method: DeshabilitarCampos
        private void DeshabilitarCampos () {
            btn_Reporte.Enabled = false;
            btn_Editar.Enabled = false;
            btn_Eliminar.Enabled = false;
        }

        private void rdb_Si_CheckedChanged (object sender, EventArgs e) {
            if (rdb_Si.Checked == true) {
                dtp_Fecha.Enabled = true;
            } else {
                dtp_Fecha.Enabled = false;
            }
        }

        public void btn_Buscar_Click (object sender, EventArgs e) {
            // Buscar datps por Nombre y hora, e/y/o/u fecha
            if (rdb_Si.Checked == true) {
                buscarGlobal = 1;   // 1: btn_Buscar
            } else {
                buscarGlobal = 2;   // 2: btn_Buscar_PacienteHora
            }
            adm.LlenarTablaAntencionMedicaBuscar (dgv_AntencionMedica, lbl_Total, cmb_Paciente, dtp_Fecha, cmb_Hora, buscarGlobal);
            if (adm.ContarListaBuscar () > 0) {
                AutoSeleccionFilaDefault ();
                HabilitarCampos ();
            } else {
                DeshabilitarCampos ();
            }
        }

        public void btn_Limpiar_Click (object sender, EventArgs e) {
            // Limpiar campos y reicio de datos del DataGridView
            cmb_Paciente.SelectedIndex = 0;
            cmb_Hora.SelectedIndex = 0;
            dtp_Fecha.Value = DateTime.Now;
            adm.LlenarTablaAntencionMedica (dgv_AntencionMedica, lbl_Total);
            buscarGlobal = 0;
            if (adm.ContarListaBuscar () > 0) {
                AutoSeleccionFilaDefault ();
                HabilitarCampos ();
            } else {
                DeshabilitarCampos ();
            }
        }

        private void dgv_AntencionMedica_CellClick (object sender, DataGridViewCellEventArgs e) {
            // Selección datos en base a índices
            if (e.RowIndex >= 0) {
                index = e.RowIndex;
                DataGridViewRow row = this.dgv_AntencionMedica.Rows [e.RowIndex];
                fecha = Convert.ToDateTime (row.Cells ["col_Fecha"].Value.ToString ());
                hora = row.Cells ["col_Hora"].Value.ToString ();
                paciente = row.Cells ["col_Paciente"].Value.ToString ();
                //Console.WriteLine (paciente + " | " + hora + " | " + fecha + "\n");
            }
        }

        private void btn_Editar_Click (object sender, EventArgs e) {
            // Abrir formulario: Editar
            if (index >= 0 && dgv_AntencionMedica.Rows != null && dgv_AntencionMedica.Rows.Count != 0) {
                //Console.WriteLine (paciente + " | " + hora + " | " + fecha + "\n");
                Frm_AtencionMedica_Editar_ROPB frm = new Frm_AtencionMedica_Editar_ROPB (fecha, hora, paciente, this);
                frm.ShowDialog ();
            } else {
                MessageBox.Show ("NO se ha selecionado datos.", "ERROR!");
            }
        }

        private void btn_Eliminar_Click (object sender, EventArgs e) {
            // Abrir formulario: Eliminar
            if (index >= 0 && dgv_AntencionMedica.Rows != null && dgv_AntencionMedica.Rows.Count != 0) {
                //Console.WriteLine (paciente + " | " + hora + " | " + fecha + "\n");
                Frm_AtencionMedica_Eliminar_ROPB frm = new Frm_AtencionMedica_Eliminar_ROPB (fecha, hora, paciente, this);
                frm.ShowDialog ();
            } else {
                MessageBox.Show ("NO se ha selecionado datos.", "ERROR!");
            }
        }

        private void btn_Reporte_Click (object sender, EventArgs e) {
           
            adm.CrearReportePDF (cmb_Paciente, dtp_Fecha, cmb_Hora, buscarGlobal);
            

        }


    }
}
