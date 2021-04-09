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
    public partial class Planes : Form
    {
        public Planes()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            this.dgvPlanes.AutoGenerateColumns = false;
            this.dgvPlanes.DataSource = pl.GetAll();
        }

        private void Especialidades_Load(object sender, EventArgs e)
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
            PlanDesktop formPlan = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            formPlan.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count > 0)
            {
                PlanDesktop formPlan = new PlanDesktop(((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Modificacion);
                formPlan.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count > 0)
            {
                PlanDesktop formPlan = new PlanDesktop(((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Baja);
                formPlan.ShowDialog();
                this.Listar();
            }
        }
    }
}