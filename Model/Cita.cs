using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proyecto_Dentalig {
    public class Cita {

        // Variables
        private int idCita;
        private Paciente paciente;
        private Odontologo odontologo;
        private DateTime fecha;
        private DateTime hora;

        // Constructor: Default
        public Cita () {
            this.idCita = 0;
            this.paciente = new Paciente ();
            this.odontologo = new Odontologo ();
            this.fecha = DateTime.Now;
            this.hora = DateTime.Now;
        }

        // Constructor: Parameterized
        public Cita (int id_cita, DateTime fecha, DateTime hora, Odontologo odontologo, Paciente paciente) {
            this.idCita = id_cita;
            this.paciente = paciente;
            this.odontologo = odontologo;
            this.fecha = fecha;
            this.hora = hora;
        }

        public int Id_cita { get => idCita; set => idCita = value; }                  // Getter & Setter: id_cita
        public Paciente Paciente { get => paciente; set => paciente = value; }          // Getter & Setter: paciente
        public Odontologo Odontologo { get => odontologo; set => odontologo = value; }  // Getter & Setter: odontologo
        public DateTime Fecha { get => fecha; set => fecha = value; }                   // Getter & Setter: fecha
        public DateTime Hora { get => hora; set => hora = value; }                      // Getter & Setter: hora

        // Method: ToString
        public override string ToString () {
            return
                "\r\nPaciente: " + paciente.Nombre +
                "\r\nOdontólogo: " + odontologo.Nombre +
                "\r\nFecha: " + fecha +
                "\r\nHora: " + hora +
                "\r\nConsultorio: " + odontologo.Consultorio;
        }
    }
}
