using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visual {
    public partial class Frm_About : Form {
        public Frm_About () {
            InitializeComponent ();
        }

        private void btn_Cerrar_Click (object sender, EventArgs e) {
            this.Close ();
        }
    }
}
