using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;
using System.Net;

namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario userSesion = (Usuario)Session["userSesion"];

            if (userSesion != null)
            { 
                Response.Redirect("~/Home.aspx");
            }
            else
            {
                HttpCookie cookieNombreUsuario = Request.Cookies["cookieNombreUsuario"];
                HttpCookie cookieClave = Request.Cookies["cookieClave"];

                if (cookieNombreUsuario != null && cookieClave != null)
                {
                    string nombreUsuario = cookieNombreUsuario.Value;
                    string clave = cookieClave.Value;

                    if (nombreUsuario != null && clave != null && !nombreUsuario.Equals("") && !clave.Equals(""))
                    {
                        UsuarioLogic ul = new UsuarioLogic();

                        Usuario user = new Usuario();
                        user.NombreUsuario = nombreUsuario;
                        user.Clave = clave;

                        user = ul.ValidarUsuario(user);

                        if (user != null)
                        {
                            Session["userSesion"] = user;

                            Response.Redirect("~/Home.aspx");
                        }
                    }
                }       
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            this.lblErrorInicioSesion.Text = "";

            if (this.txtUsuario.Text.Length < 6)
            {
                this.lblErrorNombreUsuario.Text = "Mínimo 6 caracteres";
            }
            else 
            {
                this.lblErrorNombreUsuario.Text = "";
            }

            if(this.txtClave.Text.Length < 8)
            {
                this.lblErrorContrasenia.Text = "Mínimo 8 caracteres";
            }
            else
            {
                this.lblErrorContrasenia.Text = "";
            }

            if(this.txtUsuario.Text.Length >= 6 && this.txtClave.Text.Length >= 8)
            {
                UsuarioLogic ul = new UsuarioLogic();

                Usuario user = new Usuario();
                user.NombreUsuario = this.txtUsuario.Text;
                user.Clave = this.txtClave.Text;

                user = ul.ValidarUsuario(user);

                if (user != null)
                {
                    Session["userSesion"] = user;

                    HttpCookie cookieNombreUsuario = new HttpCookie("cookieNombreUsuario");
                    cookieNombreUsuario.Value = user.NombreUsuario;
                    cookieNombreUsuario.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cookieNombreUsuario);

                    HttpCookie cookieClave = new HttpCookie("cookieClave");
                    cookieClave.Value = user.Clave;
                    cookieClave.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cookieClave);

                    Response.Redirect("~/Home.aspx");
                }
                else
                {
                    this.lblErrorInicioSesion.Text = "Usuario y/o clave incorrectos";
                }
            }
        }

        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RecuperarClave.aspx");
        }
    }
}