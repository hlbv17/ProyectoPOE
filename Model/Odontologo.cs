using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    class Odontologo : Persona {

        private string especialidad;
        private Horario horario;

        public Odontologo () {
            this.especialidad = "";
            this.horario = null;
        }

        public Odontologo (string especialidad, Horario horario) {
            this.especialidad = especialidad;
            this.horario = horario;
        }

        public string Especialidad { get => especialidad; set => especialidad = value; }
        internal Horario Horario { get => horario; set => horario = value; }

        public override string ToString () {
            return
                "\r\nEspecialidad: " + especialidad +
                "\r\nHorario: " + horario.ToString ();
        }

    }
}
