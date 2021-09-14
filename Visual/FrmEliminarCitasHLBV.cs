using Control;
using System;
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
                if (admC.AtencionExistente(dgvCitas, posicion) == false)
                {
                    admC.EliminarCita(dgvCitas, posicion);
                }
                else
                {
                    MessageBox.Show("Este paciente ya fue atendido", "Error al eliminar" );
                }
            }
            else
            {
                MessageBox.Show("No ha realizado la consulta");
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
