using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class Paciente : Persona
    {
        private int edad;
        private string estadoBucal;
        private Antecedente antecedente;

        public int Edad { get => edad; set => edad = value; }
        public string EstadoBucal { get => estadoBucal; set => estadoBucal = value; }
        internal Antecedente Antecedente { get => antecedente; set => antecedente = value; }

        public override string ToString()
        {
            return "";
        }
    }
}
