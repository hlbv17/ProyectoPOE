using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    class Paciente : Persona {

        // Variables
        private string discapacidad;

        // Constructor: default
        public Paciente () : base () {
            this.discapacidad = "";
        }

        // Constructor: parameterized
        public Paciente (string discapacidad, string cedula, char sexo, string nombre, DateTime fechaNacimiento) : base (cedula, sexo, nombre, fechaNacimiento) {
            this.discapacidad = discapacidad;
        }

        public string Discapacidad { get => discapacidad; set => discapacidad = value; }    // Getter & Setter: discapacidad

        // Method: ToString
        public override string ToString () {
            return base.ToString () + 
                "\r\nDiscapacidad: " + discapacidad;
        }
    }
}
