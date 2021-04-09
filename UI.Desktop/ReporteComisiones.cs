using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Microsoft.Reporting.WinForms;

namespace UI.Desktop
{
    public partial class ReporteComisiones : Form
    {
        public ReporteComisiones()
        {
            InitializeComponent();
        }

        private void ReporteComisiones_Load(object sender, EventArgs e)
        {
            ComisionLogic cl = new ComisionLogic();

            ReportDataSource rds = new ReportDataSource("DataSetComisiones", cl.GetAll());
            this.reportViewerComisiones.LocalReport.ReportEmbeddedResource = "UI.Desktop.ReportComisiones.rdlc";
            this.reportViewerComisiones.LocalReport.DataSources.Clear();
            this.reportViewerComisiones.LocalReport.DataSources.Add(rds);
            this.reportViewerComisiones.RefreshReport();
        }
    }
}
