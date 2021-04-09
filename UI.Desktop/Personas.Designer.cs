namespace UI.Desktop
{
    partial class Personas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Personas));
            this.tcPersonas = new System.Windows.Forms.ToolStripContainer();
            this.tlPersonas = new System.Windows.Forms.TableLayoutPanel();
            this.dvgPersonas = new System.Windows.Forms.DataGridView();
            this.btnReporteAlumnos = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.tscPersonas = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaNac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcPersonas.ContentPanel.SuspendLayout();
            this.tcPersonas.TopToolStripPanel.SuspendLayout();
            this.tcPersonas.SuspendLayout();
            this.tlPersonas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgPersonas)).BeginInit();
            this.tscPersonas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPersonas
            // 
            // 
            // tcPersonas.ContentPanel
            // 
            this.tcPersonas.ContentPanel.Controls.Add(this.tlPersonas);
            this.tcPersonas.ContentPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tcPersonas.ContentPanel.Size = new System.Drawing.Size(800, 423);
            this.tcPersonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPersonas.Location = new System.Drawing.Point(0, 0);
            this.tcPersonas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tcPersonas.Name = "tcPersonas";
            this.tcPersonas.Size = new System.Drawing.Size(800, 450);
            this.tcPersonas.TabIndex = 0;
            this.tcPersonas.Text = "toolStripContainer1";
            // 
            // tcPersonas.TopToolStripPanel
            // 
            this.tcPersonas.TopToolStripPanel.Controls.Add(this.tscPersonas);
            this.tcPersonas.TopToolStripPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // tlPersonas
            // 
            this.tlPersonas.ColumnCount = 3;
            this.tlPersonas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlPersonas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlPersonas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlPersonas.Controls.Add(this.dvgPersonas, 0, 0);
            this.tlPersonas.Controls.Add(this.btnReporteAlumnos, 0, 1);
            this.tlPersonas.Controls.Add(this.btnSalir, 2, 1);
            this.tlPersonas.Controls.Add(this.btnActualizar, 1, 1);
            this.tlPersonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlPersonas.Location = new System.Drawing.Point(0, 0);
            this.tlPersonas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlPersonas.Name = "tlPersonas";
            this.tlPersonas.RowCount = 2;
            this.tlPersonas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlPersonas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlPersonas.Size = new System.Drawing.Size(800, 423);
            this.tlPersonas.TabIndex = 0;
            // 
            // dvgPersonas
            // 
            this.dvgPersonas.AllowUserToAddRows = false;
            this.dvgPersonas.AllowUserToDeleteRows = false;
            this.dvgPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgPersonas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Legajo,
            this.Nombre,
            this.Apellido,
            this.FechaNac,
            this.Edad,
            this.Telefono,
            this.EMail,
            this.Direccion,
            this.TipoPersona,
            this.Plan});
            this.tlPersonas.SetColumnSpan(this.dvgPersonas, 3);
            this.dvgPersonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgPersonas.Location = new System.Drawing.Point(3, 2);
            this.dvgPersonas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dvgPersonas.MultiSelect = false;
            this.dvgPersonas.Name = "dvgPersonas";
            this.dvgPersonas.ReadOnly = true;
            this.dvgPersonas.RowHeadersWidth = 51;
            this.dvgPersonas.RowTemplate.Height = 24;
            this.dvgPersonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgPersonas.Size = new System.Drawing.Size(794, 358);
            this.dvgPersonas.TabIndex = 0;
            // 
            // btnReporteAlumnos
            // 
            this.btnReporteAlumnos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReporteAlumnos.Location = new System.Drawing.Point(262, 364);
            this.btnReporteAlumnos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReporteAlumnos.Name = "btnReporteAlumnos";
            this.btnReporteAlumnos.Size = new System.Drawing.Size(215, 57);
            this.btnReporteAlumnos.TabIndex = 3;
            this.btnReporteAlumnos.Text = "Generar Reporte Alumnos";
            this.btnReporteAlumnos.UseVisualStyleBackColor = true;
            this.btnReporteAlumnos.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(649, 364);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(148, 57);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(483, 364);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(160, 57);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // tscPersonas
            // 
            this.tscPersonas.Dock = System.Windows.Forms.DockStyle.None;
            this.tscPersonas.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tscPersonas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tscPersonas.Location = new System.Drawing.Point(8, 0);
            this.tscPersonas.Name = "tscPersonas";
            this.tscPersonas.Size = new System.Drawing.Size(100, 27);
            this.tscPersonas.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(29, 24);
            this.tsbNuevo.Text = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(29, 24);
            this.tsbEditar.Text = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminar.Image")));
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(29, 24);
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
            // Legajo
            // 
            this.Legajo.DataPropertyName = "Legajo";
            this.Legajo.HeaderText = "Legajo";
            this.Legajo.MinimumWidth = 6;
            this.Legajo.Name = "Legajo";
            this.Legajo.ReadOnly = true;
            this.Legajo.Width = 125;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 125;
            // 
            // Apellido
            // 
            this.Apellido.DataPropertyName = "Apellido";
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.MinimumWidth = 6;
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            this.Apellido.Width = 125;
            // 
            // FechaNac
            // 
            this.FechaNac.DataPropertyName = "FechaNacimientoConFormato";
            this.FechaNac.HeaderText = "Fecha Nacimiento";
            this.FechaNac.MinimumWidth = 6;
            this.FechaNac.Name = "FechaNac";
            this.FechaNac.ReadOnly = true;
            this.FechaNac.Width = 125;
            // 
            // Edad
            // 
            this.Edad.DataPropertyName = "Edad";
            this.Edad.HeaderText = "Edad";
            this.Edad.MinimumWidth = 6;
            this.Edad.Name = "Edad";
            this.Edad.ReadOnly = true;
            this.Edad.Width = 125;
            // 
            // Telefono
            // 
            this.Telefono.DataPropertyName = "Telefono";
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.MinimumWidth = 6;
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            this.Telefono.Width = 125;
            // 
            // EMail
            // 
            this.EMail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EMail.DataPropertyName = "EMail";
            this.EMail.HeaderText = "EMail";
            this.EMail.MinimumWidth = 6;
            this.EMail.Name = "EMail";
            this.EMail.ReadOnly = true;
            this.EMail.Width = 71;
            // 
            // Direccion
            // 
            this.Direccion.DataPropertyName = "Direccion";
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.MinimumWidth = 6;
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Width = 125;
            // 
            // TipoPersona
            // 
            this.TipoPersona.DataPropertyName = "TipoPersona";
            this.TipoPersona.HeaderText = "Tipo Persona";
            this.TipoPersona.MinimumWidth = 6;
            this.TipoPersona.Name = "TipoPersona";
            this.TipoPersona.ReadOnly = true;
            this.TipoPersona.Width = 125;
            // 
            // Plan
            // 
            this.Plan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Plan.DataPropertyName = "Plan";
            this.Plan.HeaderText = "Plan";
            this.Plan.MinimumWidth = 6;
            this.Plan.Name = "Plan";
            this.Plan.ReadOnly = true;
            this.Plan.Width = 65;
            // 
            // Personas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tcPersonas);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Personas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Personas_Load);
            this.tcPersonas.ContentPanel.ResumeLayout(false);
            this.tcPersonas.TopToolStripPanel.ResumeLayout(false);
            this.tcPersonas.TopToolStripPanel.PerformLayout();
            this.tcPersonas.ResumeLayout(false);
            this.tcPersonas.PerformLayout();
            this.tlPersonas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgPersonas)).EndInit();
            this.tscPersonas.ResumeLayout(false);
            this.tscPersonas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcPersonas;
        private System.Windows.Forms.TableLayoutPanel tlPersonas;
        private System.Windows.Forms.DataGridView dvgPersonas;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip tscPersonas;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.Button btnReporteAlumnos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaNac;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plan;
    }
}