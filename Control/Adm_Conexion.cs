using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Control {
    public class Adm_Conexion {

        Conexion con = new Conexion ();

        public void Conectar () {
            string mensaje = con.Conectar ();
            if (mensaje [0] == '1')
                MessageBox.Show ("Conexión satisfactoria!");
            else
                MessageBox.Show ("Error: " + mensaje);
            con.Cerrar ();
        }

    }
}
