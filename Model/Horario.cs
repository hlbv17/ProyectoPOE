using Proyecto_Dentalig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {

    public class Horario {

        private List<Dias> dias;

        public Horario () {
            this.dias = null;
        }

        public Horario (List<Dias> dias) {
            this.dias = dias;
        }

        public List<Dias> Dias { get => dias; set => dias = value; }

        public override string ToString () {
            return base.ToString ();
        }
    }
}
