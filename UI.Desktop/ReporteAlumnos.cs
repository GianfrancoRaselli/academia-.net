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
    public partial class ReporteAlumnos : Form
    {
        public ReporteAlumnos()
        {
            InitializeComponent();
        }

        private void ReporteAlumnos_Load(object sender, EventArgs e)
        {
            PersonaLogic pl = new PersonaLogic();

            ReportDataSource rds = new ReportDataSource("DataSetAlumnos", pl.GetAlumnos());
            this.reportViewerAlumnos.LocalReport.ReportEmbeddedResource = "UI.Desktop.ReportAlumnos.rdlc";
            this.reportViewerAlumnos.LocalReport.DataSources.Clear();
            this.reportViewerAlumnos.LocalReport.DataSources.Add(rds);
            this.reportViewerAlumnos.RefreshReport();
        }
    }
}
