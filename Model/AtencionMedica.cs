using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proyecto_Dentalig {
    public class AtencionMedica {

        // Variables
        private Cita cita;
        private PiezaDental piezaDental;
        private string motivoConsulta;
        private string diagnostico;

        public AtencionMedica () {
            this.cita = null;
            this.piezaDental = null;
            this.motivoConsulta = "";
            this.diagnostico = "";
        }

        // Constructor: Parameterized
        public AtencionMedica (Cita cita, PiezaDental piezaDental, string motivoConsulta, string diagnostico) {
            this.cita = cita;
            this.piezaDental = piezaDental;
            this.motivoConsulta = motivoConsulta;
            this.diagnostico = diagnostico;
        }

        public string MotivoConsulta { get => motivoConsulta; set => motivoConsulta = value; }  // Getter & Setter: cita
        public string Diagnostico { get => diagnostico; set => diagnostico = value; }           // Getter & Setter: piezaDental
        internal Cita Cita { get => cita; set => cita = value; }                                // Getter & Setter: motivoConsulta
        internal PiezaDental PiezaDental { get => piezaDental; set => piezaDental = value; }    // Getter & Setter: diagnostico
        
        // Method: ToString
        public override string ToString () {
            return 
                "\r\nCita: "+ cita.ToString()+
                "\r\nPieca Dental: " + piezaDental.ToString ()+
                "\r\nMotivo de Consulta: "+ motivoConsulta+
                "\r\nDiagnostico:"+ diagnostico;
        }
    }
}
