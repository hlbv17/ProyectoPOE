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
    public partial class FrmActualizarOdontologo : Form
    {
        AdmHorarioEGGM admhorario = AdmHorarioEGGM.GetAdm();
        AdmOdontologoEGGM admodo = AdmOdontologoEGGM.GetAdm();
        public string cedula;
        public FrmActualizarOdontologo()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            try
            {
                string nombre = textNombre.Text.Trim(), cedula = txtCedula.Text.Trim(), correo = txtCorreo.Text.Trim(), telefono = txtTelefono.Text.Trim(), especialidad = cmbEspecialidad.Text;
                char sexo = Convert.ToChar(cmbSexo.Text);
                int consultorio = Convert.ToInt32(cmbConsultorio.Text);
                int w = Convert.ToInt32(idodo.Text);
                DateTime fechaNac = dateTimePicker1.Value.Date;

                admodo.guardarActualizar(w, nombre, cedula, especialidad, sexo, fechaNac, correo, telefono, consultorio, admhorario.HorarioOdont[1]);
                MessageBox.Show(admodo.mostrardatos(), "DATOS GUARDADOS");
            }
            catch (Exception ex)
            {
                MessageBox.Show("DEBE INGRESAR TODOS LO DATOS");
            }

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            
            FrmHorarioEGGM frm = new FrmHorarioEGGM();
            frm.ShowDialog();
            admhorario.LlenarGriDE(dgvHorarioOdontologo);
        }

        private void FrmActualizarOdontologo_Load(object sender, EventArgs e)
        {
            txtCedula.Text = cedula;
            admodo.consultarOdoParaActualizar(txtCedula.Text.Trim(), txtCedula, textNombre, txtCorreo, txtTelefono, cmbConsultorio, cmbEspecialidad, cmbSexo, dateTimePicker1, dgvHorarioOdontologo, idodo);
        }

        private void textNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsLetter(c) && c != ',' && (e.KeyChar != Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) && (e.KeyChar != Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
