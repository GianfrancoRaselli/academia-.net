using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class ComisionesDisponibles : System.Web.UI.Page
    {
        Usuario userSesion;
        private Materia materia;

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
                    if (Request.QueryString["IdMateria"] != null)
                    {
                        try
                        {
                            if (int.Parse(Request.QueryString["IdMateria"]) > 0)
                            {
                                MateriaLogic ml = new MateriaLogic();
                                materia = ml.GetOne(int.Parse(Request.QueryString["IdMateria"]));

                                if(materia != null)
                                {
                                    if (materia.Plan.ID == userSesion.Persona.Plan.ID)
                                    {
                                        InscripcionLogic il = new InscripcionLogic();
                                        List<AlumnoInscripcion> inscripcionesDelAlumno = il.GetInscripcionesDelAlumno(userSesion.Persona);

                                        foreach (AlumnoInscripcion alumnoInsc in inscripcionesDelAlumno)
                                        {
                                            if (alumnoInsc.Curso.Materia.ID == materia.ID &&
                                                (alumnoInsc.Condicion == AlumnoInscripcion.Condiciones.Aprobada ||
                                                alumnoInsc.Condicion == AlumnoInscripcion.Condiciones.Inscripto))
                                            {
                                                materia.CondicionAlumno = alumnoInsc.Condicion;
                                                materia.NotaAlumno = alumnoInsc.Nota;
                                                break;
                                            }

                                            if (alumnoInsc.Curso.Materia.ID == materia.ID &&
                                                alumnoInsc.Condicion == AlumnoInscripcion.Condiciones.Regular)
                                            {
                                                materia.CondicionAlumno = alumnoInsc.Condicion;
                                                materia.NotaAlumno = alumnoInsc.Nota;
                                            }
                                        }

                                        if (materia.CondicionAlumno != AlumnoInscripcion.Condiciones.Aprobada)
                                        {
                                            VerificarMateriasCorrelativasLogic vmcl = new VerificarMateriasCorrelativasLogic();

                                            if (vmcl.PuedeInscribirse(userSesion.Persona, materia))
                                            {
                                                HtmlControl lbl = (HtmlControl)Master.FindControl("lblInscripcionCursosAlumno");
                                                lbl.Attributes["style"] = "color: orange;";

                                                LoadGrid();
                                            }
                                            else
                                            {
                                                Response.Redirect("~/InscripcionCursos.aspx");
                                            }
                                        }
                                        else
                                        {
                                            Response.Redirect("~/InscripcionCursos.aspx");
                                        }
                                    }
                                    else
                                    {
                                        Response.Redirect("~/InscripcionCursos.aspx");
                                    }
                                }
                                else
                                {
                                    Response.Redirect("~/InscripcionCursos.aspx");
                                }
                            }
                            else
                            {
                                Response.Redirect("~/InscripcionCursos.aspx");
                            }
                        }
                        catch(Exception)
                        {
                            Response.Redirect("~/InscripcionCursos.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("~/InscripcionCursos.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        private void LoadGrid()
        {
            CursoLogic cl = new CursoLogic();
            List<Curso> cursosDeLaMateriaDisponibles = cl.GetCursosDeLaMateriaDisponibles(materia);

            if(cursosDeLaMateriaDisponibles == null || cursosDeLaMateriaDisponibles.Count() == 0)
            {
                lblMateria.Text = "La Materia " + materia.Descripcion + " no tiene cursos disponibles actualmente";
            }
            else
            {
                InscripcionLogic il = new InscripcionLogic();
                List<AlumnoInscripcion> inscripcionesDelAlumno = il.GetInscripcionesDelAlumno(userSesion.Persona);

                foreach (Curso cur in cursosDeLaMateriaDisponibles)
                {
                    foreach(AlumnoInscripcion alins in inscripcionesDelAlumno)
                    {
                        if(alins.Curso.ID == cur.ID)
                        {
                            cur.CondicionAlumno = "Inscripto";
                            break;
                        }
                    }

                    if(cur.CondicionAlumno == null)
                    {
                        cur.CondicionAlumno = "No Inscripto";
                    }
                }

                lblMateria.Text = "Materia: " + materia.Descripcion;
                this.gridView.DataSource = cursosDeLaMateriaDisponibles;
                this.gridView.DataBind();
            }
        }

        private void LoadForm(Curso cur)
        {
            this.ViewState["IdCurso"] = cur.ID;
            this.materiaLabel.Text = "Materia: " + cur.Materia.Descripcion;
            this.comisionLabel.Text = "Comisión: " + cur.Comision.Descripcion;
            this.anioCalendarioLabel.Text = "Año: " + cur.AnioCalendario.ToString();
            this.cuatrimestreLabel.Text = "Cuatrimestre: " + cur.TipoCuatrimestre.ToString();
            this.condicionAlumnoLabel.Text = "Estado: " + cur.CondicionAlumno;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.alerta.Visible = false;

            CursoLogic cl = new CursoLogic();
            Curso cursoSeleccionado = cl.GetOne((int)gridView.SelectedValue);

            if(cursoSeleccionado != null)
            {
                InscripcionLogic il = new InscripcionLogic();
                List<AlumnoInscripcion> inscripcionesDelAlumno = il.GetInscripcionesDelAlumno(userSesion.Persona);

                cursoSeleccionado.CondicionAlumno = "No Inscripto";
                foreach (AlumnoInscripcion alins in inscripcionesDelAlumno)
                {
                    if (alins.Curso.ID == cursoSeleccionado.ID)
                    {
                        cursoSeleccionado.CondicionAlumno = "Inscripto";
                        break;
                    }
                }

                LoadForm(cursoSeleccionado);

                if (cursoSeleccionado.CondicionAlumno == "No Inscripto")
                {
                    btnAceptar.Text = "Inscribirse";

                    if (userSesion.Habilitado)
                    { 
                        bool inscriptoAOtraComision = false;
                        List<Curso> cursosDeLaMateriaDisponibles = cl.GetCursosDeLaMateriaDisponibles(materia);
                        foreach (Curso c in cursosDeLaMateriaDisponibles)
                        {
                            foreach (AlumnoInscripcion alins in inscripcionesDelAlumno)
                            {
                                if (alins.Curso.ID == c.ID)
                                {
                                    inscriptoAOtraComision = true;
                                    break;
                                }
                            }

                            if (inscriptoAOtraComision)
                            {
                                break;
                            }
                        }

                        if (!inscriptoAOtraComision)
                        {
                            if (cursoSeleccionado.CuposDisponibles > 0)
                            {
                                this.modal.Visible = true;
                            }
                            else
                            {
                                this.textoAlerta.InnerText = "No hay cupos disponibles";
                                this.alerta.Attributes["style"] = "background-color: #F0B435";
                                this.alerta.Visible = true;
                            }
                        }
                        else
                        {
                            this.textoAlerta.InnerText = "Ya se ha inscripto a la materia en otra comisión";
                            this.alerta.Attributes["style"] = "background-color: #F0B435";
                            this.alerta.Visible = true;
                        }
                    }
                    else
                    {
                        this.textoAlerta.InnerText = "No está habilitado para inscribirse";
                        this.alerta.Attributes["style"] = "background-color: #F0B435";
                        this.alerta.Visible = true;
                    }
                }
                else if (cursoSeleccionado.CondicionAlumno == "Inscripto")
                {
                    btnAceptar.Text = "Darse de baja";
                    this.modal.Visible = true;
                }
            }
            else
            {
                this.textoAlerta.InnerText = "Seleccione un curso";
                this.alerta.Attributes["style"] = "background-color: #F0B435";
                this.alerta.Visible = true;
            }
        }

        protected void volverLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InscripcionCursos.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            InscripcionLogic il = new InscripcionLogic();
            CursoLogic cl = new CursoLogic();
            Curso cursoSeleccionado = cl.GetOne((int)this.ViewState["IdCurso"]);

            if (cursoSeleccionado != null)
            {
                List<AlumnoInscripcion> inscripcionesDelAlumno = il.GetInscripcionesDelAlumno(userSesion.Persona);

                cursoSeleccionado.CondicionAlumno = "No Inscripto";
                foreach (AlumnoInscripcion alins in inscripcionesDelAlumno)
                {
                    if (alins.Curso.ID == cursoSeleccionado.ID)
                    {
                        cursoSeleccionado.CondicionAlumno = "Inscripto";
                        break;
                    }
                }

                if (cursoSeleccionado.CondicionAlumno == "Inscripto")
                {
                    try
                    {
                        il.DesinscribirAlumno(userSesion.Persona.ID, cursoSeleccionado.ID);

                        this.modal.Visible = false;
                        this.textoAlerta.InnerText = "Inscripción eliminada";
                        this.alerta.Attributes["style"] = "background-color: #31DE35";
                        this.alerta.Visible = true;

                        LoadGrid();
                    }
                    catch(Exception)
                    {
                        this.textoAlerta.InnerText = "Inscripción no eliminada";
                        this.alerta.Attributes["style"] = "background-color: #EC3434";
                        this.alerta.Visible = true;
                    }
                }
                else if (cursoSeleccionado.CondicionAlumno == "No Inscripto")
                {
                    try
                    {
                        il.InscribirAlumno(userSesion.Persona.ID, cursoSeleccionado.ID);

                        this.modal.Visible = false;
                        this.textoAlerta.InnerText = "Inscripto a " + cursoSeleccionado.Materia.Descripcion + " en comisión " + cursoSeleccionado.Comision.Descripcion;
                        this.alerta.Attributes["style"] = "background-color: #31DE35";
                        this.alerta.Visible = true;

                        LoadGrid();
                    }
                    catch(Exception)
                    {
                        this.textoAlerta.InnerText = "Inscripción no registrada";
                        this.alerta.Attributes["style"] = "background-color: #EC3434";
                        this.alerta.Visible = true;
                    }
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.alerta.Visible = false;
            this.modal.Visible = false;
        }
    }
}