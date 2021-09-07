using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Control
{
    public class ValidacionesVLRS
    {
        public Char AChar(string sexo)
        {
            char x = ' ';
            try
            {
                x = Convert.ToChar(sexo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return x;
        }

        public bool validarEmail(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            return Regex.IsMatch(email, expresion);
        }

        public bool is_validate(ErrorProvider errorP, TextBox txtCorreo, TextBox txtNombre, TextBox txtCedula, TextBox txtTelefono, TextBox txtAntecPers,
            TextBox txtAntecFam, ComboBox cmbDiscapacidad, ComboBox cmbSexo, DateTimePicker dtpFNacimiento)
        {
            bool no_error = true;
            string correo = txtCorreo.Text.Trim();
            if (txtNombre.Text == string.Empty)
            {
                errorP.Clear();
                errorP.SetError(txtNombre, "Ingrese su nombre");
                no_error = false;
            }
            if (txtCedula.Text == string.Empty || (txtCedula.Text.Length < 10))
            {
                errorP.Clear();
                errorP.SetError(txtCedula, "Ingrese su cedula, debe tener 10 digitos");
                no_error = false;
            }
            if (txtCorreo.Text == string.Empty)
            {
                errorP.Clear();
                errorP.SetError(txtCorreo, "Ingrese su correo");
                no_error = false;
            }
            if (!(validarEmail(correo)))
            {
                errorP.Clear();
                errorP.SetError(txtCorreo, "Ingrese un correo correcto, nombre@dominio.com");
                no_error = false;
            }
            if (txtTelefono.Text == string.Empty || (txtTelefono.Text.Length < 10))
            {
                errorP.Clear();
                errorP.SetError(txtTelefono, "Ingrese su telefono, debe tener 10 digitos");
                no_error = false;
            }
            if (txtAntecPers.Text == string.Empty)
            {
                errorP.Clear();
                errorP.SetError(txtAntecPers, "Si no hay Antecedentes, escriba ninguno");
                no_error = false;
            }
            if (txtAntecFam.Text == string.Empty)
            {
                errorP.Clear();
                errorP.SetError(txtAntecFam, "Si no hay Antecedentes, escriba ninguno");
                no_error = false;
            }
            if (cmbDiscapacidad.SelectedItem == null)
            {
                errorP.Clear();
                errorP.SetError(cmbDiscapacidad, "Escoja una opcion");
                no_error = false;
            }
            if (cmbSexo.SelectedItem == null)
            {
                errorP.Clear();
                errorP.SetError(cmbSexo, "Escoja una opcion");
                no_error = false;
            }
            if (dtpFNacimiento.Value == null)
            {
                errorP.Clear();
                errorP.SetError(dtpFNacimiento, "Escoja una opcion");
                no_error = false;
            }
            if (dtpFNacimiento.Value > DateTime.Now)
            {
                errorP.Clear();
                errorP.SetError(dtpFNacimiento, "No puede escoger una fecha mayor a la de hoy");
                no_error = false;
            }
            return no_error;
        }


        public bool ValidarFiltro(ErrorProvider errorProvider1, ComboBox cmbFiltro, TextBox txtCedula, ComboBox cmbSexo, DateTimePicker dtpFnac1, DateTimePicker dtpFnac2, int rbindex)
        {
            bool no_error = true;
            if (cmbFiltro.SelectedIndex == 0)
            {
                if (txtCedula.Text == string.Empty || (txtCedula.Text.Length < 10))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtCedula, "Ingrese su cedula, debe tener 10 digitos");
                    no_error = false;
                }
            }
            if (cmbFiltro.SelectedIndex == 1 && rbindex == 2)
            {
                if (cmbSexo.SelectedItem == null)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(cmbSexo, "Escoja un sexo");
                    no_error = false;
                }
            }
            if (cmbFiltro.SelectedIndex == 1 && rbindex == 3)
            {
                if (dtpFnac1.Value > DateTime.Now)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(dtpFnac1, "No puede escoger una fecha mayor a la de hoy");
                    no_error = false;
                }
                if (dtpFnac2.Value > DateTime.Now)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(dtpFnac2, "No puede escoger una fecha mayor a la de hoy");
                    no_error = false;
                }
            }
            if (cmbFiltro.SelectedIndex == 1 && rbindex == 4)
            {
                if (cmbSexo.SelectedItem == null)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(cmbSexo, "Escoja un sexo");
                    no_error = false;
                }
                if (dtpFnac1.Value > DateTime.Now)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(dtpFnac1, "No puede escoger una fecha mayor a la de hoy");
                    no_error = false;
                }
                if (dtpFnac2.Value > DateTime.Now)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(dtpFnac2, "No puede escoger una fecha mayor a la de hoy");
                    no_error = false;
                }
            }

            return no_error;
        }

    }
}
