using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    abstract class Persona {

        // Variables
        private string cedula;
        private char sexo;
        private string nombre;
        private DateTime fechaNacimiento;

        // Constructor: defautl
        public Persona () {
            this.cedula = "";
            this.sexo = ' ';
            this.nombre = "";
            this.fechaNacimiento = DateTime.Now;
        }

        // Constructor: parameterized
        protected Persona (string cedula, char sexo, string nombre, DateTime fechaNacimiento) {
            this.cedula = cedula;
            this.sexo = sexo;
            this.nombre = nombre;
            this.fechaNacimiento = fechaNacimiento;
        }

        public string Cedula { get => cedula; set => cedula = value; }                              // Getter & Setter: cedula
        public char Sexo { get => sexo; set => sexo = value; }                                      // Getter & Setter: sexo
        public string Nombre { get => nombre; set => nombre = value; }                              // Getter & Setter: nombre
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; } // Getter & Setter: fechaNacimiento


        // Method: LeerEdad
        public int LeerEdad () {
            int output = 0;
            // ¿?
            output = (int)Math.Round ((DateTime.Now.Date - fechaNacimiento.Date).TotalDays, MidpointRounding.AwayFromZero);
            output = output / 365;
            return output;
        }

        // Method: Leersexo
        public string LeerSexo () {
            String output = "";
            if (sexo == 'F') {
                output = "Femenino";
            } else if (sexo == 'M') {
                output = "Masculino";
            }
            return output;
        }
        
        // Method: ToString
        public override string ToString () {
            return
                "\r\nSexo: " + LeerSexo () +
                "\r\nNombre: " + nombre +
                "\r\nFecha de nacimiento: " + fechaNacimiento+
                "\r\nEdad: " + LeerEdad ();
        }

    }
}
