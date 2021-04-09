using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Cursos : Form
    {
        public Cursos()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            CursoLogic cl = new CursoLogic();
            this.dvgCursos.AutoGenerateColumns = false;
            this.dvgCursos.DataSource = cl.GetAll();
        }

        private void Personas_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            CursoDesktop formCurso = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            formCurso.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dvgCursos.SelectedRows.Count > 0)
            {
                CursoDesktop formCurso = new CursoDesktop(((Curso)this.dvgCursos.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Modificacion);
                formCurso.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dvgCursos.SelectedRows.Count > 0)
            {
                CursoDesktop formCurso = new CursoDesktop(((Curso)this.dvgCursos.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Baja);
                formCurso.ShowDialog();
                this.Listar();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }
    }
}