using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    abstract class Persona {
        private string cedula;
        private string nombre;
        private char sexo;
        private DateTime fechanac;

        public Persona()
        {
        }

        public Persona(string cedula, string nombre, char sexo, DateTime fechanac)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.sexo = sexo;
            this.fechanac = fechanac;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public char Sexo { get => sexo; set => sexo = value; }
        public DateTime Fechanac { get => fechanac; set => fechanac = value; }
        public string Cedula { get => cedula; set => cedula = value; }

        public override string ToString()
        {
            return "\nCedula: "+ cedula+"\nNombre: " + nombre + "\nFecha Nacimiento: " + fechanac +
                "\nSexo: " + sexo;
        }


    }
}
