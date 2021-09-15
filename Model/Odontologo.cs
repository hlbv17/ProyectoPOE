using Proyecto_Dentalig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    public class Odontologo : Persona, IOdontologo {

        // Variables
        private int idOdontologo;
        private string especialidad;
        private int consultorio;
        private Horario horario;

        // Constructor: Default
        public Odontologo () {
            this.idOdontologo = 0;
            this.especialidad = "";
            this.consultorio = 0;
            this.horario = new Horario ();
        }

        // Constructor: Parameterized
        public Odontologo (int id_Odontologo, string especialidad, int consultorio, Horario horario, string cedula, char sexo, string nombre, DateTime fechaNacimiento, string telefono, string correo) : base (cedula, sexo, nombre, fechaNacimiento, telefono, correo) {
            this.idOdontologo = id_Odontologo;
            this.especialidad = especialidad;
            this.consultorio = consultorio;
            this.horario = horario;
        }

        public int Id_Odontologo { get => idOdontologo; set => idOdontologo = value; }    // Getter & Setter: id_Odontologo
        public string Especialidad { get => especialidad; set => especialidad = value; }    // Getter & Setter: especialida
        public int Consultorio { get => consultorio; set => consultorio = value; }          // Getter & Setter: consultorio
        public Horario Horario { get => horario; set => horario = value; }                  // Getter & Setter: horario

        // Methodd: Estado
        public string Estado (int e) {
            string estado = "";
            if (e == 0 ) {
                estado = "Disponible";
            } else if (e > 0) {
                estado = "Ocupado";
            }
            return estado;
        }

        // Method: ToString
        public override string ToString () {
            return base.ToString () +
                "\r\nEstado: " + Estado (consultorio) +
                "\r\nEspecialidad: " + especialidad +
                "\r\nConsultorio:" + consultorio +
                "\r\nHorario: " + horario.ToString ();
        }
    }
}