using Proyecto_Dentalig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    class Odontologo : Persona, IOdontologo
    {

        private string especialidad;
        private int consultorio;
        private Horario horario;
        private int id_Odontologo;


        public Odontologo()
        {
            this.especialidad = " ";
            this.id_Odontologo = 04;
            this.consultorio = 1;
            this.horario = null;
        }


        public string Especialidad { get => especialidad; set => especialidad = value; }
        internal Horario Horario { get => horario; set => horario = value; }
        public int Consultorio { get => consultorio; set => consultorio = value; }
        public int Id_Odontologo { get => id_Odontologo; set => id_Odontologo = value; }

        public Odontologo(int id_Odontologo, string nombre, string cedula, string especialidad, char sexo, DateTime fechaNacimiento, Horario horario, int consultorio, string telefono, string correo) : base(cedula, sexo, nombre, fechaNacimiento, telefono, correo)
        {
            this.Especialidad = especialidad;
            this.Horario = horario;
            this.Id_Odontologo = id_Odontologo;
            this.consultorio = consultorio;
        }
        public string Estado(int consultorio)
        {
            string estado;

            Random r = new Random();
            int e;
            e = r.Next(1, 6);
            if (consultorio == e)
            {
                estado = "Disponible";
            }
            else
            {
                estado = "Ocupado";
            }

            return estado;
        }
        public override string ToString () {
            return base.ToString() +
              "\r\nEspecialidad: " + especialidad +
              "\r\nHorario: " + horario.ToString() +
              "\r\nEstado: " + Estado(consultorio) +
              "\r\nConsultorio:" + consultorio;

        }

    }
}
