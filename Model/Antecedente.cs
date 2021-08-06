using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    class Antecedente {
                private string Cod_Antecedente;
        private string nAntecedente;
        private string Descripcion;


        public Antecedente()
        {
        }

        public Antecedente(string cod_Antecedente, string nAntecedente, string descripcion)
        {
            Cod_Antecedente = cod_Antecedente;
            this.nAntecedente = nAntecedente;
            Descripcion = descripcion;
        }

        public string Cod_Antecedente1 { get => Cod_Antecedente; set => Cod_Antecedente = value; }
        public string NAntecedente { get => nAntecedente; set => nAntecedente = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }

        public override String ToString()
        {
            return "\nAntecedente: " + nAntecedente +
                    "\nDescripcion: " + Descripcion;
        }
       
    }
}
