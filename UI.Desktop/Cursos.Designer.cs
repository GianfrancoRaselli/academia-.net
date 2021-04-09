namespace UI.Desktop
{
    partial class Cursos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cursos));
            this.tcCursos = new System.Windows.Forms.ToolStripContainer();
            this.tlCursos = new System.Windows.Forms.TableLayoutPanel();
            this.dvgCursos = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tscCursos = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnioCalendario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cupos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoCuatrimestre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comenzado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcCursos.ContentPanel.SuspendLayout();
            this.tcCursos.TopToolStripPanel.SuspendLayout();
            this.tcCursos.SuspendLayout();
            this.tlCursos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCursos)).BeginInit();
            this.tscCursos.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcCursos
            // 
            // 
            // tcCursos.ContentPanel
            // 
            this.tcCursos.ContentPanel.Controls.Add(this.tlCursos);
            this.tcCursos.ContentPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tcCursos.ContentPanel.Size = new System.Drawing.Size(600, 339);
            this.tcCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCursos.Location = new System.Drawing.Point(0, 0);
            this.tcCursos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tcCursos.Name = "tcCursos";
            this.tcCursos.Size = new System.Drawing.Size(600, 366);
            this.tcCursos.TabIndex = 0;
            this.tcCursos.Text = "toolStripContainer1";
            // 
            // tcCursos.TopToolStripPanel
            // 
            this.tcCursos.TopToolStripPanel.Controls.Add(this.tscCursos);
            this.tcCursos.TopToolStripPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // tlCursos
            // 
            this.tlCursos.ColumnCount = 2;
            this.tlCursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlCursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlCursos.Controls.Add(this.dvgCursos, 0, 0);
            this.tlCursos.Controls.Add(this.btnActualizar, 0, 1);
            this.tlCursos.Controls.Add(this.btnSalir, 1, 1);
            this.tlCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlCursos.Location = new System.Drawing.Point(0, 0);
            this.tlCursos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlCursos.Name = "tlCursos";
            this.tlCursos.RowCount = 2;
            this.tlCursos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlCursos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlCursos.Size = new System.Drawing.Size(600, 339);
            this.tlCursos.TabIndex = 0;
            // 
            // dvgCursos
            // 
            this.dvgCursos.AllowUserToAddRows = false;
            this.dvgCursos.AllowUserToDeleteRows = false;
            this.dvgCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgCursos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.AnioCalendario,
            this.Cupos,
            this.Comision,
            this.Materia,
            this.TipoCuatrimestre,
            this.Comenzado});
            this.tlCursos.SetColumnSpan(this.dvgCursos, 2);
            this.dvgCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgCursos.Location = new System.Drawing.Point(2, 2);
            this.dvgCursos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dvgCursos.MultiSelect = false;
            this.dvgCursos.Name = "dvgCursos";
            this.dvgCursos.ReadOnly = true;
            this.dvgCursos.RowHeadersWidth = 51;
            this.dvgCursos.RowTemplate.Height = 24;
            this.dvgCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgCursos.Size = new System.Drawing.Size(596, 288);
            this.dvgCursos.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(363, 294);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(120, 43);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(487, 294);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(111, 43);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tscCursos
            // 
            this.tscCursos.Dock = System.Windows.Forms.DockStyle.None;
            this.tscCursos.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tscCursos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tscCursos.Location = new System.Drawing.Point(8, 0);
            this.tscCursos.Name = "tscCursos";
            this.tscCursos.Size = new System.Drawing.Size(84, 27);
            this.tscCursos.TabIndex = 0;
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
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 125;
            // 
            // AnioCalendario
            // 
            this.AnioCalendario.DataPropertyName = "AnioCalendario";
            this.AnioCalendario.HeaderText = "Año calendario";
            this.AnioCalendario.MinimumWidth = 6;
            this.AnioCalendario.Name = "AnioCalendario";
            this.AnioCalendario.ReadOnly = true;
            this.AnioCalendario.Width = 125;
            // 
            // Cupos
            // 
            this.Cupos.DataPropertyName = "Cupos";
            this.Cupos.HeaderText = "Cupos";
            this.Cupos.MinimumWidth = 6;
            this.Cupos.Name = "Cupos";
            this.Cupos.ReadOnly = true;
            this.Cupos.Width = 125;
            // 
            // Comision
            // 
            this.Comision.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Comision.DataPropertyName = "Comision";
            this.Comision.HeaderText = "Comision";
            this.Comision.MinimumWidth = 6;
            this.Comision.Name = "Comision";
            this.Comision.ReadOnly = true;
            this.Comision.Width = 74;
            // 
            // Materia
            // 
            this.Materia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Materia.DataPropertyName = "Materia";
            this.Materia.HeaderText = "Materia";
            this.Materia.MinimumWidth = 6;
            this.Materia.Name = "Materia";
            this.Materia.ReadOnly = true;
            this.Materia.Width = 67;
            // 
            // TipoCuatrimestre
            // 
            this.TipoCuatrimestre.DataPropertyName = "TipoCuatrimestre";
            this.TipoCuatrimestre.HeaderText = "Tipo Cuatrimestre";
            this.TipoCuatrimestre.MinimumWidth = 6;
            this.TipoCuatrimestre.Name = "TipoCuatrimestre";
            this.TipoCuatrimestre.ReadOnly = true;
            this.TipoCuatrimestre.Width = 125;
            // 
            // Comenzado
            // 
            this.Comenzado.DataPropertyName = "Comenzado";
            this.Comenzado.HeaderText = "Comenzado";
            this.Comenzado.MinimumWidth = 6;
            this.Comenzado.Name = "Comenzado";
            this.Comenzado.ReadOnly = true;
            this.Comenzado.Width = 125;
            // 
            // Cursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.tcCursos);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Cursos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cursos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Personas_Load);
            this.tcCursos.ContentPanel.ResumeLayout(false);
            this.tcCursos.TopToolStripPanel.ResumeLayout(false);
            this.tcCursos.TopToolStripPanel.PerformLayout();
            this.tcCursos.ResumeLayout(false);
            this.tcCursos.PerformLayout();
            this.tlCursos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgCursos)).EndInit();
            this.tscCursos.ResumeLayout(false);
            this.tscCursos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcCursos;
        private System.Windows.Forms.TableLayoutPanel tlCursos;
        private System.Windows.Forms.DataGridView dvgCursos;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip tscCursos;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnioCalendario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cupos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comision;
        private System.Windows.Forms.DataGridViewTextBoxColumn Materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCuatrimestre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comenzado;
    }
}