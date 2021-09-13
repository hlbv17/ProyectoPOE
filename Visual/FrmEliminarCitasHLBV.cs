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
    public partial class FrmEliminarCitasHLBV : Form
    {
        AdmCitaHLBV admC = AdmCitaHLBV.GetAdm();
        public FrmEliminarCitasHLBV()
        {
            InitializeComponent();
            admC.LlenarTabla(dgvCitas);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int posicion = dgvCitas.CurrentRow.Index; 
            if (posicion >= 0)
            {
                admC.EliminarCita(dgvCitas, posicion);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFecha.Value.Date;
            dgvCitas.Rows.Clear();
            admC.FiltrarDatos(dgvCitas, fecha);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            dgvCitas.Rows.Clear();
            admC.LlenarTabla(dgvCitas);
        }
    }
}
