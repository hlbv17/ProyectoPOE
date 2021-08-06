using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    class PiezaDental {

        private string nombrePieza;
        private string seccion;
        private int numeroPieza;
        private string estado;

        public PiezaDental () {
            this.nombrePieza = "";
            this.seccion = "";
            this.numeroPieza = 0;
            this.estado = "";
        }

        public PiezaDental (string nombrePieza, string seccion, int numeroPieza, string estado) {
            this.nombrePieza = nombrePieza;
            this.seccion = seccion;
            this.numeroPieza = numeroPieza;
            this.estado = estado;
        }

        public string NombrePieza { get => nombrePieza; set => nombrePieza = value; }
        public string Seccion { get => seccion; set => seccion = value; }
        public int NumeroPieza { get => numeroPieza; set => numeroPieza = value; }
        public string Estado { get => estado; set => estado = value; }

        public override string ToString () {
            return
                "\r\nNompbre de Pieza: " + nombrePieza +
                "\r\nSección: " + seccion +
                "\r\nNumero de Pieza: " + numeroPieza +
                "\r\nEstado: " + estado;
        }

    }
}
