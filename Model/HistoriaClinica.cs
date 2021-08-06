using System;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proyecto_Dentalig;

namespace Model {
    class HistoriaClinica {

        private Paciente paciente;
        private string antecedenteFamiliar;
        private string antecedentePersonal;
        private List<AtencionMedica> atencionMedica;

        public HistoriaClinica () {
            this.paciente = null;
            this.antecedenteFamiliar = null;
            this.antecedentePersonal = null;
            this.atencionMedica = null;
        }

        public HistoriaClinica (Paciente paciente, string antecedenteFamiliar, string antecedentePersonal, List<AtencionMedica> atencionMedica) {
            this.paciente = paciente;
            this.antecedenteFamiliar = antecedenteFamiliar;
            this.antecedentePersonal = antecedentePersonal;
            this.atencionMedica = atencionMedica;
        }

        public string AntecedenteFamiliar { get => antecedenteFamiliar; set => antecedenteFamiliar = value; }
        public string AntecedentePersonal { get => antecedentePersonal; set => antecedentePersonal = value; }
        internal Paciente Paciente { get => paciente; set => paciente = value; }
        internal List<AtencionMedica> AtencionMedica { get => atencionMedica; set => atencionMedica = value; }

        public override string ToString () {
            return
                "\r\nPaciente: " + paciente.Nombre +
                "\r\nAntecedente Familiar: " + antecedenteFamiliar +
                "\r\nAntecedente Personal: " + antecedentePersonal +
                "\r\nAtención Médica: " + atencionMedica;
        }

    }
}
