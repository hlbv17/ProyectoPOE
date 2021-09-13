using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Control {
    public class Validacion {

        /*----------------------------------------ROPB------------------------------------------------------*/

        // Method: EsCorrectoGuardar
        public bool EsCorrectoGuardar (DateTimePicker dtp_Fecha, ComboBox cmb_Hora, ComboBox cmb_Paciente, ComboBox cmb_CuadrantePieza, ComboBox cmb_NombrePieza, TextBox txt_MotivoConsulta, TextBox txt_Diagnostico, ErrorProvider errorProvider1) {
            bool output = true;
            if (dtp_Fecha == null) {
                errorProvider1.SetError (dtp_Fecha, "Campo obligatorio.");
                output = false;
            }
            if (cmb_Hora.SelectedIndex == 0) {
                errorProvider1.SetError (cmb_Hora, "Campo obligatorio.");
                output = false;
            }
            if (cmb_Paciente.SelectedIndex == 0) {
                errorProvider1.SetError (cmb_Paciente, "Campo obligatorio.");
                output = false;
            }
            if (cmb_CuadrantePieza.SelectedIndex == 0) {
                errorProvider1.SetError (cmb_CuadrantePieza, "Campo obligatorio.");
                output = false;
            }
            if (cmb_NombrePieza.SelectedIndex == 0) {
                errorProvider1.SetError (cmb_NombrePieza, "Campo obligatorio.");
                output = false;
            }
            if (txt_MotivoConsulta.Text == "") {
                errorProvider1.SetError (txt_MotivoConsulta, "Campo obligatorio.");
                output = false;
            }
            if (txt_Diagnostico.Text == "") {
                errorProvider1.SetError (txt_Diagnostico, "Campo obligatorio.");
                output = false;
            }
            return output;
        }

        // Method: EsCorrectoGuardarEditar
        public bool EsCorrectoGuardarEditar (ComboBox cmb_CuadrantePieza, ComboBox cmb_NombrePieza, TextBox txt_MotivoConsulta, TextBox txt_Diagnostico, ComboBox cmb_CuadrantePieza_Editar, ComboBox cmb_NombrePieza_Editar, TextBox txt_MotivoConsulta_Editar, TextBox txt_Diagnostico_Editar, ErrorProvider errorProvider1) {
            bool output = true;
            if (cmb_CuadrantePieza.SelectedIndex == 0 && cmb_NombrePieza.SelectedIndex == 0) {
                MessageBox.Show ("No ha selecionado datos a modificar.", "ERROR!");
                output = false;
            } else {
                if (cmb_CuadrantePieza_Editar.SelectedIndex == 0) {
                    errorProvider1.SetError (cmb_CuadrantePieza_Editar, "Campo obligatorio.");
                    output = false;
                }
                if (cmb_NombrePieza_Editar.SelectedIndex == 0) {
                    errorProvider1.SetError (cmb_NombrePieza_Editar, "Campo obligatorio.");
                    output = false;
                }
                if (txt_MotivoConsulta_Editar.Text == "") {
                    errorProvider1.SetError (txt_MotivoConsulta_Editar, "Campo obligatorio.");
                    output = false;
                }
                if (txt_Diagnostico_Editar.Text == "") {
                    errorProvider1.SetError (txt_Diagnostico_Editar, "Campo obligatorio.");
                    output = false;
                }
            }
            return output;
        }

        // Method: EsCorrectoEliminar
        public bool EsCorrectoEliminar (ComboBox cmb_CuadrantePieza, ComboBox cmb_NombrePieza, TextBox txt_MotivoConsulta, TextBox txt_Diagnostico) {
            bool output = true;
            if (cmb_CuadrantePieza.SelectedIndex == 0 && cmb_NombrePieza.SelectedIndex == 0 && txt_MotivoConsulta.Text == "" && txt_Diagnostico.Text == "") {
                MessageBox.Show ("NO hay datos a borrar.", "ERROR!");
                output = false;
            }
            return output;
        }

        /*----------------------------------------EGGM------------------------------------------------------*/
        
        //
        internal int AEntero (string entrada) {
            int x = 0;
            try {
                x = Convert.ToInt32 (entrada);
            } catch (Exception ex) {
                Console.WriteLine (ex.Message);
                MessageBox.Show ("Error:Se espera un número entero");
            }
            return x;
        }

        //
        internal bool EsReal (string monto) {
            bool bandera = true;
            double x = 0.0;
            try {
                x = Convert.ToDouble (monto);
                bandera = true;
            } catch (Exception ex) {
                Console.WriteLine (ex.Message);
                MessageBox.Show ("Error: se espera un número real");
                bandera = false;
            }
            return bandera;
        }

        //
        internal double AReal (string entrada) {
            double x = 0;
            try {
                x = Convert.ToInt32 (entrada);
            } catch (Exception ex) {
                Console.WriteLine (ex.Message);
                MessageBox.Show ("Error: se espera un número real");
            }
            return x;
        }

        /*----------------------------------------VLRS------------------------------------------------------*/

        //
        public Char AChar (string sexo) {
            char x = ' ';
            try {
                x = Convert.ToChar (sexo);
            } catch (Exception ex) {
                Console.WriteLine (ex.Message);
            }
            return x;
        }

        public bool validarEmail (String email) {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            return Regex.IsMatch (email, expresion);
        }

        //
        public bool is_validate (ErrorProvider errorP, TextBox txtCorreo, TextBox txtNombre, TextBox txtCedula, TextBox txtTelefono, TextBox txtAntecPers,
            TextBox txtAntecFam, ComboBox cmbDiscapacidad, ComboBox cmbSexo, DateTimePicker dtpFNacimiento) {
            bool no_error = true;
            string correo = txtCorreo.Text.Trim ();
            if (txtNombre.Text == string.Empty) {
                errorP.Clear ();
                errorP.SetError (txtNombre, "Ingrese su nombre");
                no_error = false;
            }
            if (txtCedula.Text == string.Empty || (txtCedula.Text.Length < 10)) {
                errorP.Clear ();
                errorP.SetError (txtCedula, "Ingrese su cedula, debe tener 10 digitos");
                no_error = false;
            }
            if (txtCorreo.Text == string.Empty) {
                errorP.Clear ();
                errorP.SetError (txtCorreo, "Ingrese su correo");
                no_error = false;
            }
            if (!(validarEmail (correo))) {
                errorP.Clear ();
                errorP.SetError (txtCorreo, "Ingrese un correo correcto, nombre@dominio.com");
                no_error = false;
            }
            if (txtTelefono.Text == string.Empty || (txtTelefono.Text.Length < 10)) {
                errorP.Clear ();
                errorP.SetError (txtTelefono, "Ingrese su telefono, debe tener 10 digitos");
                no_error = false;
            }
            if (txtAntecPers.Text == string.Empty) {
                errorP.Clear ();
                errorP.SetError (txtAntecPers, "Si no hay Antecedentes, escriba ninguno");
                no_error = false;
            }
            if (txtAntecFam.Text == string.Empty) {
                errorP.Clear ();
                errorP.SetError (txtAntecFam, "Si no hay Antecedentes, escriba ninguno");
                no_error = false;
            }
            if (cmbDiscapacidad.SelectedItem == null) {
                errorP.Clear ();
                errorP.SetError (cmbDiscapacidad, "Escoja una opcion");
                no_error = false;
            }
            if (cmbSexo.SelectedItem == null) {
                errorP.Clear ();
                errorP.SetError (cmbSexo, "Escoja una opcion");
                no_error = false;
            }
            if (dtpFNacimiento.Value == null) {
                errorP.Clear ();
                errorP.SetError (dtpFNacimiento, "Escoja una opcion");
                no_error = false;
            }
            if (dtpFNacimiento.Value > DateTime.Now) {
                errorP.Clear ();
                errorP.SetError (dtpFNacimiento, "No puede escoger una fecha mayor a la de hoy");
                no_error = false;
            }
            return no_error;
        }

        //
        public bool ValidarFiltro (ErrorProvider errorProvider1, ComboBox cmbFiltro, TextBox txtCedula, ComboBox cmbSexo, DateTimePicker dtpFnac1, DateTimePicker dtpFnac2, int rbindex) {
            bool no_error = true;
            if (cmbFiltro.SelectedIndex == 0) {
                if (txtCedula.Text == string.Empty || (txtCedula.Text.Length < 10)) {
                    errorProvider1.Clear ();
                    errorProvider1.SetError (txtCedula, "Ingrese su cedula, debe tener 10 digitos");
                    no_error = false;
                }
            }
            if (cmbFiltro.SelectedIndex == 1 && rbindex == 2) {
                if (cmbSexo.SelectedItem == null) {
                    errorProvider1.Clear ();
                    errorProvider1.SetError (cmbSexo, "Escoja un sexo");
                    no_error = false;
                }
            }
            if (cmbFiltro.SelectedIndex == 1 && rbindex == 3) {
                if (dtpFnac1.Value > DateTime.Now) {
                    errorProvider1.Clear ();
                    errorProvider1.SetError (dtpFnac1, "No puede escoger una fecha mayor a la de hoy");
                    no_error = false;
                }
                if (dtpFnac2.Value > DateTime.Now) {
                    errorProvider1.Clear ();
                    errorProvider1.SetError (dtpFnac2, "No puede escoger una fecha mayor a la de hoy");
                    no_error = false;
                }
            }
            if (cmbFiltro.SelectedIndex == 1 && rbindex == 4) {
                if (cmbSexo.SelectedItem == null) {
                    errorProvider1.Clear ();
                    errorProvider1.SetError (cmbSexo, "Escoja un sexo");
                    no_error = false;
                }
                if (dtpFnac1.Value > DateTime.Now) {
                    errorProvider1.Clear ();
                    errorProvider1.SetError (dtpFnac1, "No puede escoger una fecha mayor a la de hoy");
                    no_error = false;
                }
                if (dtpFnac2.Value > DateTime.Now) {
                    errorProvider1.Clear ();
                    errorProvider1.SetError (dtpFnac2, "No puede escoger una fecha mayor a la de hoy");
                    no_error = false;
                }
            }
            return no_error;
        }

    }
}
