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
        ConexionEGGM con = new Datos.ConexionEGGM();
        public void Conectar()
        {

            string mensaje =
            mensaje = con.conectar();
            if (mensaje[0] == '1')
                MessageBox.Show("Conexión satisfactoria!");
            else
                MessageBox.Show("Error: " + mensaje);
            con.cerrar();

        }
    }
}
