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
    public partial class MateriasCorrelativas : Form
    {

        public MateriasCorrelativas()
        {
            InitializeComponent();
            Listar();
        }

        public void Listar()
        {
            MateriaCorrelativaLogic mcl = new MateriaCorrelativaLogic();
            dgvMatCorrelativas.AutoGenerateColumns = false;
            dgvMatCorrelativas.DataSource = mcl.GetAll();
        }

        private void toolStripBtnNuevo_Click(object sender, EventArgs e)
        {
            MateriaCorrelativaDesktop formMateriaCorrelativa = new MateriaCorrelativaDesktop(ApplicationForm.ModoForm.Alta);
            formMateriaCorrelativa.ShowDialog();
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripBtnEditar_Click_1(object sender, EventArgs e)
        {
            MateriaCorrelativaDesktop formMateriaCorrelativa = new MateriaCorrelativaDesktop(ApplicationForm.ModoForm.Modificacion, ((MateriaCorrelativa)this.dgvMatCorrelativas.SelectedRows[0].DataBoundItem).ID);
            formMateriaCorrelativa.ShowDialog();
            Listar();
        }

        private void toolStripBtnSalir_Click_1(object sender, EventArgs e)
        {
            MateriaCorrelativaDesktop formMateriaCorrelativa = new MateriaCorrelativaDesktop(ApplicationForm.ModoForm.Baja, ((MateriaCorrelativa)this.dgvMatCorrelativas.SelectedRows[0].DataBoundItem).ID);
            formMateriaCorrelativa.ShowDialog();
            Listar();
        }
    }
}
