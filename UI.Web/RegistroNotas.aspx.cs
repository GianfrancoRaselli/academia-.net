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
    public partial class RegistroNotas : System.Web.UI.Page
    {
        Usuario userSesion;
        Curso cursoSeleccionado;

        protected void Page_Load(object sender, EventArgs e)
        {
            userSesion = (Usuario)Session["userSesion"];

            if (userSesion != null)
            {
                if (userSesion.Persona.TipoPersona == Persona.TiposPersona.Administrativo)
                {
                    Response.Redirect("~/Home.aspx");
                }
                else if (userSesion.Persona.TipoPersona == Persona.TiposPersona.Docente)
                {
                    HtmlControl lbl = (HtmlControl)Master.FindControl("lblRegistroNotasDocente");
                    lbl.Attributes["style"] = "color: orange;";
                    this.alerta.Visible = false;

                    if (ViewState["IDCursoSeleccionado"] != null)
                    {
                        CursoLogic cl = new CursoLogic();
                        cursoSeleccionado = cl.GetOne(int.Parse((string)ViewState["IDCursoSeleccionado"]));
                    }

                    if (!Page.IsPostBack) CargarCursos();
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

        private void CargarCursos()
        {
            ListItem item = new ListItem("Seleccione un curso", "Seleccione un curso");
            item.Selected = true;
            this.DropDownListCursos.Items.Add(item);

            CursoLogic cl = new CursoLogic();

            foreach (Curso cur in cl.GetCursosDelDocente(userSesion.Persona))
            {
                item = new ListItem(cur.ToString(), cur.ID.ToString());
                this.DropDownListCursos.Items.Add(item);
            }
        }

        private void LoadGrid(Curso curso)
        {
            InscripcionLogic il = new InscripcionLogic();
            this.gridView.DataSource = il.GetInscripcionesDelCurso(curso);
            this.gridView.DataBind();
        }

        protected void guardarLinkButton_Click(object sender, EventArgs e)
        {
            this.alerta.Visible = false;

            if (cursoSeleccionado != null)
            {
                if (verificarNotas())
                {
                    InscripcionLogic il = new InscripcionLogic();

                    foreach (GridViewRow fila in gridView.Rows)
                    {
                        (fila.FindControl("txtNota") as TextBox).Enabled = false;

                        int ID = int.Parse((fila.FindControl("lblID") as Label).Text);
                        int nota = int.Parse((fila.FindControl("txtNota") as TextBox).Text);

                        il.ActualizarNota(ID, nota);
                    }

                    this.guardarLinkButton.Visible = false;
                    this.cancelarEdicionLinkButton.Visible = false;
                    this.habilitarEdicionLinkButton.Visible = true;

                    this.textoAlerta.InnerText = "Las notas han sido actualizadas";
                    this.alerta.Attributes["style"] = "background-color: #31DE35";
                    this.alerta.Visible = true;
                }
                else
                {
                    this.textoAlerta.InnerText = "La notas deben estar entre 0 y 10";
                    this.alerta.Attributes["style"] = "background-color: #EC3434";
                    this.alerta.Visible = true;
                }
            }
            else
            {
                this.textoAlerta.InnerText = "Seleccione un curso";
                this.alerta.Attributes["style"] = "background-color: #F0B435";
                this.alerta.Visible = true;
            }
        }

        private bool verificarNotas()
        {
            bool rta = true;

            foreach (GridViewRow fila in gridView.Rows)
            {
                try
                {
                    int nota = int.Parse((fila.FindControl("txtNota") as TextBox).Text);
                    if(!(nota >= 0 && nota <= 10))
                    {
                        rta = false;
                        break;
                    }
                }
                catch(Exception)
                {
                    rta = false;
                    break;
                }
            }

            return rta;
        }

        protected void habilitarEdicionLinkButton_Click(object sender, EventArgs e)
        {
            if(cursoSeleccionado != null)
            {
                this.alerta.Visible = false;

                foreach (GridViewRow fila in gridView.Rows)
                {
                    (fila.FindControl("txtNota") as TextBox).Enabled = true;
                }

                this.habilitarEdicionLinkButton.Visible = false;
                this.guardarLinkButton.Visible = true;
                this.cancelarEdicionLinkButton.Visible = true;
            }
            else
            {
                this.textoAlerta.InnerText = "Seleccione un curso";
                this.alerta.Attributes["style"] = "background-color: #F0B435";
                this.alerta.Visible = true;
            }
        }

        protected void cancelarEdicionLinkButton_Click(object sender, EventArgs e)
        {
            LoadGrid(cursoSeleccionado);

            foreach (GridViewRow fila in gridView.Rows)
            {
                (fila.FindControl("txtNota") as TextBox).Enabled = false;
            }

            this.guardarLinkButton.Visible = false;
            this.cancelarEdicionLinkButton.Visible = false;
            this.habilitarEdicionLinkButton.Visible = true;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (DropDownListCursos.SelectedValue != "Seleccione un curso")
            {
                this.alerta.Visible = false;

                ViewState["IDCursoSeleccionado"] = this.DropDownListCursos.SelectedValue;
                CursoLogic cl = new CursoLogic();
                cursoSeleccionado = cl.GetOne(int.Parse((string)ViewState["IDCursoSeleccionado"]));

                this.lblCursoSeleccionado.Text = "Curso: " + cursoSeleccionado.ToString();
                this.lblCursoSeleccionado.Visible = true;
                LoadGrid(cursoSeleccionado);
            }
            else
            {
                this.textoAlerta.InnerText = "Seleccione un curso";
                this.alerta.Attributes["style"] = "background-color: #F0B435";
                this.alerta.Visible = true;
            }
        }
    }
}