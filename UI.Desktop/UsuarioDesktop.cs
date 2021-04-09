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
using Business.Entities;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        private Usuario _usuarioActual;

        public Usuario UsuarioActual
        {
            set
            {
                _usuarioActual = value;
            }
            get
            {
                return _usuarioActual;
            }
        }

        public UsuarioDesktop()
        {
            InitializeComponent();
            CargarPersonas();
        }


        private void CargarPersonas()
        {
            PersonaLogic pl = new PersonaLogic();

            foreach (Persona per in pl.GetAll())
            {
                comboBoxPersona.Items.Add(per);
            }
        }

        public UsuarioDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(ID);
            this.MapearDeDatos();
            if(this.Modo == ModoForm.Baja)
            {
                this.DeshabilitarCampos();
            }
        }

        public void DeshabilitarCampos()
        {
            this.chkHabilitado.Enabled = false;
            this.txtClave.ReadOnly = true;
            this.txtConfirmarClave.ReadOnly = true;
            this.txtUsuario.ReadOnly = true;
            this.comboBoxPersona.Enabled = false;
        }

        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.comboBoxPersona.Text = this.UsuarioActual.Persona.ToString();
            

            switch (Modo)
            {
                case ModoForm.Modificacion:
                case ModoForm.Alta: 
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
            }
        }

        public override void MapearADatos() 
        {
            if(Modo == ModoForm.Alta)
            {
                UsuarioActual = new Usuario();
                UsuarioActual.CambiaClave = false;
            }

            if (Modo == ModoForm.Modificacion)
            {
                UsuarioActual.ID = int.Parse(this.txtID.Text);
                UsuarioActual.State = BusinessEntity.States.Modified;
                if(UsuarioActual.Clave == this.txtClave.Text)
                {
                    UsuarioActual.CambiaClave = false;
                }
                else if (UsuarioActual.Clave != this.txtClave.Text)
                {
                    UsuarioActual.CambiaClave = true;
                }
            }

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                UsuarioActual.Clave = this.txtClave.Text;
                UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                UsuarioActual.Persona = (Persona)this.comboBoxPersona.SelectedItem;
            }
        }

        public override void GuardarCambios() 
        {
            UsuarioLogic ul = new UsuarioLogic();
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                ul.Save(UsuarioActual);
            }
            else if (Modo == ModoForm.Baja)
            {
                ul.Delete(UsuarioActual.ID);
            }
        }

        public override bool Validar() 
        { 
            if(txtUsuario.Text != "" && txtClave.Text != "" && txtConfirmarClave.Text != "" && comboBoxPersona.SelectedItem != null)
            {
                if (txtUsuario.TextLength >= 6)
                {
                    if (txtClave.TextLength >= 8)
                    {
                        if (txtClave.Text == txtConfirmarClave.Text)
                        {
                            return true;
                        }
                        else
                        {
                            this.Notificar("Invalido", "Las contraseñas no coinciden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        this.Notificar("Invalido", "La contraseña debe tener 8 caracteres como minimo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    this.Notificar("Invalido", "El nombre de usuario debe tener 6 caracteres como minimo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                this.Notificar("Invalido", "Completa todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(Validar())
            {
                try
                {
                    this.GuardarCambios();
                    this.Close();
                }
                catch(Exception ex)
                {
                    this.Notificar("Invalido", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
