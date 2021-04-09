using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
        private int _anioEspecialidad;
        public int AnioEspecialidad
        {
            get
            {
                return _anioEspecialidad;
            }
            set
            {
                _anioEspecialidad = value;
            }
        }

        private string _descripcion;
        public string Descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }

        private Plan _plan;
        public Plan Plan
        {
            get
            {
                return _plan;
            }
            set
            {
                _plan = value;
            }
        }

        private string _descPlan;
        public string DescPlan
        {
            get
            {
                return _descPlan;
            }
            set
            {
                _descPlan = value;
            }
        }

        public override string ToString()
        {
            return Descripcion + "- " + Plan;
        }
    }
}
