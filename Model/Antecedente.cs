using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    class Antecedente {
        private string familiar;
        private string personal;

        public Antecedente () {
        }

        public string Familiar { get => familiar; set => familiar = value; }
        public string Personal { get => personal; set => personal = value; }

        public Antecedente (string familiar, string personal) {
            Familiar = familiar;
            Personal = personal;
        }

        public override string ToString () {
            return base.ToString ();
        }
    }
}
