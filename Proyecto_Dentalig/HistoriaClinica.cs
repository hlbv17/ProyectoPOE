using System;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class HistoriaClinica
    {
        private string numero;
        private PiezaDental[] dientes;
        private Paciente paciente;

        public HistoriaClinica()
        {     
            numero = "";
            dientes = new PiezaDental[1];
            paciente = new Paciente();
        }

        public HistoriaClinica(string numero, PiezaDental[] dientes, Paciente paciente)
        {
            this.numero = numero;
            this.dientes = dientes;
            this.paciente = paciente;
        }

        public string Numero { get => numero; set => numero = value; }
        internal PiezaDental[] Dientes { get => dientes; set => dientes = value; }
        internal Paciente Paciente { get => paciente; set => paciente = value; }

        public string VerDientes()
        {
            string salida = "";
            for (int i = 0; i < dientes.Length; i++)
            {
                salida += dientes[i].ToString();
            }
            return salida;
        }

        public override string ToString()
        {
            return "\r\nNro. de Historia Clínica: " + numero +"\r\n" + Paciente.ToString() +
                    "\r\n" + VerDientes();
        }
    }
}
