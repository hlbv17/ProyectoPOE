using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proyecto_Dentalig {
    public class AtencionMedica_ROPB {


        // Variables
        private Cita cita;
        private PiezaDental piezaDental;
        private string motivoConsulta;
        private string diagnostico;

        // Constructor: Default
        public AtencionMedica_ROPB () {
            this.cita = new Cita ();
            this.piezaDental = new PiezaDental ();
            this.motivoConsulta = "";
            this.diagnostico = "";
        }

        // Constructor: Parameterized
        public AtencionMedica_ROPB (Cita cita, PiezaDental piezaDental, string motivoConsulta, string diagnostico) {
            this.cita = cita;
            this.piezaDental = piezaDental;
            this.motivoConsulta = motivoConsulta;
            this.diagnostico = diagnostico;
        }

        public Cita Cita { get => cita; set => cita = value; }                                  // Getter & Setter: cita
        public PiezaDental PiezaDental { get => piezaDental; set => piezaDental = value; }      // Getter & Setter: piezaDental
        public string MotivoConsulta { get => motivoConsulta; set => motivoConsulta = value; }  // Getter & Setter: motivoConsulta
        public string Diagnostico { get => diagnostico; set => diagnostico = value; }           // Getter & Setter: diagnostico

        // Method: ToString
        public override string ToString () {
            return
                "\r\nCita: " + cita.ToString () +
                "\r\nPieza Dental: " + piezaDental.ToString () +
                "\r\nMotivo de Consulta: " + motivoConsulta +
                "\r\nDiagnostico: " + diagnostico;
        }


    }
}
