using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Web.UI.HtmlControls;

namespace UI.Web
{
    public partial class ReporteComisiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario userSesion = (Usuario)Session["userSesion"];

            if (userSesion != null)
            {
                if (userSesion.Persona.TipoPersona == Persona.TiposPersona.Administrativo)
                {
                    HtmlControl lbl = (HtmlControl)Master.FindControl("lblReportesAdministrativo");
                    lbl.Attributes["style"] = "color: orange;";

                    lbl = (HtmlControl)Master.FindControl("lblReporteComisionesAdministrativo");
                    lbl.Attributes["style"] = "background-color: orange;";
                }
                else if (userSesion.Persona.TipoPersona == Persona.TiposPersona.Docente)
                {
                    HtmlControl lbl = (HtmlControl)Master.FindControl("lblReportesDocente");
                    lbl.Attributes["style"] = "color: orange;";

                    lbl = (HtmlControl)Master.FindControl("lblReporteComisionesDocente");
                    lbl.Attributes["style"] = "background-color: orange;";
                }
                else if (userSesion.Persona.TipoPersona == Persona.TiposPersona.Alumno)
                {
                    HtmlControl lbl = (HtmlControl)Master.FindControl("lblReportesAlumno");
                    lbl.Attributes["style"] = "color: orange;";

                    lbl = (HtmlControl)Master.FindControl("lblReporteComisionesAlumno");
                    lbl.Attributes["style"] = "background-color: orange;";
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}