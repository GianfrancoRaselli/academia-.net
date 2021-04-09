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
    public partial class Usuarios : ABM
    {
        UsuarioLogic _logic;
        private UsuarioLogic logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            Usuario userSesion = (Usuario)Session["userSesion"];

            if (userSesion != null)
            {
                if (userSesion.Persona.TipoPersona == Persona.TiposPersona.Administrativo)
                {
                    HtmlControl lbl = (HtmlControl)Master.FindControl("lblABMAdministrativo");
                    lbl.Attributes["style"] = "color: orange;";

                    lbl = (HtmlControl)Master.FindControl("lblABMUsuariosAdministrativo");
                    lbl.Attributes["style"] = "background-color: orange;";

                    LoadGrid();
                    if(!Page.IsPostBack) CargarPersonas();
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
            this.gridView.DataSource = this.logic.GetAll();
            this.gridView.DataBind();
        }

        private void CargarPersonas()
        {
            ListItem item = new ListItem("Seleccione una persona", "Seleccione una persona");
            item.Selected = true;
            this.DropDownListUsuarios.Items.Add(item);

            PersonaLogic pl = new PersonaLogic();

            foreach (Persona p in pl.GetAll())
            {
                string strpersona = p.Legajo.ToString() + " - " + p.Nombre.ToString() + " " + p.Apellido.ToString() + " - " + p.Plan.ToString();
                item = new ListItem(strpersona, p.ID.ToString());
                this.DropDownListUsuarios.Items.Add(item);
            }
        }

        private Usuario Entity
        {
            get;
            set;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entity = this.logic.GetOne(id);
            this.idTextbox.Text = this.Entity.ID.ToString();
            this.nombreUsuarioTextbox.Text = this.Entity.NombreUsuario;
            this.claveTextBox.Text = this.Entity.Clave;
            this.habilitadoCheckbox.Checked = (this.Entity.Habilitado);
            this.cambiaClaveCheckbox.Checked = this.Entity.CambiaClave;
            this.DropDownListUsuarios.SelectedValue = this.Entity.Persona.ID.ToString();
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.alerta.Visible = false;
                this.modal.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.ClearForm();
                this.labelForm.Text = "Editar";
                this.EnableForm(true);
                this.LoadForm(this.SelectedID);
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.alerta.Visible = false;
            this.modal.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.labelForm.Text = "Agregar";
            this.EnableForm(true);
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.alerta.Visible = false;
                this.modal.Visible = true;
                this.FormMode = FormModes.Baja;
                this.ClearForm();
                this.labelForm.Text = "Eliminar";
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        private bool LoadEntity(Usuario usuario)
        {
            if(nombreUsuarioTextbox.Text.Length > 5 && claveTextBox.Text.Length > 7 && 
                claveTextBox.Text.Equals(confirmaClaveTextBox.Text) && !DropDownListUsuarios.SelectedValue.Equals("Seleccione una persona"))
            {
                usuario.NombreUsuario = this.nombreUsuarioTextbox.Text;
                usuario.Clave = this.claveTextBox.Text;
                usuario.Habilitado = this.habilitadoCheckbox.Checked;
                usuario.CambiaClave = this.cambiaClaveCheckbox.Checked;
                usuario.Persona.ID = int.Parse(DropDownListUsuarios.SelectedValue);

                return true;
            }
            else
            {
                return false;
            }
        }

        private void SaveEntity(Usuario usuario)
        {
            this.logic.Save(usuario);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    try
                    {
                        this.DeleteEntity(this.SelectedID);

                        this.LoadGrid();
                        this.modal.Visible = false;
                        this.textoAlerta.InnerText = "Usuario Eliminado Exitosamente";
                        this.alerta.Attributes["style"] = "background-color: #31DE35";
                        this.alerta.Visible = true;
                    }
                    catch(Exception Ex)
                    {
                        this.textoAlerta.InnerText = Ex.Message;
                        this.alerta.Attributes["style"] = "background-color: #F0B435";
                        this.alerta.Visible = true;
                    }
                    break;
                case FormModes.Modificacion:
                    Entity = new Usuario();
                    Entity.Persona = new Persona();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;

                    if (this.LoadEntity(Entity))
                    {
                        try
                        {
                            this.SaveEntity(Entity);

                            this.LoadGrid();
                            this.modal.Visible = false;

                            this.modal.Visible = false;
                            this.textoAlerta.InnerText = "Usuario Modificado Exitosamente";
                            this.alerta.Attributes["style"] = "background-color: #31DE35";
                            this.alerta.Visible = true;
                        }
                        catch(Exception Ex)
                        {
                            this.textoAlerta.InnerText = Ex.Message;
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
                case FormModes.Alta:
                    this.Entity = new Usuario();
                    this.Entity.Persona = new Persona();

                    if (this.LoadEntity(this.Entity))
                    {
                        try
                        {
                            this.SaveEntity(this.Entity);

                            this.LoadGrid();
                            this.modal.Visible = false;
                            this.textoAlerta.InnerText = "Usuario Creado Exitosamente";
                            this.alerta.Attributes["style"] = "background-color: #31DE35";
                            this.alerta.Visible = true;
                        }
                        catch(Exception Ex)
                        {
                            this.textoAlerta.InnerText = Ex.Message;
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
                default:
                    this.alerta.Visible = false;
                    this.modal.Visible = false;
                    break;
            }
        }

        private void EnableForm(bool enable)
        {
            this.idTextbox.Enabled = false;
            this.cambiaClaveCheckbox.Enabled = false;
            this.nombreUsuarioTextbox.Enabled = enable;
            this.claveTextBox.Enabled = enable;
            this.confirmaClaveTextBox.Enabled = enable;
            this.habilitadoCheckbox.Enabled = enable;
            this.DropDownListUsuarios.Enabled = enable;
        }

        private void DeleteEntity(int id)
        {
            this.logic.Delete(id);
        }

        private void ClearForm()
        {
            this.idTextbox.Text = string.Empty;
            this.nombreUsuarioTextbox.Text = string.Empty;
            this.claveTextBox.Text = string.Empty;
            this.habilitadoCheckbox.Checked = false;
            this.cambiaClaveCheckbox.Checked = false;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.EnableForm(false);
            this.alerta.Visible = false;
            this.modal.Visible = false;
        }
    }
}