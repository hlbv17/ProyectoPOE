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
    public partial class FrmMenuHLBV : Form
    {
        AdmCitaHLBV adm = AdmCitaHLBV.GetAdm();
        public FrmMenuHLBV()
        {
            InitializeComponent();
        }

        private void conexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adm.Conectar();
        }

        private void registrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmRegistrarCitaHLBV frmR = new FrmRegistrarCitaHLBV();
            frmR.ShowDialog();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListarCitasHLBV frmL = new FrmListarCitasHLBV();
            frmL.ShowDialog();
        }

        private void editarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmEditarCitasHLBV frmE = new FrmEditarCitasHLBV();
            frmE.ShowDialog();
        }

        private void consultarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmFiltrarCitasHLBV frmF = new FrmFiltrarCitasHLBV();
            frmF.ShowDialog();
            
        }

        private void eliminarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmEliminarCitasHLBV frmEl = new FrmEliminarCitasHLBV();
            frmEl.ShowDialog();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAcercaDeHLBV frmA = new FrmAcercaDeHLBV();
            frmA.ShowDialog();
        }
    }
}
