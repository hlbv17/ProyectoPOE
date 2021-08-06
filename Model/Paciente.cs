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

        public Paciente()
        {
        }

        public Paciente(string cedula, string nombre, char sexo, DateTime fechanac, int edad, string estadoBucal, Antecedente antecedente) : base(cedula, nombre, sexo, fechanac)
        {
            this.edad = edad;
            this.estadoBucal = estadoBucal;
            this.antecedente = antecedente;
        }


        public int Edad { get => edad; set => edad = value; }
        public string EstadoBucal { get => estadoBucal; set => estadoBucal = value; }
        public Antecedente Antecedente { get => antecedente; set => antecedente = value; }

        public override String ToString(){ //Return of data
            return base.ToString() +
                    "\nEdad: " + edad +
                    "\nEstado bucal: " + estadoBucal +
                    "\n-Antecedente-" + antecedente.ToString();
        }

    }
}
