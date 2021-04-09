namespace UI.Desktop
{
    partial class MateriasCorrelativas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MateriasCorrelativas));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvMatCorrelativas = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MateriaSucesora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MateriaPredecesora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsMaterias = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatCorrelativas)).BeginInit();
            this.tsMaterias.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1067, 527);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1067, 554);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsMaterias);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.39626F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.36433F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.23942F));
            this.tableLayoutPanel1.Controls.Add(this.dgvMatCorrelativas, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSalir, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1067, 527);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvMatCorrelativas
            // 
            this.dgvMatCorrelativas.AllowUserToAddRows = false;
            this.dgvMatCorrelativas.AllowUserToDeleteRows = false;
            this.dgvMatCorrelativas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMatCorrelativas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatCorrelativas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.MateriaSucesora,
            this.MateriaPredecesora,
            this.Condicion});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvMatCorrelativas, 3);
            this.dgvMatCorrelativas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMatCorrelativas.Location = new System.Drawing.Point(4, 4);
            this.dgvMatCorrelativas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMatCorrelativas.Name = "dgvMatCorrelativas";
            this.dgvMatCorrelativas.ReadOnly = true;
            this.dgvMatCorrelativas.RowHeadersWidth = 51;
            this.dgvMatCorrelativas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMatCorrelativas.Size = new System.Drawing.Size(1059, 443);
            this.dgvMatCorrelativas.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 50;
            // 
            // MateriaSucesora
            // 
            this.MateriaSucesora.DataPropertyName = "MateriaSucesora";
            this.MateriaSucesora.HeaderText = "Materia Sucesora";
            this.MateriaSucesora.MinimumWidth = 6;
            this.MateriaSucesora.Name = "MateriaSucesora";
            this.MateriaSucesora.ReadOnly = true;
            this.MateriaSucesora.Width = 136;
            // 
            // MateriaPredecesora
            // 
            this.MateriaPredecesora.DataPropertyName = "MateriaPredecesora";
            this.MateriaPredecesora.HeaderText = "Materia Predecesora";
            this.MateriaPredecesora.MinimumWidth = 6;
            this.MateriaPredecesora.Name = "MateriaPredecesora";
            this.MateriaPredecesora.ReadOnly = true;
            this.MateriaPredecesora.Width = 154;
            // 
            // Condicion
            // 
            this.Condicion.DataPropertyName = "Condicion";
            this.Condicion.HeaderText = "Condiciones";
            this.Condicion.MinimumWidth = 6;
            this.Condicion.Name = "Condicion";
            this.Condicion.ReadOnly = true;
            this.Condicion.Width = 114;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAceptar.Location = new System.Drawing.Point(744, 455);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(155, 68);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Actualizar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSalir.Location = new System.Drawing.Point(907, 455);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(156, 68);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tsMaterias
            // 
            this.tsMaterias.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMaterias.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMaterias.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnNuevo,
            this.toolStripBtnEditar,
            this.toolStripBtnSalir});
            this.tsMaterias.Location = new System.Drawing.Point(7, 0);
            this.tsMaterias.Name = "tsMaterias";
            this.tsMaterias.Size = new System.Drawing.Size(100, 27);
            this.tsMaterias.TabIndex = 1;
            // 
            // toolStripBtnNuevo
            // 
            this.toolStripBtnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnNuevo.Image")));
            this.toolStripBtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnNuevo.Name = "toolStripBtnNuevo";
            this.toolStripBtnNuevo.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnNuevo.Text = "Agregar";
            this.toolStripBtnNuevo.Click += new System.EventHandler(this.toolStripBtnNuevo_Click);
            // 
            // toolStripBtnEditar
            // 
            this.toolStripBtnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnEditar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnEditar.Image")));
            this.toolStripBtnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnEditar.Name = "toolStripBtnEditar";
            this.toolStripBtnEditar.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnEditar.Text = "Editar";
            this.toolStripBtnEditar.Click += new System.EventHandler(this.toolStripBtnEditar_Click_1);
            // 
            // toolStripBtnSalir
            // 
            this.toolStripBtnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSalir.Image")));
            this.toolStripBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSalir.Name = "toolStripBtnSalir";
            this.toolStripBtnSalir.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnSalir.Text = "Eliminar";
            this.toolStripBtnSalir.Click += new System.EventHandler(this.toolStripBtnSalir_Click_1);
            // 
            // MateriasCorrelativas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.toolStripContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MateriasCorrelativas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MateriasCorrelativas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatCorrelativas)).EndInit();
            this.tsMaterias.ResumeLayout(false);
            this.tsMaterias.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvMatCorrelativas;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip tsMaterias;
        private System.Windows.Forms.ToolStripButton toolStripBtnNuevo;
        private System.Windows.Forms.ToolStripButton toolStripBtnEditar;
        private System.Windows.Forms.ToolStripButton toolStripBtnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MateriaSucesora;
        private System.Windows.Forms.DataGridViewTextBoxColumn MateriaPredecesora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condicion;
    }
}