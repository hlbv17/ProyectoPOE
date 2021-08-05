using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    abstract class Persona {
        private char sexo;
        private string nombre;
        private DateTime fechaNac;

        public Persona () {
            this.sexo = ' ';
            this.nombre = "";
            this.fechaNac = DateTime.Now;
        }

        public char Sexo { get => sexo; set => sexo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }

        public string leerSexo () {
            return "";
        }

        public override string ToString () {
            return base.ToString ();
        }


    }
}
