using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proyecto_Dentalig {
    public class Dias {

        // Variables
        private string dia;
        private DateTime horaEntrada;
        private DateTime horaSalida;

        // Constructor: Default
        public Dias () {
            this.dia = "";
            this.horaEntrada = DateTime.Now;
            this.horaSalida = DateTime.Now;
        }

        // Constructor: Parameterized
        public Dias (string dia, DateTime horaEntrada, DateTime horaSalida) {
            this.dia = dia;
            this.horaEntrada = horaEntrada;
            this.horaSalida = horaSalida;
        }

        public string Dia { get => dia; set => dia = value; }                           // Getter & Setter: dia
        public DateTime HoraEntrada { get => horaEntrada; set => horaEntrada = value; } // Getter & Setter: horaEntrada
        public DateTime HoraSalida { get => horaSalida; set => horaSalida = value; }    // Getter & Setter: horaSalida

        // Method: ToString
        public override string ToString () {
            return
                "\r\nDia: " + dia +
                "\r\nHora de Entrada:" + horaEntrada +
                "\r\nHora de Salida: " + horaSalida;
        }

    }
}
