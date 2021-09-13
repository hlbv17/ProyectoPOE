using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Control {
    public class Validacion_ROPB {


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


    }
}
