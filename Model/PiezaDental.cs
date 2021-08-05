using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class PiezaDental
    {
        private string nombrePieza;
        private string seccion;
        private int numero;
        private string estado;
        private string estado2;

        public PiezaDental()
        {     
            nombrePieza = "";
            seccion = "";
            numero = 0;
            estado = "";
            estado2 = "";
        }

        public PiezaDental(string nombrePieza, string seccion, int numero, string estado, string estado2)
        {
            this.nombrePieza = nombrePieza;
            this.seccion = seccion;
            this.numero = numero;
            this.estado = estado;
            this.estado2 = estado2;
        }

        public string NombrePieza { get => nombrePieza; set => nombrePieza = value; }
        public string Seccion { get => seccion; set => seccion = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Estado2 { get => estado2; set => estado2 = value; }

        public override string ToString()
        {
            return "\r\nNombre de Pieza:"+nombrePieza+ "\r\nSección: " + seccion+ 
                "\r\nNumero de pieza: " + numero + "\r\nEstado: " + estado;
        }
    }
}
