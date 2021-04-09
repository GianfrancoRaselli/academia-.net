using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Plan : BusinessEntity
    {
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

        private Especialidad _especialidad;

        public Especialidad Especialidad
        {
            get
            {
                return _especialidad;
            }
            set
            {
                _especialidad = value;
            }
        }

        public override string ToString()
        {
            return Descripcion + " - " + Especialidad;
        }
    }
}