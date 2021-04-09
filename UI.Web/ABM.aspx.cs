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
    public partial class ABM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario userSesion = (Usuario)Session["userSesion"];

            if (userSesion != null)
            {
                if (userSesion.Persona.TipoPersona == Persona.TiposPersona.Administrativo)
                {

                }
                else if (userSesion.Persona.TipoPersona == Persona.TiposPersona.Docente)
                {
                    Response.Redirect("~/Home.aspx");
                }
                else if (userSesion.Persona.TipoPersona == Persona.TiposPersona.Alumno)
                {
                    Response.Redirect("~/Home.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        public FormModes FormMode
        {
            get
            {
                return (FormModes)this.ViewState["FormMode"];
            }
            set
            {
                this.ViewState["FormMode"] = value;
            }
        }

        protected int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        protected bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }
    }
}