using Proyecto_Dentalig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {

    public class Horario {

        private List<Dias> dias;
        private string tipo;
   

        public Horario () {
            this.dias = null;
            this.Tipo = "";
        }

        public Horario (List<Dias> dias, string tipo) {
            this.dias = dias;
            this.Tipo = tipo;
            
        }

        public List<Dias> Dias { get => dias; set => dias = value; }
        public string Tipo { get => tipo; set => tipo = value; }

        public override string ToString () {
            return base.ToString ();
        }
    }
}
