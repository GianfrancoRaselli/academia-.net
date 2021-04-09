namespace UI.Desktop
{
    partial class MateriaDesktop
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblHsSemanales = new System.Windows.Forms.Label();
            this.lblHsTotales = new System.Windows.Forms.Label();
            this.lblIdPlan = new System.Windows.Forms.Label();
            this.txtIdMateria = new System.Windows.Forms.TextBox();
            this.txtHsTotales = new System.Windows.Forms.TextBox();
            this.txtHsSemanales = new System.Windows.Forms.TextBox();
            this.txtDescMateria = new System.Windows.Forms.TextBox();
            this.comboBoxPlan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanel2);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(669, 387);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(669, 412);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.btnGuardar, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSalir, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 325);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(669, 62);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(392, 4);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(141, 58);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(541, 4);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(124, 58);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblHsSemanales, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblHsTotales, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblIdPlan, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtIdMateria, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtHsTotales, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtHsSemanales, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDescMateria, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxPlan, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(669, 240);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblHsSemanales
            // 
            this.lblHsSemanales.AutoSize = true;
            this.lblHsSemanales.Location = new System.Drawing.Point(4, 96);
            this.lblHsSemanales.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHsSemanales.Name = "lblHsSemanales";
            this.lblHsSemanales.Size = new System.Drawing.Size(99, 17);
            this.lblHsSemanales.TabIndex = 2;
            this.lblHsSemanales.Text = "Hs Semanales";
            // 
            // lblHsTotales
            // 
            this.lblHsTotales.AutoSize = true;
            this.lblHsTotales.Location = new System.Drawing.Point(4, 144);
            this.lblHsTotales.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHsTotales.Name = "lblHsTotales";
            this.lblHsTotales.Size = new System.Drawing.Size(76, 17);
            this.lblHsTotales.TabIndex = 3;
            this.lblHsTotales.Text = "Hs Totales";
            // 
            // lblIdPlan
            // 
            this.lblIdPlan.AutoSize = true;
            this.lblIdPlan.Location = new System.Drawing.Point(4, 192);
            this.lblIdPlan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdPlan.Name = "lblIdPlan";
            this.lblIdPlan.Size = new System.Drawing.Size(36, 17);
            this.lblIdPlan.TabIndex = 4;
            this.lblIdPlan.Text = "Plan";
            // 
            // txtIdMateria
            // 
            this.txtIdMateria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtIdMateria.Location = new System.Drawing.Point(111, 4);
            this.txtIdMateria.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdMateria.Name = "txtIdMateria";
            this.txtIdMateria.ReadOnly = true;
            this.txtIdMateria.Size = new System.Drawing.Size(554, 22);
            this.txtIdMateria.TabIndex = 5;
            // 
            // txtHsTotales
            // 
            this.txtHsTotales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHsTotales.Location = new System.Drawing.Point(111, 148);
            this.txtHsTotales.Margin = new System.Windows.Forms.Padding(4);
            this.txtHsTotales.Name = "txtHsTotales";
            this.txtHsTotales.Size = new System.Drawing.Size(554, 22);
            this.txtHsTotales.TabIndex = 8;
            // 
            // txtHsSemanales
            // 
            this.txtHsSemanales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHsSemanales.Location = new System.Drawing.Point(111, 100);
            this.txtHsSemanales.Margin = new System.Windows.Forms.Padding(4);
            this.txtHsSemanales.Name = "txtHsSemanales";
            this.txtHsSemanales.Size = new System.Drawing.Size(554, 22);
            this.txtHsSemanales.TabIndex = 7;
            // 
            // txtDescMateria
            // 
            this.txtDescMateria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescMateria.Location = new System.Drawing.Point(111, 52);
            this.txtDescMateria.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescMateria.Name = "txtDescMateria";
            this.txtDescMateria.Size = new System.Drawing.Size(554, 22);
            this.txtDescMateria.TabIndex = 6;
            // 
            // comboBoxPlan
            // 
            this.comboBoxPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxPlan.FormattingEnabled = true;
            this.comboBoxPlan.Location = new System.Drawing.Point(110, 194);
            this.comboBoxPlan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxPlan.Name = "comboBoxPlan";
            this.comboBoxPlan.Size = new System.Drawing.Size(556, 24);
            this.comboBoxPlan.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Descripción";
            // 
            // MateriaDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 412);
            this.Controls.Add(this.toolStripContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MateriaDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MateriaDesktop";
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblHsSemanales;
        private System.Windows.Forms.Label lblHsTotales;
        private System.Windows.Forms.Label lblIdPlan;
        private System.Windows.Forms.TextBox txtIdMateria;
        private System.Windows.Forms.TextBox txtHsTotales;
        private System.Windows.Forms.TextBox txtHsSemanales;
        private System.Windows.Forms.TextBox txtDescMateria;
        private System.Windows.Forms.ComboBox comboBoxPlan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}