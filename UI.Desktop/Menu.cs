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
using Lab01;

namespace UI.Desktop
{
    public partial class Menu : Form
    {
        private Usuario _usuarioSesion;

        public Usuario UsuarioSesion
        {
            set
            {
                _usuarioSesion = value;
            }
            get
            {
                return _usuarioSesion;
            }
        }

        public Menu()
        {
            Form login = new formLogin(this);
            login.ShowDialog();
            if(UsuarioSesion != null)
            {
                InitializeComponent();
                tsmUsuario.Text = UsuarioSesion.NombreUsuario;
            }
            else
            {
                this.Close();
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormUsuarios = new Usuarios();
            FormUsuarios.Show();       
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormPersonas = new Personas();
            FormPersonas.Show();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormPlanes = new Planes();
            FormPlanes.Show();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormEspecialidades = new Especialidades();
            FormEspecialidades.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormComisiones = new Comisiones();
            FormComisiones.Show();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormCursos = new Cursos();
            FormCursos.Show();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormMaterias = new Materias();
            FormMaterias.Show();
        }

        private void materiasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form FormReporteMaterias = new ReporteMaterias();
            FormReporteMaterias.Show();
        }

        private void comisionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form FormReporteComisiones = new ReporteComisiones();
            FormReporteComisiones.Show();
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormReporteAlumnos = new ReporteAlumnos();
            FormReporteAlumnos.Show();
        }

        private void materiasCorrelativasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formMateriasCorrelativas = new MateriasCorrelativas();
            formMateriasCorrelativas.Show();
        }
    }
}
