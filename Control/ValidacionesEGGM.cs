using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Control
{
    public class ValidacionesEGGM
    {

        internal int AEntero(string entrada)
        {
            int x = 0;
            try
            {
                x = Convert.ToInt32(entrada);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error:Se espera un número entero");
            }
            return x;
        }

        internal bool EsReal(string monto)
        {
            bool bandera = true;
            double x = 0.0;
            try
            {
                x = Convert.ToDouble(monto);
                bandera = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error: se espera un número real");
                bandera = false;
            }
            return bandera;
        }

        internal double AReal(string entrada)
        {
            double x = 0;
            try
            {
                x = Convert.ToInt32(entrada);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error: se espera un número real");
            }
            return x;
        }
    }
}
