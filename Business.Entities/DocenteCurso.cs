using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        public enum TiposCargo
        {
            Profesor,
            Ayudante,
        }

        private TiposCargo _tiposCargo;
        public TiposCargo Cargo
        {
            get
            {
                return _tiposCargo;
            }
            set
            {
                _tiposCargo = value;
            }
        }

        private Curso _curso;
        public Curso Curso
        {
            get
            {
                return _curso;
            }
            set
            {
                _curso = value;
            }
        }

        private Persona _docente;
        public Persona Docente
        {
            get
            {
                return _docente;
            }
            set
            {
                _docente = value;
            }
        }

        public override string ToString()
        {
            return Docente + " - " + Curso + " - " + Cargo;
        }
    }
}
