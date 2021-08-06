using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proyecto_Dentalig {
    class AtencionMedica {

        private DateTime fecha;
        private Odontologo odontologo;
        private string diagnostico;
        private PiezaDental piezaDental;

        public AtencionMedica () {
            this.fecha = DateTime.Now;
            this.odontologo = null;
            this.diagnostico = "";
            this.piezaDental = null;
        }

        public AtencionMedica (DateTime fecha, Odontologo odontologo, string diagnostico, PiezaDental piezaDental) {
            this.fecha = fecha;
            this.odontologo = odontologo;
            this.diagnostico = diagnostico;
            this.piezaDental = piezaDental;
        }

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Diagnostico { get => diagnostico; set => diagnostico = value; }
        internal Odontologo Odontologo { get => odontologo; set => odontologo = value; }
        internal PiezaDental PiezaDental { get => piezaDental; set => piezaDental = value; }

        public override string ToString () {
            return
                "\r\nFecha: " + fecha +
                "\r\nOdontólogo: " + odontologo.Nombre +
                "\r\nDiagnostico: " + diagnostico +
                "\r\nPieza Dental" + piezaDental.ToString ();
        }

    }
}
