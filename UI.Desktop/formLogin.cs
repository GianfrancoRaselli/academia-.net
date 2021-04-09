using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using UI.Desktop;

namespace Lab01
{
    public partial class formLogin : Form
    {
        private UI.Desktop.Menu menuForm;

        public formLogin(UI.Desktop.Menu menuForm)
        {
            this.menuForm = menuForm;
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioLogic ul = new UsuarioLogic();

            Usuario user = new Usuario();
            user.NombreUsuario = this.txtUsuario.Text;
            user.Clave = this.txtPass.Text;

            user = ul.ValidarUsuario(user);

            if (user != null)
            {
                if(user.Persona.TipoPersona == Persona.TiposPersona.Administrativo)
                {
                    menuForm.UsuarioSesion = user;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Acceso denegado", "Login"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Login"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña",
        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}