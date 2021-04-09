using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class InscripcionCursos : System.Web.UI.Page
    {
        Usuario userSesion;

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
                    Response.Redirect("~/Home.aspx");
                }
                else if (userSesion.Persona.TipoPersona == Persona.TiposPersona.Alumno)
                {
                    HtmlControl lbl = (HtmlControl)Master.FindControl("lblInscripcionCursosAlumno");
                    lbl.Attributes["style"] = "color: orange;";

                    lblPlan.Text = "Materias - Plan: " + userSesion.Persona.Plan;
                    LoadGrid();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        private void LoadGrid()
        {
            MateriaLogic ml = new MateriaLogic();
            List<Materia> materiasDelPlan = ml.GetMateriasDelPlan(userSesion.Persona.Plan);

            InscripcionLogic il = new InscripcionLogic();
            List<AlumnoInscripcion> inscripcionesDelAlumno = il.GetInscripcionesDelAlumno(userSesion.Persona);

            foreach(Materia mat in materiasDelPlan)
            {
                foreach(AlumnoInscripcion alumnoInsc in inscripcionesDelAlumno)
                {
                    if(alumnoInsc.Curso.Materia.ID == mat.ID &&
                        (alumnoInsc.Condicion == AlumnoInscripcion.Condiciones.Aprobada || 
                        alumnoInsc.Condicion == AlumnoInscripcion.Condiciones.Inscripto))
                    {
                        mat.CondicionAlumno = alumnoInsc.Condicion;
                        mat.NotaAlumno = alumnoInsc.Nota;
                        break;
                    }

                    if(alumnoInsc.Curso.Materia.ID == mat.ID && 
                        alumnoInsc.Condicion == AlumnoInscripcion.Condiciones.Regular)
                    {
                        mat.CondicionAlumno = alumnoInsc.Condicion;
                        mat.NotaAlumno = alumnoInsc.Nota;
                    }
                }
            }

            this.gridView.DataSource = materiasDelPlan;
            this.gridView.DataBind();
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

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.alerta.Visible = false;
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        protected void verComisionesLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                MateriaLogic ml = new MateriaLogic();
                Materia materiaSeleccionada = ml.GetOne(this.SelectedID);

                InscripcionLogic il = new InscripcionLogic();
                List<AlumnoInscripcion> inscripcionesDelAlumno = il.GetInscripcionesDelAlumno(userSesion.Persona);

                foreach (AlumnoInscripcion alumnoInsc in inscripcionesDelAlumno)
                {
                    if (alumnoInsc.Curso.Materia.ID == materiaSeleccionada.ID &&
                        (alumnoInsc.Condicion == AlumnoInscripcion.Condiciones.Aprobada ||
                        alumnoInsc.Condicion == AlumnoInscripcion.Condiciones.Inscripto))
                    {
                        materiaSeleccionada.CondicionAlumno = alumnoInsc.Condicion;
                        materiaSeleccionada.NotaAlumno = alumnoInsc.Nota;
                        break;
                    }

                    if (alumnoInsc.Curso.Materia.ID == materiaSeleccionada.ID &&
                        alumnoInsc.Condicion == AlumnoInscripcion.Condiciones.Regular)
                    {
                        materiaSeleccionada.CondicionAlumno = alumnoInsc.Condicion;
                        materiaSeleccionada.NotaAlumno = alumnoInsc.Nota;
                    }
                }

                if(materiaSeleccionada.CondicionAlumno != AlumnoInscripcion.Condiciones.Aprobada)
                {
                    VerificarMateriasCorrelativasLogic vmcl = new VerificarMateriasCorrelativasLogic();

                    if (vmcl.PuedeInscribirse(userSesion.Persona, materiaSeleccionada))
                    {
                        Response.Redirect("~/ComisionesDisponibles.aspx?IdMateria=" + this.SelectedID);
                    }
                    else
                    {
                        this.textoAlerta.InnerText = "Tiene materias correlativas pendientes";
                        this.alerta.Attributes["style"] = "background-color: #F0B435";
                        this.alerta.Visible = true;
                    }
                }
                else
                {
                    this.textoAlerta.InnerText = "Materia aprobada anteriormente";
                    this.alerta.Attributes["style"] = "background-color: #F0B435";
                    this.alerta.Visible = true;
                }
            }
            else
            {
                this.textoAlerta.InnerText = "Seleccione una materia";
                this.alerta.Attributes["style"] = "background-color: #F0B435";
                this.alerta.Visible = true;
            }
        }

        protected void verMateriasCorrelativasLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                Response.Redirect("~/MateriasCorrelativas.aspx?IdMateria=" + this.SelectedID);
            }
            else
            {
                this.textoAlerta.InnerText = "Seleccione una materia";
                this.alerta.Attributes["style"] = "background-color: #F0B435";
                this.alerta.Visible = true;
            }
        }
    }
}