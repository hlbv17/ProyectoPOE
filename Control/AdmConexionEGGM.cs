using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Control
{
    public class AdmConexionEGGM
    {
        Conexion con = new Datos.Conexion();
        public void Conectar()
        {

            string mensaje =
            mensaje = con.Conectar();
            if (mensaje[0] == '1')
                MessageBox.Show("Conexión satisfactoria!");
            else
                MessageBox.Show("Error: " + mensaje);
            con.Cerrar();

        }
    }
}
