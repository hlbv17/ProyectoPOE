using System;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proyecto_Dentalig;

namespace Model {
    public class HistoriaClinica {

        // Variables
        private Paciente paciente;
        private Antecedente antecedente;
        private List<AtencionMedica> atencionMedica;

        // Constructor: defautl
        public HistoriaClinica () {
            this.paciente = new Paciente ();
            this.antecedente = new Antecedente ();
            this.atencionMedica = new List<AtencionMedica> ();
        }

        // Constructor: parameterized
        public HistoriaClinica (Paciente paciente, Antecedente antecedente, List<AtencionMedica> atencionMedica) {
            this.paciente = paciente;
            this.antecedente = antecedente;
            this.atencionMedica = atencionMedica;
        }

        public Paciente Paciente { get => paciente; set => paciente = value; }                                  // Getter & Setter: paciente
        public Antecedente Antecedente { get => antecedente; set => antecedente = value; }                      // Getter & Setter: antecedente
        public List<AtencionMedica> AtencionMedica { get => atencionMedica; set => atencionMedica = value; }    // Getter & Setter: atencionMedica

        // Method: ToString
        public override string ToString () {
            return
                "\r\nPaciente: " + paciente.Nombre +
                "\r\nAntecedentes " + antecedente.ToString () +
                "\r\nAtención Médica: " + atencionMedica.Count;
        }

    }
}
