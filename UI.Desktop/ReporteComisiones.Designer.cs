namespace UI.Desktop
{
    partial class ReporteComisiones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewerComisiones = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerComisiones
            // 
            this.reportViewerComisiones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerComisiones.Location = new System.Drawing.Point(0, 0);
            this.reportViewerComisiones.Name = "reportViewerComisiones";
            this.reportViewerComisiones.ServerReport.BearerToken = null;
            this.reportViewerComisiones.Size = new System.Drawing.Size(800, 450);
            this.reportViewerComisiones.TabIndex = 0;
            // 
            // ReporteComisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewerComisiones);
            this.Name = "ReporteComisiones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteComisiones";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReporteComisiones_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerComisiones;
    }
}