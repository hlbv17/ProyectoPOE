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

        public Cita()
        {
            this.id_cita = 0;
            this.fecha = new DateTime();
            this.hora = new DateTime();
            this.odontologo = new Odontologo();
            this.paciente = new Paciente();
        }

        public Cita(int id_cita, DateTime fecha, DateTime hora, Odontologo odontologo, Paciente paciente)
        {
            this.id_cita = id_cita;
            this.fecha = fecha;
            this.hora = hora;
            this.odontologo = odontologo;
            this.paciente = paciente;
        }

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public DateTime Hora { get => hora; set => hora = value; }
        public int Id_cita { get => id_cita; set => id_cita = value; }
        public Odontologo Odontologo { get => odontologo; set => odontologo = value; }
        public Paciente Paciente { get => paciente; set => paciente = value; }

        public override string ToString()
        {
            return
                "\r\nCédula: " + paciente.Cedula +
                "\r\nPaciente: " + paciente.Nombre +
                "\r\nFecha: " + fecha.ToString("yyyy-MM-dd") +
                "\r\nHora: " + hora.ToString("HH:mm:ss") +
                "\r\nOdontólogo: " + odontologo.Nombre +
                "\r\nConsultorio: " + odontologo.Consultorio;
        }
    }
}
