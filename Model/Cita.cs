using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proyecto_Dentalig {
    public class Cita {

        // Variables
        private int id_cita;
        private Paciente paciente;
        private Odontologo odontologo;
        private DateTime fecha;
        private DateTime hora;

        public Cita () {
            this.id_cita = 0;
            this.paciente = new Paciente ();
            this.odontologo = new Odontologo ();
            this.fecha = new DateTime ();
            this.hora = new DateTime ();
        }

        public Cita (int id_cita, Paciente paciente, Odontologo odontologo, DateTime fecha, DateTime hora) {
            this.id_cita = id_cita;
            this.paciente = paciente;
            this.odontologo = odontologo;
            this.fecha = fecha;
            this.hora = hora;
        }

        public int Id_cita { get => id_cita; set => id_cita = value; }
        public Paciente Paciente { get => paciente; set => paciente = value; }
        public Odontologo Odontologo { get => odontologo; set => odontologo = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public DateTime Hora { get => hora; set => hora = value; }

        public override string ToString () {
            return
                "\r\nCédula: " + paciente.Cedula +
                "\r\nPaciente: " + paciente.Nombre +
                "\r\nOdontólogo: " + odontologo.Nombre +
                "\r\nFecha: " + fecha.ToString ("yyyy-MM-dd") +
                "\r\nHora: " + hora.ToString ("HH:mm:ss") +
                "\r\nConsultorio: " + odontologo.Consultorio;
        }
    }
}
