using Control;
using Datos;
using Model;
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
    public partial class FrmEditarVLRS : Form
    {
        Adm_HistoriaClinicaVLRS admPac = Adm_HistoriaClinicaVLRS.GetAdm();
        ValidacionesVLRS val = new ValidacionesVLRS();
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
                cmbSexoAct, dtpFnaciAct) && val.validarEmail(correo) && admPac.EsCorrecto(cedula, nombre, sexo, telefono, correo,
                discapacidad, APersonales, AFamiliares, fechaNac, errorP, btnEditar))
            {
                errorP.Clear();
                admPac.Guardar(cedula, nombre, sexo, telefono, correo, discapacidad, APersonales, AFamiliares, fechaNac, 2);
                admPac.Agregar(txtPresentar);
            }
        }


        public void LlenarFormulario(string cedula)
        {
            char s = ' ';
            txtCedula.Text = cedula.ToString();
            if (!String.IsNullOrEmpty(cedula))
                hisclinic = datosHistClin.ConsultarXCedula(cedula);
            if (hisclinic != null)
            {
                //formulario para visualizar datos
                txtNombre.Text = hisclinic.Paciente.Nombre;
                cmbSexo.Text = hisclinic.Paciente.LeerSexo();
                dtpFNacimiento.Value = hisclinic.Paciente.FechaNacimiento;
                txtTelefono.Text = hisclinic.Paciente.Telefono;
                txtCorreo.Text = hisclinic.Paciente.Correo;
                cmbDiscapacidad.Text = hisclinic.Paciente.Discapacidad;
                txtAntecPers.Text = hisclinic.Antecedente.Antecedenteper;
                txtAntecFam.Text = hisclinic.Antecedente.AntecedenteFam;

                //formulario para cambiar los datos
                txtCedulaAct.Text = hisclinic.Paciente.Cedula;
                txtNombreact.Text = hisclinic.Paciente.Nombre;
                cmbSexoAct.Text = hisclinic.Paciente.LeerSexo();
                dtpFnaciAct.Value = hisclinic.Paciente.FechaNacimiento;
                txtTelefonoAct.Text = hisclinic.Paciente.Telefono;
                txtCorreoAct.Text = hisclinic.Paciente.Correo;
                cmbDiscAct.Text = hisclinic.Paciente.Discapacidad;
                txtAntPersAct.Text = hisclinic.Antecedente.Antecedenteper;
                txtAntFamAct.Text = hisclinic.Antecedente.AntecedenteFam;

            }
            else
            {
                MessageBox.Show("No existe Historia Clinica con la cedula registrada asociada");
            }
        }

    }
}
