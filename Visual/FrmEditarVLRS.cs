using Control;
using Datos;
using Model;
using System;
using System.Windows.Forms;

namespace Visual
{
    public partial class FrmEditarVLRS : Form
    {
        Adm_HistoriaClinicaVLRS admHisclin = Adm_HistoriaClinicaVLRS.GetAdm();
        Validacion val = new Validacion();
        DatosHistoriaClinicaVLRS datosHistClin = new DatosHistoriaClinicaVLRS();
        HistoriaClinica hisclinic = null;

        public FrmEditarVLRS()
        {
            InitializeComponent();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedulaAct.Text.Trim(), nombre = txtNombreact.Text.Trim(), sexo = cmbSexoAct.Text,
                   telefono = txtTelefonoAct.Text.Trim(), correo = txtCorreoAct.Text.Trim(), discapacidad = cmbDiscAct.Text,
                   APersonales = txtAntPersAct.Text.Trim(), AFamiliares = txtAntFamAct.Text.Trim();
            DateTime fechaNac = dtpFnaciAct.Value.Date;
            if (val.is_validate(errorP, txtCorreoAct, txtNombreact, txtCedulaAct, txtTelefonoAct, txtAntPersAct, txtAntFamAct, cmbDiscAct,
                cmbSexoAct, dtpFnaciAct) && val.validarEmail(correo) && admHisclin.EsCorrecto(cedula, nombre, sexo, telefono, correo,
                discapacidad, APersonales, AFamiliares, fechaNac, errorP, btnEditar))
            {
                errorP.Clear();
                admHisclin.Guardar(cedula, nombre, sexo, telefono, correo, discapacidad, APersonales, AFamiliares, fechaNac, 2);
                admHisclin.Agregar(txtPresentar);

            }
        }
        public void LlenarFormulario(string cedula)
        {
            admHisclin.LlenarFormulario(cedula, txtNombre, txtNombreact, cmbSexo, cmbSexoAct, dtpFNacimiento, dtpFnaciAct, txtTelefono, txtTelefonoAct,
                txtCorreo, txtCorreoAct, cmbDiscapacidad, cmbDiscAct, txtAntecPers, txtAntPersAct, txtAntecFam, txtAntFamAct, txtCedulaAct, txtCedula);
        }
    }

    }

