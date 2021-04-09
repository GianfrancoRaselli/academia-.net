using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Comisiones : ABM
    {
        Usuario userSesion;

        protected new void Page_Load(object sender, EventArgs e)
        {
            userSesion = (Usuario)Session["userSesion"];

            if (userSesion != null)
            {
                if (userSesion.Persona.TipoPersona == Persona.TiposPersona.Administrativo)
                {
                    HtmlControl lbl = (HtmlControl)Master.FindControl("lblABMAdministrativo");
                    lbl.Attributes["style"] = "color: orange;";

                    lbl = (HtmlControl)Master.FindControl("lblABMComisionesAdministrativo");
                    lbl.Attributes["style"] = "background-color: orange;";

                    LoadGrid();
                    if (!Page.IsPostBack) CargarPlanes();
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

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        private void CargarPlanes()
        {
            ListItem item = new ListItem("Seleccione un plan", "Seleccione un plan");
            item.Selected = true;
            this.DropDownListPlan.Items.Add(item);

            PlanLogic pl = new PlanLogic();

            foreach (Plan p in pl.GetAll())
            {
                item = new ListItem(p.ToString(), p.ID.ToString());
                this.DropDownListPlan.Items.Add(item);
            }
        }

        private ComisionLogic _logic;

        private ComisionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new ComisionLogic();
                }
                return _logic;
            }
        }

        private Comision Entity
        {
            get;
            set;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.alerta.Visible = false;
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.idComisionTextbox.Text = this.Entity.ID.ToString();
            this.anioEspecialidadTexBox.Text = this.Entity.AnioEspecialidad.ToString();
            this.descripcionTextBox.Text = this.Entity.Descripcion;
            this.DropDownListPlan.SelectedValue = this.Entity.Plan.ID.ToString();
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.alerta.Visible = false;
                this.modal.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.EnableForm(true);
                this.LoadForm(this.SelectedID);
                this.labelForm.Text = "Editar";
            }
            else
            {
                this.textoAlerta.InnerText = "Seleccione una comisión";
                this.alerta.Attributes["style"] = "background-color: #F0B435";
                this.alerta.Visible = true;
            }
        }

        private bool LoadEntity(Comision comision)
        {
            if (anioEspecialidadTexBox.Text != "" && descripcionTextBox.Text != "" && 
                DropDownListPlan.SelectedValue != null && DropDownListPlan.SelectedValue != "Seleccione un plan")
            {
                try
                {
                    comision.AnioEspecialidad = int.Parse(this.anioEspecialidadTexBox.Text);
                }
                catch(Exception)
                {
                    return false;
                }
                comision.Descripcion = this.descripcionTextBox.Text;
                Plan plan = new Plan();
                plan.ID = int.Parse(this.DropDownListPlan.SelectedValue);
                comision.Plan = plan;

                return true;
            }
            else
            {
                return false;
            }
        }

        private void SaveEntity(Comision comision)
        {
            this.Logic.Save(comision);
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.Entity = new Comision();
                    if (this.LoadEntity(this.Entity))
                    {
                        try 
                        {
                            this.SaveEntity(this.Entity);

                            this.LoadGrid();
                            this.modal.Visible = false;

                            this.textoAlerta.InnerText = "Comisión registrada";
                            this.alerta.Attributes["style"] = "background-color: #31DE35";
                            this.alerta.Visible = true;
                        }
                        catch(Exception)
                        {
                            this.textoAlerta.InnerText = "Comisión no registrada";
                            this.alerta.Attributes["style"] = "background-color: #EC3434";
                            this.alerta.Visible = true;
                        }
                    }
                    else
                    {
                        this.textoAlerta.InnerText = "Revise los datos ingresados";
                        this.alerta.Attributes["style"] = "background-color: #F0B435";
                        this.alerta.Visible = true;
                    }
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Comision();
                    if (this.LoadEntity(this.Entity))
                    {
                        this.Entity.ID = this.SelectedID;
                        this.Entity.State = BusinessEntity.States.Modified;

                        try
                        {
                            this.SaveEntity(this.Entity);

                            this.LoadGrid();
                            this.modal.Visible = false;

                            this.textoAlerta.InnerText = "Comisión actualizada";
                            this.alerta.Attributes["style"] = "background-color: #31DE35";
                            this.alerta.Visible = true;
                        }
                        catch(Exception)
                        {
                            this.textoAlerta.InnerText = "Comisión no actualizada";
                            this.alerta.Attributes["style"] = "background-color: #EC3434";
                            this.alerta.Visible = true;
                        }
                    }
                    else
                    {
                        this.textoAlerta.InnerText = "Revise los datos ingresados";
                        this.alerta.Attributes["style"] = "background-color: #F0B435";
                        this.alerta.Visible = true;
                    }
                    break;
                case FormModes.Baja:
                    try
                    {
                        this.DeleteEntity(this.SelectedID);

                        this.LoadGrid();
                        this.SelectedID = 0;
                        this.modal.Visible = false;

                        this.textoAlerta.InnerText = "Comisión eliminada";
                        this.alerta.Attributes["style"] = "background-color: #31DE35";
                        this.alerta.Visible = true;
                    }
                    catch(Exception)
                    {
                        this.textoAlerta.InnerText = "Comisión no eliminada";
                        this.alerta.Attributes["style"] = "background-color: #EC3434";
                        this.alerta.Visible = true;
                    }
                    break;
                default:
                    this.alerta.Visible = false;
                    this.modal.Visible = false;
                    break;
            }
        }

        private void EnableForm(bool enable)
        {
            this.anioEspecialidadTexBox.ReadOnly = !enable;
            this.descripcionTextBox.ReadOnly = !enable;
            this.DropDownListPlan.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.alerta.Visible = false;
                this.modal.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
                this.labelForm.Text = "Eliminar";
            }
            else
            {
                this.textoAlerta.InnerText = "Seleccione una comisión";
                this.alerta.Attributes["style"] = "background-color: #F0B435";
                this.alerta.Visible = true;
            }
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        protected void agregarLinkButton_Click(object sender, EventArgs e)
        {
            this.alerta.Visible = false;
            this.modal.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
            this.labelForm.Text = "Agregar";
        }

        private void ClearForm()
        {
            this.idComisionTextbox.Text = string.Empty;
            this.anioEspecialidadTexBox.Text = string.Empty;
            this.descripcionTextBox.Text = string.Empty;
            this.DropDownListPlan.SelectedValue = "Seleccione un plan";
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            this.alerta.Visible = false;
            this.modal.Visible = false;
        }
    }
}