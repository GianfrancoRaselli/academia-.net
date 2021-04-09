using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class MateriaCorrelativa : BusinessEntity
    {
        public enum Condiciones
        {
            Regular,
            Aprobada,
        }

        private Condiciones _condicion;
        public Condiciones Condicion
        {
            get
            {
                return _condicion;
            }
            set
            {
                _condicion = value;
            }
        }

        private Materia _materiaSucesora;
        public Materia MateriaSucesora
        {
            get
            {
                return _materiaSucesora;
            }
            set
            {
                _materiaSucesora = value;
            }
        }

        private Materia _materiaPredecesora;
        public Materia MateriaPredecesora
        {
            get
            {
                return _materiaPredecesora;
            }
            set
            {
                _materiaPredecesora = value;
            }
        }
    }
}
