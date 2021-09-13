using Datos;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Control
{
    public class AdmPacienteHLBV
    {
        List<Paciente> pacientes = new List<Paciente>();
        DatosPacienteVLRS datosPa = new DatosPacienteVLRS();
        Paciente paciente = null;

        public void ConsultarPacientes(string cedula, Label lblNombre)
        {
            if (!String.IsNullOrEmpty(cedula))
                paciente = datosPa.ConsultarPacienteNombre(cedula);
            if (paciente != null)
            {
                lblNombre.Text = paciente.Nombre;
            }
            else
            {
                lblNombre.Text = "______________";
                MessageBox.Show("No existe un paciente con esa cédula");
            }
        }
    }
}
