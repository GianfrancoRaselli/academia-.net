namespace UI.Desktop
{
    partial class UsuarioDesktop
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.chkHabilitado = new System.Windows.Forms.CheckBox();
            this.txtConfirmarClave = new System.Windows.Forms.TextBox();
            this.Persona = new System.Windows.Forms.Label();
            this.comboBoxPersona = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.chkHabilitado, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtConfirmarClave, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.Persona, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxPersona, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(416, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(408, 390);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "Confirmar Clave";
            // 
            // chkHabilitado
            // 
            this.chkHabilitado.AutoSize = true;
            this.chkHabilitado.Location = new System.Drawing.Point(3, 2);
            this.chkHabilitado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(93, 21);
            this.chkHabilitado.TabIndex = 8;
            this.chkHabilitado.Text = "Habilitado";
            this.chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // txtConfirmarClave
            // 
            this.txtConfirmarClave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConfirmarClave.Location = new System.Drawing.Point(117, 262);
            this.txtConfirmarClave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConfirmarClave.Name = "txtConfirmarClave";
            this.txtConfirmarClave.PasswordChar = '*';
            this.txtConfirmarClave.Size = new System.Drawing.Size(288, 22);
            this.txtConfirmarClave.TabIndex = 10;
            // 
            // Persona
            // 
            this.Persona.AutoSize = true;
            this.Persona.Location = new System.Drawing.Point(3, 130);
            this.Persona.Name = "Persona";
            this.Persona.Size = new System.Drawing.Size(61, 17);
            this.Persona.TabIndex = 11;
            this.Persona.Text = "Persona";
            // 
            // comboBoxPersona
            // 
            this.comboBoxPersona.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxPersona.FormattingEnabled = true;
            this.comboBoxPersona.Location = new System.Drawing.Point(117, 132);
            this.comboBoxPersona.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxPersona.Name = "comboBoxPersona";
            this.comboBoxPersona.Size = new System.Drawing.Size(288, 24);
            this.comboBoxPersona.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Usuario";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtClave, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtUsuario, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(407, 390);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Clave";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtID.Location = new System.Drawing.Point(66, 2);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(338, 22);
            this.txtID.TabIndex = 4;
            // 
            // txtClave
            // 
            this.txtClave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtClave.Location = new System.Drawing.Point(66, 262);
            this.txtClave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(338, 22);
            this.txtClave.TabIndex = 7;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsuario.Location = new System.Drawing.Point(66, 132);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(338, 22);
            this.txtUsuario.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(827, 441);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.btnAceptar, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnCancelar, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(416, 396);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(408, 43);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAceptar.Location = new System.Drawing.Point(3, 2);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(120, 39);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Guardar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(129, 2);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(129, 39);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // UsuarioDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 441);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UsuarioDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UsuarioDesktop";
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox chkHabilitado;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtConfirmarClave;
        private System.Windows.Forms.Label Persona;
        private System.Windows.Forms.ComboBox comboBoxPersona;
    }
}