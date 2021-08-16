
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    public class PiezaDental {

        // Variables
        private int numeroPieza;
        private string cuadrantePieza;
        private string nombrePieza;

        // Constructor: default
        public PiezaDental () {
            this.numeroPieza = 0;
            this.cuadrantePieza = "";
            this.nombrePieza = "";
        }

        // Constructor: Parameterized
        public PiezaDental (int numeroPieza, string cuadrantePieza, string nombrePieza) {
            this.numeroPieza = numeroPieza;
            this.cuadrantePieza = cuadrantePieza;
            this.nombrePieza = nombrePieza;
        }

        public int NumeroPieza { get => numeroPieza; set => numeroPieza = value; }              // Getter & Setter: numeroPieza
        public string CuadrantePieza { get => cuadrantePieza; set => cuadrantePieza = value; }  // Getter & Setter: cuadrantePieza
        public string NombrePieza { get => nombrePieza; set => nombrePieza = value; }           // Getter & Setter: nombrePieza

        // Method: ToString
        public override string ToString () {
            return
                "\r\nNumero de Pieza:" + numeroPieza +
                "\r\nCuadrante de Pieza: " + cuadrantePieza +
                "\r\nNombre Pieza: " + nombrePieza;
        }

    }
}
