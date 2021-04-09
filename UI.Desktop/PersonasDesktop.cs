using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class PersonaDesktop : ApplicationForm
    {
        private Persona _personaActual;

        public Persona PersonaActual
        {
            set
            {
                _personaActual = value;
            }
            get
            {
                return _personaActual;
            }
        }

        public PersonaDesktop()
        {
            InitializeComponent();
            CargarPlanes();
            CargarTiposPersonas();
        }

        private void CargarPlanes()
        {
            PlanLogic pl = new PlanLogic();

            foreach (Plan plan in pl.GetAll())
            {
                comboBoxPlan.Items.Add(plan);
            }
        }

        private void CargarTiposPersonas()
        {
            comboBoxTipo.Items.Add(Persona.TiposPersona.Administrativo);
            comboBoxTipo.Items.Add(Persona.TiposPersona.Docente);
            comboBoxTipo.Items.Add(Persona.TiposPersona.Alumno);
        }

        public PersonaDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public PersonaDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            PersonaLogic pl = new PersonaLogic();
            PersonaActual = pl.GetOne(ID);
            this.MapearDeDatos();
            if (this.Modo == ModoForm.Baja)
            {
                this.DeshabilitarCampos();
            }
        }

        public void DeshabilitarCampos()
        {
            this.txtDireccion.ReadOnly = true;
            this.txtNombre.ReadOnly = true;
            this.txtApellido.ReadOnly = true;
            this.txtLegajo.ReadOnly = true;
            this.DateTimePicker.Enabled = false;
            this.txtTelefono.ReadOnly = true;
            this.txtEmail.ReadOnly = true;
            this.comboBoxTipo.Enabled = false;
            this.comboBoxPlan.Enabled = false;
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PersonaActual.ID.ToString();
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtApellido.Text = this.PersonaActual.Apellido;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
            this.txtTelefono.Text = this.PersonaActual.Telefono;
            this.DateTimePicker.Text = this.PersonaActual.FechaNacimiento.ToString();
            this.comboBoxTipo.Text = this.PersonaActual.TipoPersona.ToString();
            this.comboBoxPlan.Text = this.PersonaActual.Plan.ToString();

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
                PersonaActual = new Persona();
            }

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                PersonaActual.Apellido = this.txtApellido.Text;
                PersonaActual.Nombre = this.txtNombre.Text;
                PersonaActual.Email = this.txtEmail.Text;
                PersonaActual.Telefono = this.txtTelefono.Text;
                PersonaActual.Direccion = this.txtDireccion.Text;
                PersonaActual.FechaNacimiento = this.DateTimePicker.Value;
                PersonaActual.TipoPersona = (Persona.TiposPersona)this.comboBoxTipo.SelectedItem;
                PersonaActual.Plan = (Plan)this.comboBoxPlan.SelectedItem;
            }

            if (Modo == ModoForm.Modificacion)
            {
                PersonaActual.ID = int.Parse(this.txtID.Text);
                PersonaActual.State = BusinessEntity.States.Modified;
            }
        }

        public override void GuardarCambios()
        {
            PersonaLogic pl = new PersonaLogic();

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                pl.Save(PersonaActual);
            }
            else if (Modo == ModoForm.Baja)
            {
                pl.Delete(PersonaActual.ID);
            }
        }

        public override bool Validar()
        {
            if (txtNombre.Text != "" && txtApellido.Text != "" && txtTelefono.Text != "" && 
                txtDireccion.Text != "" && txtEmail.Text != "" && comboBoxTipo.SelectedItem != null && 
                comboBoxPlan.SelectedItem != null && DateTimePicker.Value != null)
            {
                if (DateTimePicker.Value < DateTime.Now)
                {
                    if (ValidarEMail(txtEmail.Text))
                    {
                        if (ValidarTelefono())
                        {
                            return true;
                        }
                        else
                        {
                            this.Notificar("Invalido", "Telefono invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        this.Notificar("Invalido", "EMail invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    this.Notificar("Invalido", "Fecha nacimiento invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                this.Notificar("Invalido", "Completa todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ValidarTelefono()
        {
            try
            {
                long.Parse(this.txtTelefono.Text);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool ValidarEMail(string email)
        {
            String expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}