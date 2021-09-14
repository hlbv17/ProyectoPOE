using Control;
using System;
using System.Windows.Forms;

namespace Visual
{
    public partial class FrmReporteCitaHLBV : Form
    {
        AdmCitaHLBV admC = AdmCitaHLBV.GetAdm();
        public FrmReporteCitaHLBV(string cedula, DateTime fecha, string hora, int n, string file)
        {
            InitializeComponent();
            admC.CrearPdf(cedula, fecha, hora, n, file);
            axAcroPDF.src = file;
        }
    }
}
