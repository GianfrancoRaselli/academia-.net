using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario userSesion = (Usuario)Session["userSesion"];

            if (userSesion != null)
            {
                if (userSesion.Persona.TipoPersona == Persona.TiposPersona.Administrativo)
                {
                    HtmlControl lbl = (HtmlControl) Master.FindControl("lblHomeAdministrativo");
                    lbl.Attributes["style"] = "color: orange;";
                }
                else if (userSesion.Persona.TipoPersona == Persona.TiposPersona.Docente)
                {
                    HtmlControl lbl = (HtmlControl)Master.FindControl("lblHomeDocente");
                    lbl.Attributes["style"] = "color: orange;";
                }
                else if (userSesion.Persona.TipoPersona == Persona.TiposPersona.Alumno)
                {
                    HtmlControl lbl = (HtmlControl)Master.FindControl("lblHomeAlumno");
                    lbl.Attributes["style"] = "color: orange;";
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}