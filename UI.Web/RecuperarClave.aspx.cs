using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Net.Mail;
using System.Net;
using System.Drawing;

namespace UI.Web
{
    public partial class RecuperarClave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario userSesion = (Usuario)Session["userSesion"];

            if (userSesion != null)
            {
                Response.Redirect("~/Home.aspx");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.lblErrorLegajo.Text = "";
            this.lblError.Text = "";

            if(this.txtLegajo.Text.Length < 4)
            {
                this.lblErrorLegajo.Text = "Mínimo 4 dígitos";
            }
            else
            {
                try
                {
                    int legajo = int.Parse(this.txtLegajo.Text);
                    this.txtLegajo.Text = "";

                    UsuarioLogic ul = new UsuarioLogic();
                    Usuario user = ul.BuscarPorLegajo(legajo);

                    if(user != null)
                    { 
                        this.panelLegajo.Visible = false;
                        this.lblCorreo.Text = "¿Es " + user.Persona.Email + " su correo?";
                        this.btnConfirmar.Text = "Confirmar";
                        this.panelCorreo.Visible = true;

                        Session["userARecuperar"] = user;
                    }
                    else
                    {
                        this.lblError.Text = "No existe persona con legajo " + legajo;
                    }
                }
                catch(Exception)
                {
                    this.lblErrorLegajo.Text = "El legajo debe ser numérico";
                }
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            Usuario user = (Usuario)Session["userARecuperar"];
            SmtpClient smtp = null;

            try
            {
                smtp = new SmtpClient();
                smtp.Credentials = new NetworkCredential("recuperarusuarioutn@gmail.com", ".net2020");
                smtp.Port = 25;
                smtp.Host = "smtp.gmail.com";
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("RecuperarUsuarioUTN@gmail.com", "Recuperar Usuario UTN");
                mail.To.Add(new MailAddress(user.Persona.Email));
                mail.Subject = "Recuperar Usuario";
                mail.Body = "Nombre Usuario: " + user.NombreUsuario + " - Contraseña: " + user.Clave;

                smtp.Send(mail);
                this.lblCorreo.ForeColor = Color.Black;
                this.lblCorreo.Text = "Se ha enviado un correo a " + user.Persona.Email;
            }
            catch(Exception)
            {
                this.lblCorreo.ForeColor = Color.Red;
                this.lblCorreo.Text = "No se pudo enviar correo a " + user.Persona.Email;
            }
            finally
            {
                if(smtp != null) smtp.Dispose();            
            }

            this.btnConfirmar.Text = "Volver a enviar";
        }

        protected void lnkVolverInicioSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void lnkVolver_Click(object sender, EventArgs e)
        {
            this.panelCorreo.Visible = false;
            this.panelLegajo.Visible = true;
        }
    }
}