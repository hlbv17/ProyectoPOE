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
    public partial class Frm_Odontologo_Editar : Form {
        
        Adm_Horario admhorario = Adm_Horario.GetAdm ();
        Adm_Odontologo admodo = Adm_Odontologo.GetAdm ();
        public string cedula;
        
        public Frm_Odontologo_Editar () {
            InitializeComponent ();
        }

        private void btnGuardar_Click (object sender, EventArgs e) {
            string nombre = textNombre.Text.Trim (), cedula = txtCedula.Text.Trim (), correo = txtCorreo.Text.Trim (), telefono = txtTelefono.Text.Trim (), especialidad = cmbEspecialidad.Text;

            int consultorio = Convert.ToInt32 (cmbConsultorio.Text);
            int w = Convert.ToInt32 (idodo.Text);
            DateTime fechaNac = dateTimePicker1.Value.Date;
            char sexo = Convert.ToChar (cmbSexo.Text);
           

            try {
                admodo.guardarActualizar (w, nombre, cedula, especialidad, sexo, fechaNac, correo, telefono, consultorio, admhorario.HorarioOdont [0]);

                MessageBox.Show (admodo.mostrardatos (), "DATOS GUARDADOS");
            } catch (Exception ex) {
                MessageBox.Show ("DEBE INGRESAR TODOS LO DATOS: " + ex);
            }

        }

        private void btnSeleccionar_Click (object sender, EventArgs e) {

            Frm_Odontologo_Horario frm = new Frm_Odontologo_Horario ();
            frm.ShowDialog ();
            admhorario.LlenarGriDE (dgvHorarioOdontologo);
        }

        private void FrmActualizarOdontologo_Load (object sender, EventArgs e) {
            txtCedula.Text = cedula;
            admodo.consultarOdoParaActualizar (txtCedula.Text.Trim (), txtCedula, textNombre, txtCorreo, txtTelefono, cmbConsultorio, cmbEspecialidad, cmbSexo, dateTimePicker1, dgvHorarioOdontologo, idodo);
        }

        private void textNombre_KeyPress (object sender, KeyPressEventArgs e) {
            char c = e.KeyChar;
            if (!char.IsLetter (c) && c != ' ' && (e.KeyChar != Convert.ToChar (Keys.Back))) {
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress (object sender, KeyPressEventArgs e) {
            char c = e.KeyChar;
            if (!char.IsDigit (c) && (e.KeyChar != Convert.ToChar (Keys.Back))) {
                e.Handled = true;
                return;
            }
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsLetter(c) && !char.IsDigit(c) && (e.KeyChar != Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
