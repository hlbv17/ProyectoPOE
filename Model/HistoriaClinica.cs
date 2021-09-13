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
        private long id_hclinica;

        // Constructor: defautl
        public HistoriaClinica () {
            this.paciente = new Paciente ();
            this.antecedente = new Antecedente ();
            this.atencionMedica = new List<AtencionMedica> ();
            this.id_hclinica = 0;
        }

        // Constructor: parameterized
        public HistoriaClinica (Paciente paciente, Antecedente antecedente, List<AtencionMedica> atencionMedica, long id_hclinica) {
            this.paciente = paciente;
            this.antecedente = antecedente;
            this.atencionMedica = atencionMedica;
            this.id_hclinica = id_hclinica;
        }

        public Paciente Paciente { get => paciente; set => paciente = value; }
        public List<AtencionMedica> AtencionMedica { get => atencionMedica; set => atencionMedica = value; }
        public Antecedente Antecedente { get => antecedente; set => antecedente = value; }
        public long Id_hclinica { get => id_hclinica; set => id_hclinica = value; }

        // Method: ToString
        public override string ToString () {
            return
                "\r\nPaciente: \n" + paciente.ToString () +
                "\r\nAntecedente Familiar: " + antecedente.AntecedenteFam +
                "\r\nAntecedente Personal: " + antecedente.Antecedenteper +
                "\r\nAtención Médica: " + atencionMedica.Count ();
        }

    }
}

