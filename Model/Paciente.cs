using Model;
using Proyecto_Dentalig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    public class Paciente : Persona,IPaciente {

        // Variables
        private string discapacidad;

        // Constructor: default
        public Paciente () : base () {
            this.discapacidad = "";
        }

        // Constructor: parameterized
        public Paciente(string discapacidad, string cedula, char sexo, string nombre, DateTime fechaNacimiento, string telefono, string correo) : base(cedula, sexo, nombre, fechaNacimiento, telefono, correo)
        {
            this.discapacidad = discapacidad;
        }

        public string Discapacidad { get => discapacidad; set => discapacidad = value; }    // Getter & Setter: discapacidad

        public string CategoriaEdad()
        {
            string categoria_edad = "";
            int edad = base.LeerEdad();

            if (edad>=0 && edad <= 1 ) {
                categoria_edad = "bebé";
            }else if (edad > 1 && edad <= 12) {
                categoria_edad = "niño";
            }else if (edad > 12 && edad <= 18){
                categoria_edad = "adolescente";
            }else if (edad > 18 && edad <= 25){
                categoria_edad = "adulto joven";
            }else if (edad > 25 && edad <= 65){
                categoria_edad = "adulto";
            }else if (edad > 65 && edad <= 80){
                categoria_edad = "adulto mayor";
            }else if (edad > 80 && edad <= 130){
                categoria_edad = "anciano";
            }
            return categoria_edad;
        }

        // Method: ToString
        public override string ToString () {
            return base.ToString () + 
                "\r\nDiscapacidad: " + discapacidad+
                "\r\nCategoria Edad: " + CategoriaEdad();
        }

        
    }
}
