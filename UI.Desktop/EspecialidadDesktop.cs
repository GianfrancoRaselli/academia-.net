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
    public partial class EspecialidadDesktop : ApplicationForm
    {
        private Especialidad _especialidadActual;

        public Especialidad EspecialidadActual
        {
            set
            {
                _especialidadActual = value;
            }
            get
            {
                return _especialidadActual;
            }
        }

        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public EspecialidadDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            EspecialidadLogic el = new EspecialidadLogic();
            EspecialidadActual = el.GetOne(ID);
            this.MapearDeDatos();
            if (this.Modo == ModoForm.Baja)
            {
                this.DeshabilitarCampos();
            }
        }

        public void DeshabilitarCampos()
        {
            this.txtDescripcion.ReadOnly = true;
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;

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
                EspecialidadActual = new Especialidad();
            }

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                EspecialidadActual.Descripcion = this.txtDescripcion.Text;
            }

            if (Modo == ModoForm.Modificacion)
            {
                EspecialidadActual.ID = int.Parse(this.txtID.Text);
                EspecialidadActual.State = BusinessEntity.States.Modified;
            }
        }

        public override void GuardarCambios()
        {
            EspecialidadLogic el = new EspecialidadLogic();

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                el.Save(EspecialidadActual);
            }
            else if (Modo == ModoForm.Baja)
            {
                el.Delete(EspecialidadActual.ID);
            }
        }

        public override bool Validar()
        {
            if (txtDescripcion.Text != "")
            {
                return true;
            }
            else
            {
                this.Notificar("Invalido", "La descripción no puede estar vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
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

        private void button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}