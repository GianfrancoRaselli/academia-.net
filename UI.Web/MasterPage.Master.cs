using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario userSesion = (Usuario)Session["userSesion"];

            if (userSesion != null)
            {
                if(userSesion.Persona.TipoPersona == Persona.TiposPersona.Administrativo)
                {
                    this.navbarAdministrativo.Visible = true;
                    this.lblNombreUsuarioAdministrativo.Text = userSesion.NombreUsuario;
                }
                else if (userSesion.Persona.TipoPersona == Persona.TiposPersona.Docente)
                {
                    this.navbarDocente.Visible = true;
                    this.lblNombreUsuarioDocente.Text = userSesion.NombreUsuario;
                }
                else if (userSesion.Persona.TipoPersona == Persona.TiposPersona.Alumno)
                {
                    this.navbarAlumno.Visible = true;
                    this.lblNombreUsuarioAlumno.Text = userSesion.NombreUsuario;
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            HttpCookie cookieNombreUsuario = new HttpCookie("cookieNombreUsuario");
            cookieNombreUsuario.Value = "";
            cookieNombreUsuario.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookieNombreUsuario);

            HttpCookie cookieClave = new HttpCookie("cookieClave");
            cookieClave.Value = "";
            cookieClave.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookieClave);

            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}