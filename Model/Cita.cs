using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proyecto_Dentalig {
    public class Cita {

        // Variables
        private int id_cita;
        private DateTime fecha;
        private DateTime hora;
        private Odontologo odontologo;
        private Paciente paciente;

        // Constructor: Default
        public Cita () {
            this.id_cita = 1;
            this.fecha = DateTime.Now;
            this.hora = DateTime.Now;
            this.odontologo = null;
            this.paciente = null;
        }

        // Constructor: Parameterized
        public Cita (int id_cita, DateTime fecha, DateTime hora, Odontologo odontologo, Paciente paciente) {
            this.id_cita = id_cita;
            this.fecha = fecha;
            this.hora = hora;
            this.odontologo = odontologo;
            this.paciente = paciente;
        }

        public int Id_cita { get => id_cita; set => id_cita = value; }                  // Getter & Setter: id_cita
        public DateTime Fecha { get => fecha; set => fecha = value; }                   // Getter & Setter: fecha
        public DateTime Hora { get => hora; set => hora = value; }                      // Getter & Setter: hora
        public Odontologo Odontologo { get => odontologo; set => odontologo = value; }  // Getter & Setter: odontologo
        public Paciente Paciente { get => paciente; set => paciente = value; }          // Getter & Setter: paciente

        // Method: ToString
        public override string ToString () {
            return
                "\r\nFecha: " + fecha +
                "\r\nHora: " + hora +
                "\r\nOdontólogo: " + odontologo.Nombre +
                "\r\nPaciente: " + paciente.Nombre +
                "\r\nConsultorio: " + odontologo.Consultorio;
        }
    }
}
