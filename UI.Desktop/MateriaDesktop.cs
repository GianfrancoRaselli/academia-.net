using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class MateriaDesktop : ApplicationForm
    {
        private Materia _materiaActural;
        public Materia MateriaActual
        {
            set { _materiaActural = value; }
            get { return _materiaActural; }
        }

        public MateriaDesktop()
        {
            InitializeComponent();
            CargarPlanes();
        }

        private void CargarPlanes()
        {
            PlanLogic pl = new PlanLogic();

            foreach (Plan plan in pl.GetAll())
            {
                comboBoxPlan.Items.Add(plan);
            }
        }

        public MateriaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public MateriaDesktop(int ID, ModoForm modo): this()
        {
            Modo = modo;
            MateriaLogic ml = new MateriaLogic();
            MateriaActual = ml.GetOne(ID);
            MapearDeDatos();
            if (this.Modo == ModoForm.Baja)
            {
                this.DeshabilitarCampos();
            }

        }

        public void DeshabilitarCampos()
        {
            this.txtIdMateria.ReadOnly = true;
            this.txtHsSemanales.ReadOnly = true;
            this.txtHsTotales.ReadOnly = true;
            this.txtDescMateria.ReadOnly = true;
            this.comboBoxPlan.Enabled = false;
        }

        public override void MapearADatos()
        {
            if(Modo == ModoForm.Alta)
            {
                this.MateriaActual = new Materia();
            }
            if(Modo == ModoForm.Modificacion)
            {
                this.MateriaActual.ID = int.Parse(this.txtIdMateria.Text);
                this.MateriaActual.State = BusinessEntity.States.Modified;
            }
            if(Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.MateriaActual.Descripcion = this.txtDescMateria.Text;
                this.MateriaActual.HsSemanales = int.Parse(this.txtHsSemanales.Text);
                this.MateriaActual.HsTotales = int.Parse(this.txtHsTotales.Text);
                this.MateriaActual.Plan = (Plan)this.comboBoxPlan.SelectedItem;
            }
        }

        public override void MapearDeDatos()
        {
            this.txtIdMateria.Text = this.MateriaActual.ID.ToString();
            this.txtDescMateria.Text = this.MateriaActual.Descripcion;
            this.txtHsSemanales.Text = this.MateriaActual.HsSemanales.ToString();
            this.txtHsTotales.Text = this.MateriaActual.HsTotales.ToString();
            this.comboBoxPlan.Text = this.MateriaActual.Plan.ToString();

            switch (Modo)
            {
                case ModoForm.Modificacion:
                case ModoForm.Alta:
                    this.btnGuardar.Text = "Guardar";
                    break;
                case ModoForm.Consulta:
                    this.btnGuardar.Text = "Aceptar";
                    break;
                case ModoForm.Baja:
                    this.btnGuardar.Text = "Eliminar";
                    break;
            }
        }

        public override bool Validar()
        {
            if(this.txtDescMateria.Text != "" && this.txtHsSemanales.Text != "" && this.txtHsTotales.Text != "" && this.comboBoxPlan.SelectedItem != null)
            {
                return true;
            }
            else
            {
                this.Notificar("Error en uno de los campos", "No puede haber campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public override void GuardarCambios()
        {
            MateriaLogic ml = new MateriaLogic();

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
            }
            else if (Modo == ModoForm.Baja)
            {
                MateriaActual.State = BusinessEntity.States.Deleted;
            }
            ml.Save(MateriaActual);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                try
                {
                    this.GuardarCambios();
                    this.Close();
                }
                catch (Exception ex)
                {
                    this.Notificar("Invalido", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
