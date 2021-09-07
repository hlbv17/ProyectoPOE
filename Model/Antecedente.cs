using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proyecto_Dentalig {
    public class Antecedente {

        // Variables
        private string antecedenteFam;
        private string antecedenteper;
        private long id_antecedente;



        public string AntecedenteFam { get => antecedenteFam; set => antecedenteFam = value; }
        public string Antecedenteper { get => antecedenteper; set => antecedenteper = value; }
        public long Id_antecedente { get => id_antecedente; set => id_antecedente = value; }

        public Antecedente()
        {
            this.antecedenteFam = "";
            this.antecedenteper = "";
        }

        // Constructor: Parameterized

        public Antecedente(string antecedenteFam, string antecedenteper)
        {
            this.antecedenteFam = antecedenteFam;
            this.antecedenteper = antecedenteper;
        }

        // Method: ToString
        public override string ToString () {
            return
                "\r\nAntecedente Familiar: " + antecedenteFam +
                "\r\nAntecedente Personal: " + antecedenteper;
        }

    }
}
