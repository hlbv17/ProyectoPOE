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
    public partial class FrmIngresoHisClinicaVLRS : Form
    {
        Adm_HistoriaClinicaVLRS admPac = Adm_HistoriaClinicaVLRS.GetAdm();
        Validacion val = new Validacion();
        public FrmIngresoHisClinicaVLRS()
        {
            InitializeComponent();
        }


        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text.Trim(), nombre = txtNombre.Text.Trim(), sexo = cmbSexo.Text,
            telefono = txtTelefono.Text.Trim(), correo = txtCorreo.Text.Trim(), discapacidad = cmbDiscapacidad.Text,
            APersonales = txtAntecPers.Text.Trim(), AFamiliares = txtAntecFam.Text.Trim();
            DateTime fechaNac = dtpFNacimiento.Value.Date;
            if (val.is_validate(errorP, txtCorreo, txtNombre, txtCedula, txtTelefono, txtAntecPers, txtAntecFam, cmbDiscapacidad, cmbSexo,
                dtpFNacimiento) && val.validarEmail(correo) && !admPac.CedulaUnica(cedula)
                && admPac.EsCorrecto(cedula, nombre, sexo, telefono, correo, discapacidad, APersonales, AFamiliares, fechaNac, errorP,
                btnGuardar))
            {
                errorP.Clear();
                admPac.Guardar(cedula, nombre, sexo, telefono, correo, discapacidad, APersonales, AFamiliares, fechaNac, 1);
                admPac.Agregar(txtPresentar);
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) && (e.KeyChar != Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsLetter(c) && !char.IsDigit(c) && c != '@' && c != '.' && c != '-' && c != '_' && (e.KeyChar != Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsLetter(c) && c != ' ' && (e.KeyChar != Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
