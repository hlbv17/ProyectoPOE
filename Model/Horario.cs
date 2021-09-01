using Proyecto_Dentalig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {

    public class Horario {

        // Varialbes
        private string tipo;
        private List<Dias> dias;
        
        // Constructor: Default
        public Horario () {
            this.tipo = "";
            this.dias = new List<Dias> ();
        }

        // Constructor: Parameterized
        public Horario (List<Dias> dias, string tipo) {
            this.tipo = tipo;
            this.dias = dias;
        }

        public List<Dias> Dias { get => dias; set => dias = value; }    // Getter & Setter: dias
        public string Tipo { get => tipo; set => tipo = value; }        // Getter & Setter: tipo

        // Method: ToString
        public override string ToString () {
            return 
                "\r\nTipo: " + tipo +
                "\r\nDías: " + dias.Count;
        }
    }
}
