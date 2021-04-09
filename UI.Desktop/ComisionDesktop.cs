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
    public partial class ComisionDesktop : ApplicationForm
    {
        private Comision _comisionActual;

        public Comision ComisionActual
        {
            get { return _comisionActual; }
            set { _comisionActual = value; }
        }

        public ComisionDesktop()
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

        public ComisionDesktop(ModoForm modo): this()
        {
            Modo = modo;
        }

        public ComisionDesktop(int ID, ModoForm modo): this()
        {
            this.Modo = modo;
            ComisionLogic cl = new ComisionLogic();
            ComisionActual = cl.GetOne(ID);
            this.MapearDeDatos();
            if (this.Modo == ModoForm.Baja)
            {
                this.DeshabilitarCampos();
            }
        }

        public void DeshabilitarCampos()
        {
            this.txtDescComision.ReadOnly = true;
            this.txtAnioEspecialidad.ReadOnly = true;
            comboBoxPlan.Enabled = false;
        }

        public override void MapearADatos()
        {
           
            if (Modo == ModoForm.Alta)
            {
                ComisionActual = new Comision();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                ComisionActual.Descripcion = this.txtDescComision.Text;
                ComisionActual.AnioEspecialidad = int.Parse(this.txtAnioEspecialidad.Text);
                ComisionActual.Plan = (Plan)this.comboBoxPlan.SelectedItem;
            }
            if (Modo == ModoForm.Modificacion)
            {
                ComisionActual.ID = int.Parse(this.txtIdComision.Text);
                ComisionActual.State = BusinessEntity.States.Modified;
            }
        }

        public override void MapearDeDatos()
        {
            this.txtIdComision.Text = this.ComisionActual.ID.ToString();
            this.txtDescComision.Text = this.ComisionActual.Descripcion;
            this.comboBoxPlan.Text = this.ComisionActual.Plan.ToString();
            this.txtAnioEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();

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

        public override void GuardarCambios()
        {
            ComisionLogic cl = new ComisionLogic();

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                cl.Save(ComisionActual);
            }
            else if (Modo == ModoForm.Baja)
            {
                cl.Delete(ComisionActual.ID);
            }
        }

        public override bool Validar()
        {
            if (this.txtDescComision.Text !="" && this.txtAnioEspecialidad.Text != "" && this.comboBoxPlan.SelectedItem != null)
            {
                return true;
            }
            else
            {
                this.Notificar("Error en uno de los campos", "No puede haber campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }   
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
            this.Close();
        }
    }
}
