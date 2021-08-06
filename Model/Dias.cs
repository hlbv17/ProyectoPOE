using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proyecto_Dentalig {
    class Dias {

        private string dia;
        private DateTime horaEntrada;
        private DateTime horaSalida;

        public Dias () {
            this.dia = "";
            this.horaEntrada = DateTime.Now;
            this.horaSalida = DateTime.Now;
        }

        public Dias (string dia, DateTime horaEntrada, DateTime horaSalida) {
            this.dia = dia;
            this.horaEntrada = horaEntrada;
            this.horaSalida = horaSalida;
        }

        public string Dia { get => dia; set => dia = value; }
        public DateTime HoraEntrada { get => horaEntrada; set => horaEntrada = value; }
        public DateTime HoraSalida { get => horaSalida; set => horaSalida = value; }

        public override string ToString () {
            return
                "\r\nDia: " + dia +
                "\r\nHora de Entrada:" + horaEntrada +
                "\r\nHora de Salida: " + horaSalida;
        }

    }
}
