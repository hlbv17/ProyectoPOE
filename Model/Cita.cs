using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proyecto_Dentalig {
    class Cita {

        private DateTime fecha;
        private DateTime hora;
        private int consultorio;
        private Odontologo odontologo;
        private Paciente paciente;

        public Cita () {
            this.fecha = DateTime.Now;
            this.hora = DateTime.Now;
            this.consultorio = 0;
            this.odontologo = null;
            this.paciente = null;
        }

        public Cita (DateTime fecha, DateTime hora, int consultorio, Odontologo odontologo, Paciente paciente) {
            this.fecha = fecha;
            this.hora = hora;
            this.consultorio = consultorio;
            this.odontologo = odontologo;
            this.paciente = paciente;
        }

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public DateTime Hora { get => hora; set => hora = value; }
        public int Consultorio { get => consultorio; set => consultorio = value; }
        internal Odontologo Odontologo { get => odontologo; set => odontologo = value; }
        internal Paciente Paciente { get => paciente; set => paciente = value; }

        public override string ToString () {
            return
                "\r\nFecha: " + fecha +
                "\r\nHora: " + hora +
                "\r\nConsultorio: " + consultorio +
                "\r\nOdontólogo: " + odontologo.Nombre +
                "\r\nPaciente: " + paciente.Nombre;
        }

    }
}
