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
    public partial class CursoDesktop : ApplicationForm
    {
        private Curso _cursoActual;

        public Curso CursoActual
        {
            set
            {
                _cursoActual = value;
            }
            get
            {
                return _cursoActual;
            }
        }

        public CursoDesktop()
        {
            InitializeComponent();
            CargarTiposCuatrimestres();
            CargarMaterias();
            CargarComisiones();
        }

        private void CargarTiposCuatrimestres()
        {
            comboBoxTipoCuatrimestre.Items.Add(Curso.TiposCuatrimestre.Primero);
            comboBoxTipoCuatrimestre.Items.Add(Curso.TiposCuatrimestre.Segundo);
            comboBoxTipoCuatrimestre.Items.Add(Curso.TiposCuatrimestre.Anual);
        }

        private void CargarMaterias()
        {
            MateriaLogic ml = new MateriaLogic();

            foreach (Materia mat in ml.GetAll())
            {
                comboBoxMateria.Items.Add(mat);
            }
        }

        private void CargarComisiones()
        {
            ComisionLogic cl = new ComisionLogic();

            foreach (Comision com in cl.GetAll())
            {
                comboBoxComision.Items.Add(com);
            }
        }

        public CursoDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            CursoLogic cl = new CursoLogic();
            CursoActual = cl.GetOne(ID);
            this.MapearDeDatos();
            if (this.Modo == ModoForm.Baja)
            {
                this.DeshabilitarCampos();
            }
        }

        public void DeshabilitarCampos()
        {
            this.txtAnioCalendario.ReadOnly = true;
            this.txtCupos.ReadOnly = true;
            this.comboBoxMateria.Enabled = false;
            this.comboBoxComision.Enabled = false;
            this.comboBoxTipoCuatrimestre.Enabled = false;
            this.chkComenzado.Enabled = false;
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.CursoActual.ID.ToString();
            this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupos.Text = this.CursoActual.Cupos.ToString();
            this.comboBoxMateria.Text = this.CursoActual.Materia.ToString();
            this.comboBoxComision.Text = this.CursoActual.Comision.ToString();
            this.comboBoxTipoCuatrimestre.Text = this.CursoActual.TipoCuatrimestre.ToString();
            this.chkComenzado.Checked = this.CursoActual.Comenzado;

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
                CursoActual = new Curso();
            }

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                CursoActual.AnioCalendario = int.Parse(this.txtAnioCalendario.Text);
                CursoActual.Cupos = int.Parse(this.txtCupos.Text);
                CursoActual.Materia = (Materia)this.comboBoxMateria.SelectedItem;
                CursoActual.Comision = (Comision)this.comboBoxComision.SelectedItem;
                CursoActual.TipoCuatrimestre = (Curso.TiposCuatrimestre)this.comboBoxTipoCuatrimestre.SelectedItem;
                CursoActual.Comenzado = this.chkComenzado.Checked;
            }

            if (Modo == ModoForm.Modificacion)
            {
                CursoActual.ID = int.Parse(this.txtID.Text);
                CursoActual.State = BusinessEntity.States.Modified;
            }
        }

        public override void GuardarCambios()
        {
            CursoLogic cl = new CursoLogic();

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                cl.Save(CursoActual);
            }
            else if (Modo == ModoForm.Baja)
            {
                cl.Delete(CursoActual.ID);
            }
        }

        public override bool Validar()
        {
            if (txtAnioCalendario.Text != "" && txtCupos.Text != "" && comboBoxMateria.SelectedItem != null &&
                comboBoxComision.SelectedItem != null && comboBoxTipoCuatrimestre.SelectedItem != null)
            {
                if(((Comision)comboBoxComision.SelectedItem).Plan.ID == ((Materia)comboBoxMateria.SelectedItem).Plan.ID)
                {
                    return true;
                }
                else 
                {
                    this.Notificar("Invalido", "La comisión y la materia elegida deben pertenecer al mismo plan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
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