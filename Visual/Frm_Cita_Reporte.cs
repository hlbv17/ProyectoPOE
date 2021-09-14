using Control;
using System;
using System.Windows.Forms;

namespace Visual
{
    public partial class Frm_Cita_Reporte : Form
    {
        AdmCitaHLBV admC = AdmCitaHLBV.GetAdm();
        public Frm_Cita_Reporte(string cedula, DateTime fecha, string hora, int n, string file)
        {
            InitializeComponent();
            admC.CrearPdf(cedula, fecha, hora, n, file);
            axAcroPDF.src = file;
        }
    }
}
