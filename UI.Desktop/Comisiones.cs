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
    public partial class Comisiones : Form
    {
        public Comisiones()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            ComisionLogic cl = new ComisionLogic();
            this.dgvComisiones.AutoGenerateColumns = false;
            this.dgvComisiones.DataSource = cl.GetAll();
        }

        private void Comisiones_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_MouseClick(object sender, MouseEventArgs e)
        {
            Listar();
        }

        private void btnSalir_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop formComision= new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            formComision.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvComisiones.SelectedRows.Count > 0)
            {
                ComisionDesktop formComision= new ComisionDesktop(((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Modificacion);
                formComision.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvComisiones.SelectedRows.Count > 0)
            {
                ComisionDesktop formComision = new ComisionDesktop(((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Baja);
                formComision.ShowDialog();
                this.Listar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form FormReporteComisiones = new ReporteComisiones();
            FormReporteComisiones.Show();
        }
    }
}
