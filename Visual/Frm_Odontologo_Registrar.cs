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
    public partial class Frm_Odontologo_Registrar : Form
    {
        AdmHorarioEGGM admhorario = AdmHorarioEGGM.GetAdm();
        AdmOdontologoEGGM admodo = AdmOdontologoEGGM.GetAdm();
        public Frm_Odontologo_Registrar()
        {
            InitializeComponent();
        }


       
        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) && (e.KeyChar != Convert.ToChar(Keys.Back)))
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter) && txtCedula.Text.Length >= 10)
                {
                    admodo.consultarOdo(txtCedula.Text.Trim(), textNombre, txtCorreo, txtTelefono);
                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = textNombre.Text.Trim(), cedula = txtCedula.Text.Trim(), correo = txtCorreo.Text.Trim(), telefono = txtTelefono.Text.Trim(), especialidad = cmbEspecialidad.Text, mD = label5.Text;
                char sexo = Convert.ToChar(cmbSexo.Text);
                int consultorio = Convert.ToInt32(cmbConsultorio.Text);
                int w = +admodo.Contarbasedato();
                DateTime fechaNac = dateTimePicker1.Value.Date;

                admodo.guardarprueba(w, nombre, cedula, especialidad, sexo, fechaNac, correo, telefono, consultorio, admhorario.HorarioOdont[0], label5);
                MessageBox.Show(admodo.mostrardatos(), "DATOS GUARDADOS");
            }
            catch (Exception ex)
            {
                MessageBox.Show("DEBE INGRESAR TODOS LO DATOS: "+ ex);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Frm_Odontologo_Horario frm = new Frm_Odontologo_Horario();
            frm.ShowDialog();
            admhorario.LlenarGriDE(dgvHorarioOdontologo);
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
