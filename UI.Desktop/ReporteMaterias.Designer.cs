namespace UI.Desktop
{
    partial class ReporteMaterias
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
            this.reportViewerMaterias = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerMaterias
            // 
            this.reportViewerMaterias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerMaterias.Location = new System.Drawing.Point(0, 0);
            this.reportViewerMaterias.Name = "reportViewerMaterias";
            this.reportViewerMaterias.ServerReport.BearerToken = null;
            this.reportViewerMaterias.Size = new System.Drawing.Size(800, 450);
            this.reportViewerMaterias.TabIndex = 0;
            // 
            // ReporteMaterias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewerMaterias);
            this.Name = "ReporteMaterias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteMaterias";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReporteMaterias_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerMaterias;
    }
}