using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class PlanDesktop : ApplicationForm
    {
        private Plan _planActual;

        public Plan PlanActual
        {
            set
            {
                _planActual = value;
            }
            get
            {
                return _planActual;
            }
        }

        public PlanDesktop()
        {
            InitializeComponent();
            CargarEspecialidades();
        }

        private void CargarEspecialidades()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            foreach (Especialidad especialidad in el.GetAll())
            {
                comboBoxEspecialidades.Items.Add(especialidad);
            }
        }

        public PlanDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            PlanLogic pl = new PlanLogic();
            PlanActual = pl.GetOne(ID);
            this.MapearDeDatos();
            if (this.Modo == ModoForm.Baja)
            {
                this.DeshabilitarCampos();
            }
        }

        public void DeshabilitarCampos()
        {
            this.txtDescripcion.ReadOnly = true;
            this.comboBoxEspecialidades.Enabled = false;
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
            this.comboBoxEspecialidades.Text = this.PlanActual.Especialidad.ToString();

            switch (Modo)
            {
                case ModoForm.Modificacion:
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                PlanActual = new Plan();
            }

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                PlanActual.Descripcion = this.txtDescripcion.Text;
                PlanActual.Especialidad = (Especialidad)this.comboBoxEspecialidades.SelectedItem;
            }

            if (Modo == ModoForm.Modificacion)
            {
                PlanActual.ID = int.Parse(this.txtID.Text);
                PlanActual.State = BusinessEntity.States.Modified;
            }
        }

        public override void GuardarCambios()
        {
            PlanLogic pl = new PlanLogic();
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                pl.Save(PlanActual);
            }
            else if (Modo == ModoForm.Baja)
            {
                pl.Delete(PlanActual.ID);
            }
        }

        public override bool Validar()
        {
            if (txtDescripcion.Text != "" && comboBoxEspecialidades.SelectedItem != null)
            {
                return true;
            }
            else
            {
                this.Notificar("Invalido", "Completa todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
