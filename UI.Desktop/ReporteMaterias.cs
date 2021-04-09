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
    public partial class ReporteMaterias : Form
    {
        public ReporteMaterias()
        {
            InitializeComponent();
        }

        private void ReporteMaterias_Load(object sender, EventArgs e)
        {
            MateriaLogic ml = new MateriaLogic();

            ReportDataSource rds = new ReportDataSource("DataSetMaterias", ml.GetAll());
            this.reportViewerMaterias.LocalReport.ReportEmbeddedResource = "UI.Desktop.ReportMaterias.rdlc";
            this.reportViewerMaterias.LocalReport.DataSources.Clear();
            this.reportViewerMaterias.LocalReport.DataSources.Add(rds);
            this.reportViewerMaterias.RefreshReport();
        }
    }
}
