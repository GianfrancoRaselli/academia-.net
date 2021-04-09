using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Perfil : System.Web.UI.Page
    {
        Usuario userSesion;

        protected void Page_Load(object sender, EventArgs e)
        {
            userSesion = (Usuario)Session["userSesion"];

            if (userSesion != null)
            {
                if (userSesion.Persona.TipoPersona == Persona.TiposPersona.Administrativo)
                {
                    HtmlControl lbl = (HtmlControl)Master.FindControl("lblUsuarioAdministrativo");
                    lbl.Attributes["style"] = "color: orange;";
                }
                else if (userSesion.Persona.TipoPersona == Persona.TiposPersona.Docente)
                {
                    HtmlControl lbl = (HtmlControl)Master.FindControl("lblUsuarioDocente");
                    lbl.Attributes["style"] = "color: orange;";
                }
                else if (userSesion.Persona.TipoPersona == Persona.TiposPersona.Alumno)
                {
                    HtmlControl lbl = (HtmlControl)Master.FindControl("lblUsuarioAlumno");
                    lbl.Attributes["style"] = "color: orange;";
                }

                cargarPerfil();
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        private void cargarPerfil()
        {
            lblLegajo.Text = userSesion.Persona.Legajo.ToString();
            lblNombre.Text = userSesion.Persona.Nombre;
            lblApellido.Text = userSesion.Persona.Apellido;
            lblFechaNacimiento.Text = userSesion.Persona.FechaNacimientoConFormato;
            lblEdad.Text = userSesion.Persona.Edad.ToString();
            lblDireccion.Text = userSesion.Persona.Direccion;
            lblTelefono.Text = userSesion.Persona.Telefono;
            lblEmail.Text = userSesion.Persona.Email;
            lblNombreUsuario.Text = userSesion.NombreUsuario;
            lblClave.Text = "";
            for(int i = 0; i < userSesion.Clave.Length; i++)
            {
                lblClave.Text = lblClave.Text + "*";
            }
        }

        private Usuario crearUsuario()
        {
            Usuario userActualizado = new Usuario();
            Persona personaActualizada = new Persona();

            userActualizado.ID = userSesion.ID;
            userActualizado.NombreUsuario = userSesion.NombreUsuario;
            userActualizado.Clave = userSesion.Clave;
            userActualizado.Habilitado = userSesion.Habilitado;
            userActualizado.CambiaClave = userSesion.CambiaClave;
            userActualizado.Persona = personaActualizada;
            userActualizado.State = BusinessEntity.States.Unmodified;

            personaActualizada.ID = userSesion.Persona.ID;
            personaActualizada.Nombre = userSesion.Persona.Nombre;
            personaActualizada.Apellido = userSesion.Persona.Apellido;
            personaActualizada.FechaNacimiento = userSesion.Persona.FechaNacimiento;
            personaActualizada.Legajo = userSesion.Persona.Legajo;
            personaActualizada.Direccion = userSesion.Persona.Direccion;
            personaActualizada.Telefono = userSesion.Persona.Telefono;
            personaActualizada.Email = userSesion.Persona.Email;
            personaActualizada.TipoPersona = userSesion.Persona.TipoPersona;
            personaActualizada.Plan = userSesion.Persona.Plan;
            personaActualizada.State = BusinessEntity.States.Unmodified;

            return userActualizado;
        }

        protected void LinkButtonEditar_Click(object sender, EventArgs e)
        {
            this.alerta.Visible = false;

            LinkButton linkButton = (LinkButton)sender;
            
            linkButton.Visible = false;
            switch(linkButton.ID)
            {
                case "LinkButtonEditarDireccion":
                    this.LinkButtonGuardarDireccion.Visible = true;
                    this.LinkButtonCancelarDireccion.Visible = true;
                    this.lblDireccion.Visible = false;
                    this.txtDireccion.Visible = true;
                    break;
                case "LinkButtonEditarTelefono":
                    this.LinkButtonGuardarTelefono.Visible = true;
                    this.LinkButtonCancelarTelefono.Visible = true;
                    this.lblTelefono.Visible = false;
                    this.txtTelefono.Visible = true;
                    break;
                case "LinkButtonEditarEmail":
                    this.LinkButtonGuardarEmail.Visible = true;
                    this.LinkButtonCancelarEmail.Visible = true;
                    this.lblEmail.Visible = false;
                    this.txtEmail.Visible = true;
                    break;
                case "LinkButtonEditarNombreUsuario":
                    this.LinkButtonGuardarNombreUsuario.Visible = true;
                    this.LinkButtonCancelarNombreUsuario.Visible = true;
                    this.lblNombreUsuario.Visible = false;
                    this.txtNombreUsuario.Visible = true;
                    break;
                case "LinkButtonEditarClave":
                    this.LinkButtonGuardarClave.Visible = true;
                    this.LinkButtonCancelarClave.Visible = true;
                    this.lblClave.Visible = false;
                    this.txtClave.Visible = true;
                    break;
            }
        }

        protected void LinkButtonCancelar_Click(object sender, EventArgs e)
        {
            this.alerta.Visible = false;

            LinkButton linkButton = (LinkButton)sender;

            linkButton.Visible = false;
            switch (linkButton.ID)
            {
                case "LinkButtonCancelarDireccion":
                    this.LinkButtonGuardarDireccion.Visible = false;
                    this.LinkButtonEditarDireccion.Visible = true;
                    this.txtDireccion.Visible = false;
                    this.lblDireccion.Visible = true;
                    break;
                case "LinkButtonCancelarTelefono":
                    this.LinkButtonGuardarTelefono.Visible = false;
                    this.LinkButtonEditarTelefono.Visible = true;
                    this.txtTelefono.Visible = false;
                    this.lblTelefono.Visible = true;
                    break;
                case "LinkButtonCancelarEmail":
                    this.LinkButtonGuardarEmail.Visible = false;
                    this.LinkButtonEditarEmail.Visible = true;
                    this.txtEmail.Visible = false;
                    this.lblEmail.Visible = true;
                    break;
                case "LinkButtonCancelarNombreUsuario":
                    this.LinkButtonGuardarNombreUsuario.Visible = false;
                    this.LinkButtonEditarNombreUsuario.Visible = true;
                    this.txtNombreUsuario.Visible = false;
                    this.lblNombreUsuario.Visible = true;
                    break;
                case "LinkButtonCancelarClave":
                    this.LinkButtonGuardarClave.Visible = false;
                    this.LinkButtonEditarClave.Visible = true;
                    this.txtClave.Visible = false;
                    this.lblClave.Visible = true;
                    break;
            }
        }

        protected void LinkButtonGuardar_Click(object sender, EventArgs e)
        {
            this.alerta.Visible = false;

            UsuarioLogic ul = new UsuarioLogic();
            PersonaLogic pl = new PersonaLogic();

            Usuario userAActualizar = crearUsuario();

            LinkButton linkButton = (LinkButton)sender;
            switch (linkButton.ID)
            {
                case "LinkButtonGuardarDireccion":
                    userAActualizar.Persona.Direccion = this.txtDireccion.Text;
                    userAActualizar.Persona.State = BusinessEntity.States.Modified;

                    try
                    {
                        pl.Save(userAActualizar.Persona);

                        Session["userSesion"] = userAActualizar;
                        userSesion = userAActualizar;
                        cargarPerfil();

                        linkButton.Visible = false;
                        this.LinkButtonCancelarDireccion.Visible = false;
                        this.LinkButtonEditarDireccion.Visible = true;
                        this.txtDireccion.Visible = false;
                        this.lblDireccion.Visible = true;

                        this.textoAlerta.InnerText = "Dirección actualizada";
                        this.alerta.Attributes["style"] = "background-color: #31DE35";
                        this.alerta.Visible = true;
                    }
                    catch(Exception)
                    {
                        this.textoAlerta.InnerText = "Dirección no actualizada";
                        this.alerta.Attributes["style"] = "background-color: #EC3434";
                        this.alerta.Visible = true;
                    }
                    break;
                case "LinkButtonGuardarTelefono":
                    userAActualizar.Persona.Telefono = this.txtTelefono.Text;
                    userAActualizar.Persona.State = BusinessEntity.States.Modified;

                    try
                    {
                        pl.Save(userAActualizar.Persona);

                        Session["userSesion"] = userAActualizar;
                        userSesion = userAActualizar;
                        cargarPerfil();

                        linkButton.Visible = false;
                        this.LinkButtonCancelarTelefono.Visible = false;
                        this.LinkButtonEditarTelefono.Visible = true;
                        this.txtTelefono.Visible = false;
                        this.lblTelefono.Visible = true;

                        this.textoAlerta.InnerText = "Teléfono actualizado";
                        this.alerta.Attributes["style"] = "background-color: #31DE35";
                        this.alerta.Visible = true;
                    }
                    catch(Exception)
                    {
                        this.textoAlerta.InnerText = "Teléfono no actualizado";
                        this.alerta.Attributes["style"] = "background-color: #EC3434";
                        this.alerta.Visible = true;
                    }
                    break;
                case "LinkButtonGuardarEmail":
                    userAActualizar.Persona.Email = this.txtEmail.Text;
                    userAActualizar.Persona.State = BusinessEntity.States.Modified;

                    try
                    {
                        pl.Save(userAActualizar.Persona);

                        Session["userSesion"] = userAActualizar;
                        userSesion = userAActualizar;
                        cargarPerfil();

                        linkButton.Visible = false;
                        this.LinkButtonCancelarEmail.Visible = false;
                        this.LinkButtonEditarEmail.Visible = true;
                        this.txtEmail.Visible = false;
                        this.lblEmail.Visible = true;

                        this.textoAlerta.InnerText = "Email actualizado";
                        this.alerta.Attributes["style"] = "background-color: #31DE35";
                        this.alerta.Visible = true;
                    }
                    catch(Exception)
                    {
                        this.textoAlerta.InnerText = "Email no actualizado";
                        this.alerta.Attributes["style"] = "background-color: #EC3434";
                        this.alerta.Visible = true;
                    }
                    break;
                case "LinkButtonGuardarNombreUsuario":
                    userAActualizar.NombreUsuario = this.txtNombreUsuario.Text;
                    userAActualizar.State = BusinessEntity.States.Modified;

                    try
                    {
                        ul.Save(userAActualizar);

                        Session["userSesion"] = userAActualizar;
                        userSesion = userAActualizar;
                        cargarPerfil();

                        linkButton.Visible = false;
                        this.LinkButtonCancelarNombreUsuario.Visible = false;
                        this.LinkButtonEditarNombreUsuario.Visible = true;
                        this.txtNombreUsuario.Visible = false;
                        this.lblNombreUsuario.Visible = true;

                        this.textoAlerta.InnerText = "Usuario actualizado";
                        this.alerta.Attributes["style"] = "background-color: #31DE35";
                        this.alerta.Visible = true;
                    }
                    catch(Exception)
                    {
                        this.textoAlerta.InnerText = "Usuario no actualizado";
                        this.alerta.Attributes["style"] = "background-color: #EC3434";
                        this.alerta.Visible = true;
                    }
                    break;
                case "LinkButtonGuardarClave":
                    userAActualizar.Clave = this.txtClave.Text;
                    userAActualizar.CambiaClave = true;
                    userAActualizar.State = BusinessEntity.States.Modified;

                    try
                    {
                        ul.Save(userAActualizar);

                        Session["userSesion"] = userAActualizar;
                        userSesion = userAActualizar;
                        cargarPerfil();

                        linkButton.Visible = false;
                        this.LinkButtonCancelarClave.Visible = false;
                        this.LinkButtonEditarClave.Visible = true;
                        this.txtClave.Visible = false;
                        this.lblClave.Visible = true;

                        this.textoAlerta.InnerText = "Clave actualizada";
                        this.alerta.Attributes["style"] = "background-color: #31DE35";
                        this.alerta.Visible = true;
                    }
                    catch(Exception)
                    {
                        this.textoAlerta.InnerText = "Clave no actualizada";
                        this.alerta.Attributes["style"] = "background-color: #EC3434";
                        this.alerta.Visible = true;
                    }
                    break;
            }
        }
    }
}