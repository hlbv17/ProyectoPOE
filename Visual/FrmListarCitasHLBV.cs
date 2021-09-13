using Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visual
{
    public partial class FrmListarCitasHLBV : Form
    {
        AdmCitaHLBV admC = AdmCitaHLBV.GetAdm();
        public FrmListarCitasHLBV()
        {
            InitializeComponent();
            admC.LlenarTabla(dgvCitas);
        }
    }
}
