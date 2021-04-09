namespace UI.Desktop
{
    partial class ReporteAlumnos
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
            this.reportViewerAlumnos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerAlumnos
            // 
            this.reportViewerAlumnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerAlumnos.Location = new System.Drawing.Point(0, 0);
            this.reportViewerAlumnos.Name = "reportViewerAlumnos";
            this.reportViewerAlumnos.ServerReport.BearerToken = null;
            this.reportViewerAlumnos.Size = new System.Drawing.Size(800, 450);
            this.reportViewerAlumnos.TabIndex = 0;
            // 
            // ReporteAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewerAlumnos);
            this.Name = "ReporteAlumnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteAlumnos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReporteAlumnos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerAlumnos;
    }
}