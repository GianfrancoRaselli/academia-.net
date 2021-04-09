using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class MateriaCorrelativaDesktop : ApplicationForm
    {
        MateriaCorrelativa materiaActual = new MateriaCorrelativa();
        MateriaCorrelativaLogic mcl = new MateriaCorrelativaLogic();

        public MateriaCorrelativaDesktop()
        {
            InitializeComponent();
            CargarComboBoxes();
        }

        public MateriaCorrelativaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public MateriaCorrelativaDesktop(ModoForm modo, int ID) : this()
        {
            Modo = modo;

            materiaActual = mcl.GetOne(ID);
            MapearDeDatos();
            
            if (Modo == ModoForm.Baja)
            {
                DesabilitarCampos(false);
            }
        }

        public void CargarComboBoxes()
        {
            MateriaLogic ml = new MateriaLogic();
            foreach (Materia mat in ml.GetAll())
            {
                MatSucesoraComboBox.Items.Add(mat);
                MatPredecesoraComboBox.Items.Add(mat);
            }
            CondicionComboBox.Items.Add(MateriaCorrelativa.Condiciones.Regular);
            CondicionComboBox.Items.Add(MateriaCorrelativa.Condiciones.Aprobada);

            MatSucesoraComboBox.Text = "Elija materia sucesora";
            MatPredecesoraComboBox.Text = "Elija materia predecesora";
            CondicionComboBox.Text = "Elija Condicion";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    if (Validar())
                    {
                        MapearADatos();
                        GuardarCambios();
                        this.Close();
                    }
                    break;
                case ModoForm.Modificacion:
                    if (Validar())
                    {
                        MapearADatos();
                        materiaActual.State = BusinessEntity.States.Modified;
                        GuardarCambios();
                        this.Close();
                    }
                    break;
                case ModoForm.Baja:
                    materiaActual.State = BusinessEntity.States.Deleted;
                    GuardarCambios();
                    this.Close();
                    break;
            }
        }

        public override bool Validar()
        {
            if (MatSucesoraComboBox.Text != "Elija materia sucesora" && MatPredecesoraComboBox.Text != "Elija materia predecesora" && CondicionComboBox.Text != "Elija Condicion")
            {
                if (!MatSucesoraComboBox.Text.Equals(MatPredecesoraComboBox.Text))
                {
                    if (((Materia)MatSucesoraComboBox.SelectedItem).Plan.ID.Equals(((Materia)MatPredecesoraComboBox.SelectedItem).Plan.ID))
                    {
                        return true;
                    }
                    else
                    {
                        Notificar("Las materias deben ser del mismo plan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    Notificar("Las Materias predecesora y sucesora deben ser distintas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                Notificar("Debe elegir una materia sucesora, una materiea predecesora y una condicion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        public override void MapearADatos()
        {
            materiaActual.MateriaSucesora = (Materia)MatSucesoraComboBox.SelectedItem;
            materiaActual.MateriaPredecesora = (Materia)MatPredecesoraComboBox.SelectedItem;
            materiaActual.Condicion = (MateriaCorrelativa.Condiciones)CondicionComboBox.SelectedItem;
        }

        public override void GuardarCambios()
        {
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                mcl.Save(materiaActual);
            }
            else if (Modo == ModoForm.Baja)
            {
                mcl.Delete(materiaActual.ID);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public override void MapearDeDatos()
        {
            IDtextBox.Text = materiaActual.ID.ToString();
            MatPredecesoraComboBox.Text = materiaActual.MateriaPredecesora.ToString();
            MatSucesoraComboBox.Text = materiaActual.MateriaSucesora.ToString();
            CondicionComboBox.Text = materiaActual.Condicion.ToString();
        }

        public void DesabilitarCampos(bool value)
        {
            IDtextBox.Enabled = value;
            MatSucesoraComboBox.Enabled = value;
            MatPredecesoraComboBox.Enabled = value;
            CondicionComboBox.Enabled = value;
        }
    }
}
