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
    public partial class Personas : ABM
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            Usuario userSesion = (Usuario)Session["userSesion"];

            if (userSesion != null)
            {
                if (userSesion.Persona.TipoPersona == Persona.TiposPersona.Administrativo)
                {
                    HtmlControl lbl = (HtmlControl)Master.FindControl("lblABMAdministrativo");
                    lbl.Attributes["style"] = "color: orange;";

                    lbl = (HtmlControl)Master.FindControl("lblABMPersonasAdministrativo");
                    lbl.Attributes["style"] = "background-color: orange;";

                    LoadGrid();
                    if(!Page.IsPostBack) CargarPlanes();
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

            foreach(Plan p in pl.GetAll())
            {
                item = new ListItem(p.ToString(), p.ID.ToString());
                this.DropDownListPlan.Items.Add(item);
            }
        }

        private PersonaLogic _logic;

        private PersonaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PersonaLogic();
                }
                return _logic;
            }
        }

        private Persona Entity
        {
            get;
            set;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.alerta.Visible = false;
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void EnableForm(bool enable)
        {
            this.nombreTextBox.ReadOnly = !enable;
            this.apellidoTextBox.ReadOnly = !enable;
            this.telefonoTextBox.ReadOnly = !enable;
            this.emailTextBox.ReadOnly = !enable;
            this.direccionTextBox.ReadOnly = !enable;
            this.fechaNacimientoCalendar.Enabled = enable;
            this.RadioButtonListTipoPersona.Enabled = enable;
            this.DropDownListPlan.Enabled = enable;
        }

        private void ClearForm()
        {
            this.legajoTextBox.Text = string.Empty;
            this.nombreTextBox.Text = string.Empty;
            this.apellidoTextBox.Text = string.Empty;
            this.telefonoTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.direccionTextBox.Text = string.Empty;
            this.fechaNacimientoCalendar.SelectedDate = DateTime.Now.Date;
            this.RadioButtonListTipoPersona.SelectedValue = "2";
            this.DropDownListPlan.SelectedValue = "Seleccione un plan";
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.legajoTextBox.Text = this.Entity.Legajo.ToString();
            this.apellidoTextBox.Text = this.Entity.Apellido;
            this.nombreTextBox.Text = this.Entity.Nombre;
            this.telefonoTextBox.Text = this.Entity.Telefono;
            this.emailTextBox.Text = this.Entity.Email;
            this.direccionTextBox.Text = this.Entity.Direccion;
            this.fechaNacimientoCalendar.SelectedDate = this.Entity.FechaNacimiento;
            switch (this.Entity.TipoPersona)
            {
                case Persona.TiposPersona.Administrativo:
                    this.RadioButtonListTipoPersona.SelectedValue = "0";
                    break;
                case Persona.TiposPersona.Docente:
                    this.RadioButtonListTipoPersona.SelectedValue = "1";
                    break;
                case Persona.TiposPersona.Alumno:
                    this.RadioButtonListTipoPersona.SelectedValue = "2";
                    break;
            }
            this.DropDownListPlan.SelectedValue = this.Entity.Plan.ID.ToString();
        }

        private bool LoadEntity(Persona p)
        {
            if(nombreTextBox.Text!="" && apellidoTextBox.Text!="" && telefonoTextBox.Text!="" && emailTextBox.Text!="" &&
                direccionTextBox.Text!="" && RadioButtonListTipoPersona.SelectedValue!=null && 
                DropDownListPlan.SelectedValue!=null && DropDownListPlan.SelectedValue!="Seleccione un plan" &&
                fechaNacimientoCalendar.SelectedDate!=null && fechaNacimientoCalendar.SelectedDate < DateTime.Now)
            {
                p.Nombre = this.nombreTextBox.Text;
                p.Apellido = this.apellidoTextBox.Text;
                p.Telefono = this.telefonoTextBox.Text;
                p.Email = this.emailTextBox.Text;
                p.Direccion = this.direccionTextBox.Text;
                p.FechaNacimiento = this.fechaNacimientoCalendar.SelectedDate;
                switch (this.RadioButtonListTipoPersona.SelectedValue)
                {
                    case "0":
                        p.TipoPersona = Persona.TiposPersona.Administrativo;
                        break;
                    case "1":
                        p.TipoPersona = Persona.TiposPersona.Docente;
                        break;
                    case "2":
                        p.TipoPersona = Persona.TiposPersona.Alumno;
                        break;
                }
                Plan plan = new Plan();
                plan.ID = int.Parse(this.DropDownListPlan.SelectedValue);
                p.Plan = plan;

                return true;
            }
            else
            {
                return false;
            }
        }

        private void SaveEntity(Persona p)
        {
            this.Logic.Save(p);
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
                this.textoAlerta.InnerText = "Seleccione una persona";
                this.alerta.Attributes["style"] = "background-color: #F0B435";
                this.alerta.Visible = true;
            }
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
                this.textoAlerta.InnerText = "Seleccione una persona";
                this.alerta.Attributes["style"] = "background-color: #F0B435";
                this.alerta.Visible = true;
            }
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.Entity = new Persona();
                    if(this.LoadEntity(this.Entity))
                    {
                        try
                        {
                            this.SaveEntity(this.Entity);

                            this.LoadGrid();
                            this.modal.Visible = false;

                            this.textoAlerta.InnerText = "Persona registrada";
                            this.alerta.Attributes["style"] = "background-color: #31DE35";
                            this.alerta.Visible = true;
                        }
                        catch(Exception)
                        {
                            this.textoAlerta.InnerText = "Persona no registrada";
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
                    this.Entity = new Persona();
                    if(this.LoadEntity(this.Entity))
                    {
                        this.Entity.ID = this.SelectedID;
                        this.Entity.State = BusinessEntity.States.Modified;

                        try
                        {
                            this.SaveEntity(this.Entity);

                            this.LoadGrid();
                            this.modal.Visible = false;

                            this.textoAlerta.InnerText = "Persona actualizada";
                            this.alerta.Attributes["style"] = "background-color: #31DE35";
                            this.alerta.Visible = true;
                        }
                        catch(Exception)
                        {
                            this.textoAlerta.InnerText = "Persona no actualizada";
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

                        this.textoAlerta.InnerText = "Persona eliminada";
                        this.alerta.Attributes["style"] = "background-color: #31DE35";
                        this.alerta.Visible = true;
                    }
                    catch(Exception)
                    {
                        this.textoAlerta.InnerText = "Persona no eliminada";
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

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            this.alerta.Visible = false;
            this.modal.Visible = false;
        }
    }
}