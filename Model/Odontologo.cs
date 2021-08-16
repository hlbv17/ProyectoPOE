using Proyecto_Dentalig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    public class Odontologo : Persona, IOdontologo {

        private string especialidad;
        private Horario horario;
        private int consultorio;

        public Odontologo () {
            this.especialidad = "";
            this.horario = null;
            this.consultorio = 0;
        }

        public Odontologo (string especialidad, Horario horario, int consultorio) {
            this.especialidad = especialidad;
            this.horario = horario;
            this.consultorio = consultorio;
        }

        public string Especialidad { get => especialidad; set => especialidad = value; }
        public int Consultorio { get => consultorio; set => consultorio = value; }
        internal Horario Horario { get => horario; set => horario = value; }

        public string Estado(int consultorio)
        {
            throw new NotImplementedException();
        }

        public override string ToString () {
            return
                "\r\nEspecialidad: " + especialidad +
                "\r\nConsultorio: " + consultorio +
                "\r\nHorario: " + horario.ToString ();
        }

    }
}
