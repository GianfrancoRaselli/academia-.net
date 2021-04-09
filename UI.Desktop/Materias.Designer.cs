namespace UI.Desktop
{
    partial class Materias
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Materias));
            this.tlsMaterias = new System.Windows.Forms.ToolStripContainer();
            this.tlpMaterias = new System.Windows.Forms.TableLayoutPanel();
            this.dgvMaterias = new System.Windows.Forms.DataGridView();
            this.idMateria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descMateria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsSemanales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsTotales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tsMaterias = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tlsMaterias.ContentPanel.SuspendLayout();
            this.tlsMaterias.TopToolStripPanel.SuspendLayout();
            this.tlsMaterias.SuspendLayout();
            this.tlpMaterias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).BeginInit();
            this.tsMaterias.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlsMaterias
            // 
            // 
            // tlsMaterias.ContentPanel
            // 
            this.tlsMaterias.ContentPanel.Controls.Add(this.tlpMaterias);
            this.tlsMaterias.ContentPanel.Size = new System.Drawing.Size(800, 423);
            this.tlsMaterias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlsMaterias.Location = new System.Drawing.Point(0, 0);
            this.tlsMaterias.Name = "tlsMaterias";
            this.tlsMaterias.Size = new System.Drawing.Size(800, 450);
            this.tlsMaterias.TabIndex = 0;
            this.tlsMaterias.Text = "toolStripContainer1";
            // 
            // tlsMaterias.TopToolStripPanel
            // 
            this.tlsMaterias.TopToolStripPanel.Controls.Add(this.tsMaterias);
            // 
            // tlpMaterias
            // 
            this.tlpMaterias.ColumnCount = 3;
            this.tlpMaterias.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMaterias.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMaterias.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMaterias.Controls.Add(this.dgvMaterias, 0, 0);
            this.tlpMaterias.Controls.Add(this.btnSalir, 2, 1);
            this.tlpMaterias.Controls.Add(this.btnActualizar, 1, 1);
            this.tlpMaterias.Controls.Add(this.button1, 0, 1);
            this.tlpMaterias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMaterias.Location = new System.Drawing.Point(0, 0);
            this.tlpMaterias.Name = "tlpMaterias";
            this.tlpMaterias.RowCount = 2;
            this.tlpMaterias.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMaterias.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMaterias.Size = new System.Drawing.Size(800, 423);
            this.tlpMaterias.TabIndex = 0;
            // 
            // dgvMaterias
            // 
            this.dgvMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMateria,
            this.descMateria,
            this.hsSemanales,
            this.hsTotales,
            this.Plan});
            this.tlpMaterias.SetColumnSpan(this.dgvMaterias, 3);
            this.dgvMaterias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaterias.Location = new System.Drawing.Point(3, 3);
            this.dgvMaterias.Name = "dgvMaterias";
            this.dgvMaterias.ReadOnly = true;
            this.dgvMaterias.RowHeadersWidth = 51;
            this.dgvMaterias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaterias.Size = new System.Drawing.Size(794, 374);
            this.dgvMaterias.TabIndex = 0;
            // 
            // idMateria
            // 
            this.idMateria.DataPropertyName = "ID";
            this.idMateria.HeaderText = "ID Materia";
            this.idMateria.MinimumWidth = 6;
            this.idMateria.Name = "idMateria";
            this.idMateria.ReadOnly = true;
            this.idMateria.Width = 125;
            // 
            // descMateria
            // 
            this.descMateria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.descMateria.DataPropertyName = "Descripcion";
            this.descMateria.HeaderText = "Descripcion Materia";
            this.descMateria.MinimumWidth = 6;
            this.descMateria.Name = "descMateria";
            this.descMateria.ReadOnly = true;
            this.descMateria.Width = 115;
            // 
            // hsSemanales
            // 
            this.hsSemanales.DataPropertyName = "HsSemanales";
            this.hsSemanales.HeaderText = "HS Semanales";
            this.hsSemanales.MinimumWidth = 6;
            this.hsSemanales.Name = "hsSemanales";
            this.hsSemanales.ReadOnly = true;
            this.hsSemanales.Width = 125;
            // 
            // hsTotales
            // 
            this.hsTotales.DataPropertyName = "HsTotales";
            this.hsTotales.HeaderText = "Hs Totales";
            this.hsTotales.MinimumWidth = 6;
            this.hsTotales.Name = "hsTotales";
            this.hsTotales.ReadOnly = true;
            this.hsTotales.Width = 125;
            // 
            // Plan
            // 
            this.Plan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Plan.DataPropertyName = "Plan";
            this.Plan.HeaderText = "Plan";
            this.Plan.MinimumWidth = 6;
            this.Plan.Name = "Plan";
            this.Plan.ReadOnly = true;
            this.Plan.Width = 53;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(697, 383);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 37);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(575, 383);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(116, 37);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(446, 382);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 37);
            this.button1.TabIndex = 3;
            this.button1.Text = "Generar Reporte";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tsMaterias
            // 
            this.tsMaterias.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMaterias.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMaterias.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsMaterias.Location = new System.Drawing.Point(3, 0);
            this.tsMaterias.Name = "tsMaterias";
            this.tsMaterias.Size = new System.Drawing.Size(84, 27);
            this.tsMaterias.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(24, 24);
            this.tsbNuevo.Text = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(24, 24);
            this.tsbEditar.Text = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminar.Image")));
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(24, 24);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbSalir_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Materias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlsMaterias);
            this.Name = "Materias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Materias";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Materias_Load);
            this.tlsMaterias.ContentPanel.ResumeLayout(false);
            this.tlsMaterias.TopToolStripPanel.ResumeLayout(false);
            this.tlsMaterias.TopToolStripPanel.PerformLayout();
            this.tlsMaterias.ResumeLayout(false);
            this.tlsMaterias.PerformLayout();
            this.tlpMaterias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).EndInit();
            this.tsMaterias.ResumeLayout(false);
            this.tsMaterias.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tlsMaterias;
        private System.Windows.Forms.ToolStrip tsMaterias;
        private System.Windows.Forms.TableLayoutPanel tlpMaterias;
        private System.Windows.Forms.DataGridView dgvMaterias;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMateria;
        private System.Windows.Forms.DataGridViewTextBoxColumn descMateria;
        private System.Windows.Forms.DataGridViewTextBoxColumn hsSemanales;
        private System.Windows.Forms.DataGridViewTextBoxColumn hsTotales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plan;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}