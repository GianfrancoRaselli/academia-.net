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
    public partial class Personas : Form
    {
        public Personas()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            PersonaLogic pl = new PersonaLogic();
            this.dvgPersonas.AutoGenerateColumns = false;
            this.dvgPersonas.DataSource = pl.GetAll();
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
            PersonaDesktop formPersona = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            formPersona.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dvgPersonas.SelectedRows.Count > 0)
            {
                PersonaDesktop formPersona = new PersonaDesktop(((Persona)this.dvgPersonas.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Modificacion);
                formPersona.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dvgPersonas.SelectedRows.Count > 0)
            {
                PersonaDesktop formPersona = new PersonaDesktop(((Persona)this.dvgPersonas.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Baja);
                formPersona.ShowDialog();
                this.Listar();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form FormReporteAlumnos = new ReporteAlumnos();
            FormReporteAlumnos.Show();
        }
    }
}
