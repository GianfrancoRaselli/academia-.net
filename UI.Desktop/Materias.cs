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
    public partial class Materias : Form
    {
        public Materias()
        {
            InitializeComponent();
        }
        
        public void Listar()
        {
            MateriaLogic ml = new MateriaLogic();
            this.dgvMaterias.AutoGenerateColumns = false;
            this.dgvMaterias.DataSource = ml.GetAll();
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            MateriaDesktop formMateria = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            formMateria.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if(dgvMaterias.SelectedRows.Count > 0)
            {
                MateriaDesktop formMateria = new MateriaDesktop(((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID,ApplicationForm.ModoForm.Modificacion);
                formMateria.ShowDialog();
                this.Listar();
            }
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.SelectedRows.Count > 0)
            {
                MateriaDesktop formMateria = new MateriaDesktop(((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Baja);
                formMateria.ShowDialog();
                this.Listar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form FormReporteMaterias = new ReporteMaterias();
            FormReporteMaterias.Show();
        }

        private void toolStripBtnNuevo_Click(object sender, EventArgs e)
        {
           /// MateriaCorrelativaDesktop formMateriaCorrelativa = new MateriaCorrelativaDesktop(ApplicationForm.ModoForm.Alta);
            //formMateriaCorrelativa.ShowDialog();
            //Listar();
        }
    }
}
